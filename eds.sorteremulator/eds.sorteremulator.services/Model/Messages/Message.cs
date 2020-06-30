using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using eds.sorteremulator.services.Configurations;

namespace eds.sorteremulator.services.Model.Messages
{
    public class Message
    {


        public int ParentPd { get; set; }

        public int Id { get; set; }
        public DateTime MessageTime { get; set; }

        public int MessageId { get; set; }
        public MessageType MessageType { get; set; }
        public int Pic { get; set; }


        public string AlibiId { get; set; }

        public int Hostpic { get; set; }

        public string Hostdata { get; set; }

        public int ParcelLength { get; set; }

        public int ParcelHeight { get; set; }

        public int ParcelWidth { get; set; }

        public int ParcelWeight { get; set; }

        public int ParcelWeightIdentification { get; set; }

        public int ParcelWeightScaleIdentification { get; set; }

        public int ParcelOriginalDestination { get; set; }
        public char OriginalDestinationState { get; set; }

        public string OriginalDestinationStateString
        {
            get { return OriginalDestinationState.ToString(); }
            set => OriginalDestinationState = Char.Parse(value);
        }

        public int ParcelActualDestination { get; set; }

        public int DestinationTranslateState { get; set; }

        public int ParcelAlternativeDestination1 { get; set; }

        public int ParcelAlternativeDestination2 { get; set; }

        public int ParcelAlternativeDestination3 { get; set; }

        public int ParcelAlternativeDestination4 { get; set; }

        public int ParcelAlternativeDestination5 { get; set; }



        public string ScannerData1 { get; set; }


        public string ScannerData2 { get; set; }

        public string ScannerData3 { get; set; }


        public string ScannerData4 { get; set; }


        public string ScannerData5 { get; set; }


        public string UpdateState { get; set; }

        public string ParcelEntrancePoint { get; set; }

        public string ParcelEntranceState { get; set; }

        public string ParcelExitPoint { get; set; }

        public string ParcelExitState { get; set; }

        public int Recirculations { get; set; }

        public string FirstFixedWindow { get; set; }

        public string NumberOfFixedWindows { get; set; }

        public string PositionOnFixedWindow { get; set; }

        public string PhysicalDestination { get; set; }

        public string BlockedState { get; set; }

        public int ParcelScannerId1 { get; set; }

        public int ParcelScannerId2 { get; set; }

        public int ParcelScannerId3 { get; set; }

        public int ParcelScannerId4 { get; set; }

        public int ParcelScannerId5 { get; set; }



        public string ParcelOrientation { get; set; }

        public string ParcelOffcentre { get; set; }

        public string Measuredlength { get; set; }

        public string Measuredwidth { get; set; }

        public string SocketName { get; set; }
        public string StringMessage { get; set; }

        public static bool ParseMessage(string message, IEnumerable<MessageConfig> messageConfig, out Message msg)
        {
            
            msg = new Message();
            msg.MessageTime = DateTime.Now;
            msg.StringMessage = message;
            if (string.IsNullOrEmpty(message))
            {

                throw new Exception("ParseMessage: message is empty");
            }
            if (message.StartsWith("<?xml"))
            {
                msg .MessageType=MessageType.Statistics;
                return true;
            }


            //Take the first argument..

            var messageFields = message.Split(new[] { '|' });

            if (messageFields.Length < 1)
            {
                throw new Exception("ParseMessage: message too short");
            }

            //keepaliveChecking
            if (messageFields.Length == 1)
            {
                if (messageFields[0].StartsWith("W2"))
                {
                    msg.MessageType=MessageType.KeepAliveRequest;
                    return true;

                }
                if (messageFields[0].StartsWith("W1"))
                {
                    msg.MessageType = MessageType.KeepAliveReply;
                    return true;
                }
            }
            //Now iterate over messageConfig
            if (!int.TryParse(messageFields[0], out int messageId))
            {
                //is remotecontrol?
                if (messageFields[0].StartsWith("CC"))
                {
                    msg.MessageType = MessageType.RemoteControl;
                    return true;
                }
                throw new Exception("ParseMessage: invalid message identifier");
            }

            //if (globalconfig.EnableEvents)
            //{
            //    if (globalconfig.EventMessageId == mgid)
            //    {
            //        msg.MessageType = MessageType.Event;

            //        return true;
            //    }
            //}

            var mc = messageConfig.FirstOrDefault(mconf => mconf.MessageId == messageId);
            if (mc == null)
            {
                throw new Exception("ParseMessage: unexpected message Received");
            }

            //now, check fields...
            msg.MessageType = mc.MessageType;
            msg.MessageId = mc.MessageId;
            var totalFields = mc.EnabledFields.Count;
            if (totalFields + 2 != messageFields.Length) //msgid + checksum
            {
                throw new Exception($"ParseMessage: unexpected message Length (Expected {totalFields + 2} fields, having {messageFields.Length} fields)");

            }
            int i = 1;

            foreach (var mfield in mc.EnabledFields.OrderBy(p => p.Order))
            {
                msg.SetField(mfield.FieldName, messageFields[i]);
                i++;
            }
           
            return true;


        }
        
        public static T ConvertGeneric<T>(object input)
        {
            try
            {

                Type t = typeof(T);
                
               if (t ==typeof(string))
                {
                    return (T) input;
                }
               if (t==typeof(int))
                {
                    int i = 0;
                    int.TryParse(input.ToString(), out i);
                    return (T)Convert.ChangeType(i,t);


                }
                if (t == typeof(char))
                {
                    return (T)Convert.ChangeType(Char.Parse(input.ToString()), t);
                }
                if (t == typeof(long))
                {
                    long l = 0;
                    long.TryParse(input.ToString(), out l);
                    return (T)Convert.ChangeType(l, t);
                }
                return (T)Convert.ChangeType(input, t);
            }
            catch
            {
                return default(T);
            }
        }

        static readonly ConcurrentDictionary<Type, MethodInfo> _convertersCache = new ConcurrentDictionary<Type, MethodInfo>();
        internal bool SetField(string fieldName, object fieldValue)
        {
            PropertyInfo pdpi = typeof(Message).GetProperties().FirstOrDefault(m => m.Name == fieldName);

            if (pdpi == null)
                return false;

            Type t = pdpi.PropertyType;
            var castMethod= _convertersCache.GetOrAdd(t, this.GetType().GetMethod("ConvertGeneric").MakeGenericMethod(t));
            pdpi.SetValue(this, castMethod.Invoke(null, new [] { fieldValue }));
            return true;
        }

        
        internal bool  GetField(string fieldName, out string fieldValue)
        {
            PropertyInfo pdpi = typeof(Message).GetProperties().FirstOrDefault(m => m.Name == fieldName);

            if (pdpi == null)
            {
                fieldValue = null;
                return false;
            }
            
            var resultval = pdpi.GetValue(this, null);

            string fieldval;
            if (resultval != null)

            {
                fieldval = resultval.ToString();
            }
            else
            {
                fieldval = string.Empty;
            }

            fieldValue = fieldval;
            return true;
            
        }
        public string GetMessageString(MessageConfig msgConfig)
        {
            var returnval = string.Empty;
            if (MessageId == 0)
            {
                throw new Exception("GetMessageString: Cannot generate a message without knowing message id");
            }
            if (msgConfig == null)
            {
                throw new Exception(string.Format("GetMessageString: There is no definition of message id {0}", MessageId));
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(MessageId + "|");
            foreach (var msconfig in msgConfig.EnabledFields)
            {
                string outval = string.Empty;
                if (GetField(msconfig.FieldName, out outval))
                {
                    switch (msconfig.LengthType)
                    {
                        case LengthType.FixedLength:
                            outval = outval.PadLeft(msconfig.MinLength, ' ');

                            break;

                        case LengthType.VariableLength:


                            if (outval.Length < msconfig.MinLength)
                            {
                                outval = outval.PadLeft(msconfig.MinLength, ' ');
                            }
                            else if (outval.Length > msconfig.MaxLength)
                            {
                                outval = outval.Substring(0, msconfig.MaxLength);

                            }
                            break;
                    }

                    sb.Append(outval + "|");

                }

                else
                {
                    throw new Exception("GetMessageString: Cannot get message field for " + msconfig.FieldName);
                }
            }
            return sb.ToString();
        }
        public string GetMessageString(IEnumerable<MessageConfig> messageConfig)
        {
            var returnval = string.Empty;
            if (MessageId == 0)
            {
                throw new Exception("GetMessageString: Cannot generate a message without knowing message id");
            }


            var msgConfig = messageConfig.FirstOrDefault(p => p.MessageId == MessageId);
            if (msgConfig == null)
            {
                throw new Exception(string.Format("GetMessageString: There is no definition of message id {0}", MessageId));
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(MessageId+"|");
            foreach (var msconfig in msgConfig.EnabledFields)
            {
                string outval = string.Empty;
                if (GetField(msconfig.FieldName, out outval))
                {
                    switch (msconfig.LengthType)
                    {
                        case LengthType.FixedLength:
                            outval = outval.PadLeft(msconfig.MinLength, ' ');

                            break;

                        case LengthType.VariableLength:


                            if (outval.Length < msconfig.MinLength)
                            {
                                outval = outval.PadLeft(msconfig.MinLength, ' ');
                            }
                            else if (outval.Length > msconfig.MaxLength)
                            {
                                outval = outval.Substring(0, msconfig.MaxLength);

                            }
                            break;
                    }

                    sb.Append(outval + "|");

                }

                else
                {
                    throw new Exception("GetMessageString: Cannot get message field for " + msconfig.FieldName);
                }
            





            }
            return sb.ToString();
        }
    }
}

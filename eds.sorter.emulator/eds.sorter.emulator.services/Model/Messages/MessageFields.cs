using System;
using System.Xml.Serialization;

namespace eds.sorter.emulator.services.Model.Messages
{
    public class MessageField
    {
        [XmlIgnore]
        public Type FieldType { get; set; }

        public int Order { get; set; }

        public LengthType LengthType { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }


        public virtual object GetMessageValue(object msgValue)
        {
            return new object();
        }


        public virtual string FieldName { get; set; }
        public virtual int DefaultOrder { get; set; }


    }

    public enum LengthType
    {
        FixedLength,
        VariableLength
    }

    public class PicField : MessageField
    {


        public PicField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 5;
            MaxLength = 5;
            FieldType = typeof(int);
        }


        private readonly int _defaultOrder = 0;

        private readonly string _messageField = "Pic";

        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

      
        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return  ivalue;
   
            }

            return 0;
        }
    }
    public class AlibiField : MessageField
    {


        public AlibiField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 23;
            MaxLength = 23;
            FieldType = typeof(string);
        }


        private readonly int _defaultOrder = 1;

        private readonly string _messageField = "Alibi";

        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }
    }
    public class HostpicField : MessageField
    {
        private readonly int _defaultOrder = 2;

        private readonly string _messageField = "Hostpic";

        public HostpicField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 10;
            MaxLength = 10;
            FieldType = typeof(int);
        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }
        #region Properties
        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        #endregion
    }
    public class HostdataField : MessageField
    {
        private readonly int _defaultOrder = 3;

        private readonly string _messageField = "Hostdata";

        public HostdataField()
        {
            LengthType = LengthType.VariableLength;
            MinLength = 30;
            MaxLength = 100;
            FieldType = typeof(string);

        }

        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{} 
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }
    }

    public class ParcelLengthField : MessageField
    {
        private readonly int _defaultOrder = 4;

        private readonly string _messageField = "ParcelLength";

        public ParcelLengthField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 4;
            MaxLength = 4;
            FieldType = typeof(int);

        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }

        #region Properties
        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        #endregion
    }
    public class ParcelHeightField : MessageField
    {
        private readonly int _defaultOrder = 5;

        private readonly string _messageField = "ParcelHeight";


        public ParcelHeightField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 4;
            MaxLength = 4;
            FieldType = typeof(int);

        }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }

        #region Properties
        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        #endregion
    }
    public class ParcelWidthField : MessageField
    {
        private readonly int _defaultOrder = 6;

        private readonly string _messageField = "ParcelWidth";

        public ParcelWidthField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 4;
            FieldType = typeof(int);

            MaxLength = 4;
        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }

        #region Properties
        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        #endregion
    }

    public class ParcelWeightField : MessageField
    {
        private readonly int _defaultOrder = 7;

        private readonly string _messageField = "ParcelWeight";



        public ParcelWeightField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 6;
            MaxLength = 6;
            FieldType = typeof(int);
        }
        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }

        #region Properties
        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        #endregion
    }


    public class ParcelWeightIdentificationField : MessageField
    {
        private readonly int _defaultOrder = 8;

        private readonly string _messageField = "ParcelWeightIdentification";

        public ParcelWeightIdentificationField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 10;
            MaxLength = 10;
            FieldType = typeof(int);

        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }

        #region Properties
        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        #endregion
    }

    public class ParcelWeightScaleIdentificationField : MessageField
    {
        private readonly int _defaultOrder = 9;

        private readonly string _messageField = "ParcelWeightScaleIdentification";

        public ParcelWeightScaleIdentificationField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 3;
            MaxLength = 3;
            FieldType = typeof(int);

        }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }

        #region Properties
        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        #endregion
    }


    public class ParcelOriginalDestinationField : MessageField
    {
        private readonly int _defaultOrder = 10;

        private readonly string _messageField = "ParcelOriginalDestination";

        public ParcelOriginalDestinationField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 3;
            MaxLength = 3;
            FieldType = typeof(int);

        }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }

        #region Properties
        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        #endregion
    }



    public class OriginalDestinationStateField : MessageField
    {
        private readonly int _defaultOrder = 11;

        private readonly string _messageField = "OriginalDestinationState";

        public OriginalDestinationStateField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 1;
            FieldType = typeof(char);
            MaxLength = 1;
        }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            FieldType = typeof(string);


            return Convert.ToChar(value.ToString().Trim());




        }

        #region Properties
        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        #endregion
    }




    public class ParcelActualDestinationField : MessageField
    {
        private readonly int _defaultOrder = 12;

        private readonly string _messageField = "ParcelActualDestination";
        public ParcelActualDestinationField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 3;
            MaxLength = 3;
            FieldType = typeof(int);
        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }
        #region Properties
        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        #endregion
    }

    public class DestinationTranslateStateField : MessageField
    {
        private readonly int _defaultOrder = 13;

        private readonly string _messageField = "DestinationTranslateState";

        public DestinationTranslateStateField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 1;
            MaxLength = 1;
            FieldType = typeof(int);

        }
        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }

        #region Properties
        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        #endregion
    }

    //TODO: Check the 5 field problem

    public class ParcelAlternativeDestination1Field : MessageField
    {
        private readonly int _defaultOrder = 14;

        private readonly string _messageField = "ParcelAlternativeDestination1";

        //TODO: CHeck multiple fields
        public ParcelAlternativeDestination1Field()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 3;
            MaxLength = 3;
            FieldType = typeof(string);

        }

        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; }   set{}
        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }

    }
    public class ParcelAlternativeDestination2Field : MessageField
    {
        private readonly int _defaultOrder = 14;

        private readonly string _messageField = "ParcelAlternativeDestination2";

        //TODO: CHeck multiple fields
        public ParcelAlternativeDestination2Field()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 3;
            MaxLength = 3;
            FieldType = typeof(string);

        }

        public override int DefaultOrder
        {
            get { return _defaultOrder; }
            set { }
        }

        public override string FieldName
        {
            get { return _messageField; }
            set { }
        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }

    }
    public class ParcelAlternativeDestination3Field : MessageField
    {
        private readonly int _defaultOrder = 14;

        private readonly string _messageField = "ParcelAlternativeDestination3";

        //TODO: CHeck multiple fields
        public ParcelAlternativeDestination3Field()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 3;
            MaxLength = 3;
            FieldType = typeof(string);

        }

        public override int DefaultOrder
        {
            get { return _defaultOrder; }
            set { }
        }

        public override string FieldName
        {
            get { return _messageField; }
            set { }
        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }

    }
    public class ParcelAlternativeDestination4Field : MessageField
    {
        private readonly int _defaultOrder = 14;

        private readonly string _messageField = "ParcelAlternativeDestination4";

        //TODO: CHeck multiple fields
        public ParcelAlternativeDestination4Field()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 3;
            MaxLength = 3;
            FieldType = typeof(string);

        }

        public override int DefaultOrder
        {
            get { return _defaultOrder; }
            set { }
        }

        public override string FieldName
        {
            get { return _messageField; }
            set { }
        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }

    }
    public class ParcelAlternativeDestination5Field : MessageField
    {
        private readonly int _defaultOrder = 14;

        private readonly string _messageField = "ParcelAlternativeDestination5";

        //TODO: CHeck multiple fields
        public ParcelAlternativeDestination5Field()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 3;
            MaxLength = 3;
            FieldType = typeof(string);

        }

        public override int DefaultOrder
        {
            get { return _defaultOrder; }
            set { }
        }

        public override string FieldName
        {
            get { return _messageField; }
            set { }
        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }

    }
    public class ScannerData1Field : MessageField
    {
        private readonly int _defaultOrder = 15;

        private readonly string _messageField = "ScannerData1";

        public ScannerData1Field()
        {
            LengthType = LengthType.VariableLength;
            MinLength = 1;
            MaxLength = 200;
            FieldType = typeof(string);
        }

        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }


    }



    public class ScannerData2Field : MessageField
    {
        private readonly int _defaultOrder = 16;

        private readonly string _messageField = "ScannerData2";

        public ScannerData2Field()
        {
            LengthType = LengthType.VariableLength;
            MinLength = 1;
            FieldType = typeof(string);
            MaxLength = 200;
        }

        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }



    }


    public class ScannerData3Field : MessageField
    {
        private readonly int _defaultOrder = 17;

        private readonly string _messageField = "ScannerData3";

        public ScannerData3Field()
        {
            LengthType = LengthType.VariableLength;
            MinLength = 1;
            MaxLength = 200;
            FieldType = typeof(string);

        }



        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }


    }

    public class ScannerData4Field : MessageField
    {
        private readonly int _defaultOrder = 18;

        private readonly string _messageField = "ScannerData4";


        public ScannerData4Field()
        {
            LengthType = LengthType.VariableLength;
            MinLength = 1;
            MaxLength = 200;
            FieldType = typeof(string);

        }
        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }
    }





        public class ScannerData5Field : MessageField
        {
            private readonly int _defaultOrder = 19;

            private readonly string _messageField = "ScannerData5";


        public ScannerData5Field()
        {
            LengthType = LengthType.VariableLength;
            MinLength = 1;
            MaxLength = 200;
            FieldType = typeof(string);

        }
        public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();


            //TODO:  ADD messageType

        }
    

        }
        public class UpdateStateField : MessageField
        {
            private readonly int _defaultOrder = 20;

            private readonly string _messageField = "UpdateState";

        public UpdateStateField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 8;
            MaxLength = 8;

            FieldType = typeof(string) ;

        }

        public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }


    }
        public class ParcelEntrancePointField : MessageField
        {
            private readonly int _defaultOrder = 21;

            private readonly string _messageField = "ParcelEntrancePoint";

        public ParcelEntrancePointField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 14;
            MaxLength = 14;

            FieldType = typeof(string);

        }

        public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }

    }
        public class ParcelEntranceStateField : MessageField
        {
            private readonly int _defaultOrder = 22;

            private readonly string _messageField = "ParcelEntranceState";


        public ParcelEntranceStateField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 1;
            MaxLength = 1;
            FieldType = typeof(int);

        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }
        #region Properties
        public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }

            #endregion

        }
        public class ParcelExitPointField : MessageField
        {
            private readonly int _defaultOrder = 23;

            private readonly string _messageField = "ParcelExitPoint";
        public ParcelExitPointField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 14;
            FieldType = typeof(string);
            MaxLength = 14;
        }


            public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }

    }
        public class ParcelExitStateField : MessageField
        {
            private readonly int _defaultOrder = 24;

            private readonly string _messageField = "ParcelExitState";



        public ParcelExitStateField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 1;
            MaxLength = 1;
            FieldType = typeof(int);

        }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }
        #region Properties
        public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }

            #endregion

        }

        public class RecirculationsField : MessageField
        {
            private readonly int _defaultOrder = 25;

            private readonly string _messageField = "Recirculations";

        public RecirculationsField()
        {
            LengthType = LengthType.FixedLength;
            MinLength = 4;
            MaxLength = 4;

            FieldType = typeof(int);

        }



        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }

        #region Properties
        public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }

            #endregion

        }

        public class ParcelScannerId1Field : MessageField
        {
            private readonly int _defaultOrder = 26;

            private readonly string _messageField = "ParcelScannerId1";


        public ParcelScannerId1Field()
        {


            LengthType = LengthType.FixedLength;
            MinLength = 10;
            MaxLength = 10;
            FieldType = typeof(int);

        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }
        #region Properties
        public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }

            #endregion

        }
        public class ParcelScannerId2Field : MessageField
        {
            private readonly int _defaultOrder = 27;

            private readonly string _messageField = "ParcelScannerId2";


        public ParcelScannerId2Field()
        {

            LengthType = LengthType.FixedLength;
            MinLength = 10;
            MaxLength = 10;
            FieldType = typeof(int);

        }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }

        #region Properties
        public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }

            #endregion

        }
        public class ParcelScannerId3Field : MessageField
        {
            private readonly int _defaultOrder = 28;

            private readonly string _messageField = "ParcelScannerId3";

        public ParcelScannerId3Field()
        {

            LengthType = LengthType.FixedLength;
            MinLength = 10;
            FieldType = typeof(int);

            MaxLength = 10;
        }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }

        #region Properties
        public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }

            #endregion

        }
        public class ParcelScannerId4Field : MessageField
        {
            private readonly int _defaultOrder = 29;

            private readonly string _messageField = "ParcelScannerId4";

        public ParcelScannerId4Field()
        {

            LengthType = LengthType.FixedLength;
            MinLength = 10;
            MaxLength = 10;
            FieldType = typeof(int);
        }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }
        #region Properties
        public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }

            #endregion

        }
        public class ParcelScannerId5Field : MessageField
        {
            private readonly int _defaultOrder = 30;

            private readonly string _messageField = "ParcelScannerId5";
        public ParcelScannerId5Field()
        {

            LengthType = LengthType.FixedLength;
            MinLength = 10;
            MaxLength = 10;
            FieldType = typeof(int);
        }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return 0;
            int ivalue = 0;

            if (int.TryParse(value.ToString(), out ivalue))
            {
                return ivalue;

            }

            return 0;
        }

        #region Properties
        public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }

            #endregion

        }

        public class FirstFixedWindowField : MessageField
        {
            private readonly int _defaultOrder = 31;

            private readonly string _messageField = "FirstFixedWindow";
        public FirstFixedWindowField()
        {

            LengthType = LengthType.FixedLength;
            MinLength = 14;
            MaxLength = 14; FieldType = typeof(string);
        }


            public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }


    }

        public class NumberOfFixedWindows : MessageField
        {
            private readonly int _defaultOrder = 32;

            private readonly string _messageField = "NumberOfFixedWindows";

        public NumberOfFixedWindows()
        {

            LengthType = LengthType.FixedLength;
            MinLength = 4;
            MaxLength = 4;

            FieldType = typeof(string);
        }

            public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }


    }
        public class PositionOnFixedWindowField : MessageField
        {
            private readonly int _defaultOrder = 33;

            private readonly string _messageField = "PositionOnFixedWindow";
        public PositionOnFixedWindowField()
        {

            LengthType = LengthType.FixedLength;
            MinLength = 4;
            MaxLength = 4; FieldType = typeof(string);
        }
 

            public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }


        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }


    }

        public class PhysicalDestinationField : MessageField
        {
            private readonly int _defaultOrder = 34;

            private readonly string _messageField = "PhysicalDestination";

        public PhysicalDestinationField()
        {

            LengthType = LengthType.FixedLength;
            MinLength = 3;
            MaxLength = 3;
            FieldType = typeof(string);
        }

            public override int DefaultOrder
            {
                get { return _defaultOrder; }set{}
            }

            public override string FieldName
            {
                get { return _messageField; } set{}
            }
        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }

    }

    public class BlockedStateField : MessageField
    {
        private readonly int _defaultOrder = 35;

        private readonly string _messageField = "BlockedState";

        public BlockedStateField()
        {

            LengthType = LengthType.FixedLength;
            MinLength = 4;
            MaxLength = 4;
            FieldType = typeof(string);
        }

        public override int DefaultOrder
        {
            get { return _defaultOrder; }set{}
        }

        public override string FieldName
        {
            get { return _messageField; } set{}
        }


       

        public override object GetMessageValue(object value)
        {

            if (value == null)
                return string.Empty;
            string val = string.Empty;

            return value.ToString().Trim();




        }


    }

}
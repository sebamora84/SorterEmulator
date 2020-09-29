using Autofac;
using eds.sorteremulator.services.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace eds.sorteremulator.fileservices
{
    public class FileService : IStartable
    {
        private readonly string _fileProcessingDirectory = @".\FileProcessing";
        private readonly string _fileProcessedDirectory = @".\FileProcessing\Processed";
        private readonly string _fileErrorDirectory = @".\FileProcessing\Error";
        private readonly string _fileTemplatesDirectory = @".\FileProcessing\Templates";
        private readonly ILogger<FileService> _logger;
        private readonly IParcelService _parcelsService;
        private readonly INodesService _nodesService;
        private readonly IPhysicsService _physicsService;
        private Timer _processFileTimer;

        public FileService(ILogger<FileService> logger, IParcelService parcelsService, INodesService nodesService, IPhysicsService physicsService)
        {
            _logger = logger;
            _parcelsService = parcelsService;
            _nodesService = nodesService;
            _physicsService = physicsService;
        }
        public async Task ProcessFiles()
        {
            DirectoryInfo processingDirectory = new DirectoryInfo(_fileProcessingDirectory);
            foreach (var item in processingDirectory.GetFiles("*Induction*.csv").OrderBy(p => p.LastWriteTime))
            {
                try
                {
                    await ProcessInductionFile(item);                   
                    string fileNewFullName = Path.Combine(_fileProcessedDirectory, DateTime.Now.ToString("yyyyMMddHHmmssfff") + item.Name);
                    File.Move(item.FullName, fileNewFullName);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error while processing file {item.FullName}");
                    string fileNewFullName = Path.Combine(_fileErrorDirectory, DateTime.Now.ToString("yyyyMMddHHmmssfff") + item.Name);
                    File.Move(item.FullName, fileNewFullName);
                }
            }
        }
        public async Task ProcessInductionFile(FileInfo fileInfo)
        {
            using (StreamReader file = fileInfo.OpenText())
            {
                var line = string.Empty;
                while (!string.IsNullOrEmpty(line = file.ReadLine()))
                {
                    var input = line.Split(";");
                    var delay = Convert.ToInt32(input[0]);
                    var nodeGuid = new Guid(input[1]);
                    var scannerData1=input[2];
                    var scannerData2=input[3]; 
                    var scannerData3=input[4]; 
                    var scannerData4=input[5]; 
                    var scannerData5=input[6];

                    await Task.Delay(delay);

                    var node = _nodesService.GetNode(nodeGuid);
                    if (node == null)
                    {
                        _logger.LogInformation($"No node with Id {nodeGuid}");
                        continue;
                    }
                    var parcel = _parcelsService.AddNewParcel(node, scannerData1, scannerData2, scannerData3, scannerData4, scannerData5);
                    _physicsService.AddTracking(parcel.Pic, node.Id, 0);
                }
            }
        }

        public void Start()
        {
            CreateDirectories();
            _processFileTimer = new Timer(1000);
            _processFileTimer.Elapsed += _processFileTimer_Elapsed;
            _processFileTimer.Start();
        }

        private void CreateDirectories()
        {
            DirectoryInfo processingDirectory = new DirectoryInfo(_fileProcessingDirectory);
            if (!processingDirectory.Exists)
            {
                processingDirectory.Create();
            }
            DirectoryInfo processedDirectory = new DirectoryInfo(_fileProcessedDirectory);
            if (!processedDirectory.Exists)
            {
                processedDirectory.Create();
            }
            DirectoryInfo errorDirectory = new DirectoryInfo(_fileErrorDirectory);
            if (!errorDirectory.Exists)
            {
                errorDirectory.Create();
            }
            DirectoryInfo templatesDirectory = new DirectoryInfo(_fileTemplatesDirectory);
            if (!templatesDirectory.Exists)
            {
                templatesDirectory.Create();
            }
        }

        private void _processFileTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            try
            {
                _processFileTimer.Stop(); 
                ProcessFiles().Wait();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error while processing files");
            }
            finally
            {
                _processFileTimer.Start();
            }
        }
    }
}

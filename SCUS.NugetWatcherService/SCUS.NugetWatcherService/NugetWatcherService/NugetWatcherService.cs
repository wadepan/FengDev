using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NuGet;
using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

public class NugetWatcherService : BackgroundService
{
    private readonly string _nugetFolder;
    private readonly string _archiveFolder;
    private readonly string _logPath;
    private readonly string _nugetExePath;
    private readonly string _azureFeedUrl;
    private readonly string _apiKey;
    private readonly ILogger<NugetWatcherService> _logger;
    private readonly IConfiguration _configuration;
    private FileSystemWatcher _watcher;

    public NugetWatcherService(ILogger<NugetWatcherService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _nugetExePath = configuration.GetSection("NugetWatcher")["nugetExePath"];
        _nugetFolder = configuration.GetSection("NugetWatcher")["packagesPath"];
        _archiveFolder = configuration.GetSection("NugetWatcher")["archivePath"];
        _azureFeedUrl = configuration.GetSection("NugetWatcher")["feedUrl"];
        _apiKey = configuration.GetSection("NugetWatcher")["apiKey"];
        _logPath = configuration.GetSection("NugetWatcher")["logFilePath"];
        // Ensure archive directory exists
        Directory.CreateDirectory(_archiveFolder);

        // Setup FileSystemWatcher
        _watcher = new FileSystemWatcher
        {
            Path = _nugetFolder,
            Filter = "*.nupkg",
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName,
            IncludeSubdirectories = true,
            EnableRaisingEvents = true
        };

        _watcher.Created += OnFileCreated;
    }

    private void OnFileCreated(object sender, FileSystemEventArgs e)
    {


       
        Task.Run(() => ProcessPackage(e.FullPath));
    }

    private void ProcessPackage(string packagePath)
    {
        try
        {
            _logger.LogInformation($"New package detected: {packagePath}");

            // Push to Azure Artifacts
            string command = $"push \"{packagePath}\" -Source {_azureFeedUrl} -ApiKey {_apiKey}";

            _logger.LogInformation($"Executing: {command}");
            CancellationToken cancellationToken = CancellationToken.None;

            SourceCacheContext cache = new SourceCacheContext();
            SourceRepository repository = Repository.Factory.GetCoreV3("http://tfs.scinet.gov/tfs/defaultcollection/_packaging/SCUS.CommonLibs/nuget/v3/index.json");
            PackageUpdateResource resource = repository.GetResource<PackageUpdateResource>();
            NuGet.Common.ILogger logger = NuGet.Common.NullLogger.Instance;
            IList<string> p = new List<string>();
            p.Add(packagePath); 

            resource.Push(p,
                 symbolSource: null,
                 timeoutInSecond: 5 * 60,
                 disableBuffering: false,
                 getApiKey: packageSource => _apiKey,
                 getSymbolApiKey: packageSource => null,
                 noServiceEndpoint: false,
                 skipDuplicate: false,
                 symbolPackageUpdateResource: null,
                 logger);
            //RunCommand(_nugetExePath, command);

            // Move to archive
            string packageFolder = Path.GetDirectoryName(packagePath);
            string archiveDestination = Path.Combine(_archiveFolder, Path.GetFileName(packageFolder));

            if (!Directory.Exists(archiveDestination))
                Directory.CreateDirectory(archiveDestination);

            File.Move(packagePath, Path.Combine(archiveDestination, Path.GetFileName(packagePath)));
            _logger.LogInformation($"Package moved to archive: {archiveDestination}");

            // Delete original folder if empty
            if (Directory.Exists(packageFolder) && Directory.GetFiles(packageFolder).Length == 0)
            {
                Directory.Delete(packageFolder, true);
                _logger.LogInformation($"Deleted empty folder: {packageFolder}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error processing {packagePath}: {ex.Message}");
        }
    }

    private void RunCommand(string exePath, string arguments)
    {
        SecureString sec = new SecureString();
        string pwd = "Pflm_9882!!!!!"; /* Not Secure! */
        pwd.ToCharArray().ToList().ForEach(sec.AppendChar);
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = exePath,
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            UserName = $"court\fp2815",
            Password = sec
        }; 

        using (Process process = new Process { StartInfo = startInfo })
        {
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            _logger.LogInformation($"NuGet Output: {output}");
            if (!string.IsNullOrWhiteSpace(error))
                _logger.LogError($"NuGet Error: {error}");
        }
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _watcher?.Dispose();
        base.Dispose();
    }
}
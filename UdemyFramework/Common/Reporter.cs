using NLog;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.IO;
using System;


namespace UdemyFramework.Common
{
    public class Reporter
    {
        public Reporter() { }

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private static ExtentReports _reportManager { get; set; }
        private static string _extentPath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        private static string _projectPath = Directory.GetParent(Directory.GetParent(_extentPath).FullName).FullName + "\\ExtentReports";
        private static readonly Object _objToCreateExtent = new Object();
        private static string _htmlReportFullPath { get; set; }
        public static string LatestResultsReportFolder { get; set; }
        private static TestContext _myTestContext { get; set; }
        private static ExtentTest _currentTestCase { get; set; }

        private static ExtentReports extentInstance
        {
            get
            {
                lock (_objToCreateExtent)
                {
                    if (_reportManager == null)
                    {
                        CreateSingletonReporter();
                    }
                    return _reportManager;
                }
            }
        }

        public static ExtentReports CreateSingletonReporter()
        {
            _logger.Trace("Starting a one time setup for the entire" +
                            " .CreatingReports namespace. Initializing the reporter next...");
            CreateReportDirectory();
            //Initialize the Extent Report
            var htmlReporter = new ExtentHtmlReporter(_htmlReportFullPath);
            _reportManager = new ExtentReports();
            _reportManager.AttachReporter(htmlReporter);
            return _reportManager;
        }

        private static void CreateReportDirectory()
        {
            var filePath = Path.GetFullPath(_projectPath);
            LatestResultsReportFolder = Path.Combine(filePath, DateTime.Now.ToString("MMdd_HHmm"));
            Directory.CreateDirectory(LatestResultsReportFolder);
            _htmlReportFullPath = $"{LatestResultsReportFolder}\\TestResults.html";
            _logger.Trace("Full path of HTML report=>" + _htmlReportFullPath);
        }

        public static void AddTestCaseMetadataToHtmlReport(TestContext testContext)
        {
            _myTestContext = testContext;
            _currentTestCase = extentInstance.CreateTest(_myTestContext.Test.Name);
        }

        public static void LogPassingTestStepToBugLogger(string message)
        {
            _logger.Info(message);
            _currentTestCase.Log(Status.Pass, message);
        }

        public static void ReportTestOutcome(string screenshotPath)
        {
            var status = _myTestContext.Result.Outcome.Status;

            switch (status)
            {
                case TestStatus.Failed:
                    Console.WriteLine("Reporter.ReportTestOutcome: Failed");
                    _logger.Error($"Test Failed=>{_myTestContext.Test.Name}");
                    _currentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    _currentTestCase.Fail("Fail");
                    break;
                case TestStatus.Inconclusive:
                    _currentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    _currentTestCase.Warning("Inconclusive");
                    break;
                case TestStatus.Skipped:
                    _currentTestCase.Skip("Test skipped");
                    break;
                default:
                    Console.WriteLine("Reporter.ReportTestOutcome: Passed");
                    _currentTestCase.Pass($"Test Passed");
                    break;
            }
            
            _reportManager.Flush();
        }

        public static void LogTestStepForBugLogger(Status status, string message)
        {
            _logger.Info(message);
            _currentTestCase.Log(status, message);
        }
    }
}

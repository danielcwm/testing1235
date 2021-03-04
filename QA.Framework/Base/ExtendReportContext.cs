using AventStack.ExtentReports.Reporter;
using QA.Framework.Helper;

namespace QA.Framework.Base
{
    public class ExtendReportContext
    {
        public static AventStack.ExtentReports.ExtentReports ExtendReport { get; set; }
        static ExtendReportContext()
        {
            ExtendReport = new AventStack.ExtentReports.ExtentReports();
            var path = PathHelper.GetCurrentPath(Settings.ExtendReportPath);
            var htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            ExtendReport.AttachReporter(htmlReporter);
        }
    }
}

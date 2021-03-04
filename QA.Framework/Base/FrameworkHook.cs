using BoDi;
using QA.Framework.Config;
using QA.Framework.Helper;
using QA.Framework.Helper.Excel;

namespace QA.Framework.Base
{
    public class FrameworkHook
    {
        public void InitialSetup(IObjectContainer objectContainer)
        {
            _ = new WebDriverContext(objectContainer);
            _ = new InitConfig();
            _ = new ExtendReportContext();
            // init excel and read the data
            ExcelHelper.PopulateDataIntoMemory(PathHelper.GetCurrentPath("TestData\\talent.xlsx"),
                "credentials");
        }
    }
}

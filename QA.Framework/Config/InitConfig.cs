using Newtonsoft.Json;
using QA.Framework.Base;
using QA.Framework.Helper;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace QA.Framework.Config
{
    public class InitConfig
    {
        public InitConfig()
        {
        
            // init the framework setting, such as base url, extend report path

            using (StreamReader stream = new StreamReader(PathHelper.GetCurrentPath(@"Config\config.json")))
            {
                var json = stream.ReadToEnd();
                JsonConvert.DeserializeObject<Settings>(json);
            }
        }

    }
}

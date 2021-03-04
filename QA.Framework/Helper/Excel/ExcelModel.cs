using System;
using System.Collections.Generic;
using System.Text;

namespace QA.Framework.Helper.Excel
{
    public class ExcelModel
    {
        public List<DataSetModel> DataSet { get; set; }
        public string Key { get; set; }
    }
    public class DataSetModel
    {
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
    }

}

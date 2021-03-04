using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace QA.Framework.Helper.Excel
{
   public class ExcelHelper
    {
        private static readonly List<ExcelModel> _ExcelMemoryData = new List<ExcelModel>();


        public static void PopulateDataIntoMemory(string path, string sheetName)
        {
            DataTable dataFromExcel = ExcelToDataTable(path, sheetName);
            for (int row = 1; row <= dataFromExcel.Rows.Count; row++)
            {
                var excelModel = new ExcelModel()
                {
                    Key = dataFromExcel.Rows[row - 1]["key"].ToString(),
                    DataSet = new List<DataSetModel>()
                };

                for (int col = 0; col < dataFromExcel.Columns.Count; col++)
                {
                    var dataSet = new DataSetModel
                    {
                        ColumnName = dataFromExcel.Columns[col].ToString(),
                        ColumnValue = dataFromExcel.Rows[row - 1][col].ToString()
                    };
                    excelModel.DataSet.Add(dataSet);
                }
                _ExcelMemoryData.Add(excelModel);
            }
        }
        public static ExcelModel GetDataSet(string value)
        {
            try
            {
                // using linq 
                return _ExcelMemoryData.Where(x => x.Key == value).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error during reading data from excel: {0}", e);
                return null;
            }
        }
        public static string ReadDataByKey(string key, string value)
        {
            try
            {
                // using linq 
                return _ExcelMemoryData.Where(x => x.Key == key).FirstOrDefault().DataSet.Where(x => x.ColumnName == value).FirstOrDefault().ColumnValue;
                // return _ExcelMemoryData.Where(x => x.Key == value).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error during reading data from excel: {0}", e);
                return null;
            }
        }
        // returning DataTable
        // 1. excel data reader 
        // 2. system IO 
        // 3. excel data reader. data set
        private static DataTable ExcelToDataTable(string fileName, string sheetName)
        {
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {

                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable resultTable = result.Tables[sheetName];

                    return resultTable;
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}

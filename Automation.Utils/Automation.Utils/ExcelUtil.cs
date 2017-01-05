using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Excel;
using Automation.Base;

namespace Automation.Utils
{
    public class ExcelUtil
    {
        public static List<DataCollection> _dataCollection = new List<DataCollection>();
        public static DataTable ExcelToDataTable(string fileName)
        {
            //Open File and read all content of file as stream.
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            //CreateOpenXmlReader via ExcelReaderFactory
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //Set the First Row as Column Name
            excelReader.IsFirstRowAsColumnNames = true;

            //Prepare Data Set object
            DataSet result = excelReader.AsDataSet();

            //Get All The Tables
            DataTableCollection collection = result.Tables;

            //Store all collection values in DataTable
            DataTable resultTable = collection["Sheet1"];

            //Return Table
            return resultTable;

        }

        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            //Iterate through the rows and columns of the Table.
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    DataCollection item = new DataCollection()
                    {
                        RowNumber = row,
                        ColumnName = table.Columns[col].ColumnName,
                        ColumnValue = table.Rows[row - 1][col].ToString()
                    };

                    //Add all the detail for each row
                    _dataCollection.Add(item);
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving data using LINQ to reduce avoid iterations.
                string data = (from colData in _dataCollection
                               where colData.ColumnName == columnName && colData.RowNumber == rowNumber
                               select colData.ColumnValue).SingleOrDefault();

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

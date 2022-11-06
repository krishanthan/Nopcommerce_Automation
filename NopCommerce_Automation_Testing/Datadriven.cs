using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Excel;

namespace NopCommerce_Automation_Testing
{
    public class Datadriven
    {
        public DataTable ExcelToDataTable(string filename)
        {
            //open file and read as stream
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelreader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //set 1st row as a column name
            excelreader.IsFirstRowAsColumnNames = true;
            //return as dataset
            DataSet result = excelreader.AsDataSet();
            //Get all the tables
            DataTableCollection table = result.Tables;
            //Store it in DataTable
            DataTable resultTable = table["Sheet1"];
            return resultTable;
        }

        List<Datacollection> datacol = new List<Datacollection>();

        public void populateInCollection(string filename)
        { 
            DataTable table = ExcelToDataTable(filename);
            //Iterate through the rows and columns of the Table
            for (int row=1; row <= table.Rows.Count; row++)
            {
                for (int col=0; col<= table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row-1][col].ToString()
                    };
                    //Add all the details of each row
                    datacol.Add(dtTable);
                }
            }
        }

        public string ReadData(int rowNumber, string columName)
        {
            try
            {
                //Retriving data using LINQ to reduce iteration
               /* string data = (from colData in datacol
                               where colData.colName == columName && colData.rowNumber == rowNumber
                               select colData. colValue).SingleOrDefault();*/

                var datas = datacol.Where(x => x.colName == columName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return datas.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }

        }

    }
}

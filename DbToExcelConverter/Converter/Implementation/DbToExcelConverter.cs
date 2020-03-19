using DbToExcelConverter.Converter.Interface;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;


namespace DbToExcelConverter.Converter.Implementation
{
    //Takes IntervalData model and creates excel file out of it
    public class DbToExcelConverter<T> : IConverter<T>
    {      
        private readonly string rootFolder;
        private string fileName;
        public DbToExcelConverter(IConfiguration configuration)
        {     
            //To get file path and name from config
            rootFolder = $"{configuration["Location:FilePath"]}";
            fileName = $"{configuration["Location:FileName"]}";
        }
        public string Convert<IntervalDataViewModel>(List<IntervalDataViewModel> intervalDataViewModel)
        {            
            var file = new FileInfo(Path.Combine(rootFolder, DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileName));
            
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Hourly");
                worksheet.Cells[1, 4].Merge = true;
                worksheet.Cells[1, 4].Value = "Exported data";
                worksheet.Row(1).Style.Font.Bold = true;

                worksheet.Cells[2, 1].Value = "Delivery Point";
                worksheet.Cells[2, 2].Value = "Date";               
                worksheet.Cells[2, 3].Value = "Time Slot";
                worksheet.Cells[2, 4].Value = "Slot Value";
                worksheet.Row(2).Style.Font.Bold = true;
                
                int rowCount = intervalDataViewModel.Count;
                int i = 0;
                for (int row = 3; row <= rowCount + 2; row++)
                {
                    worksheet.Cells[row, 1].Value =  intervalDataViewModel[i].GetType().GetProperty("DeliveryPoint").GetValue(intervalDataViewModel[i]).ToString(); 
                    worksheet.Cells[row, 2].Value =  intervalDataViewModel[i].GetType().GetProperty("Date").GetValue(intervalDataViewModel[i]).ToString(); 
                    worksheet.Cells[row, 3].Value = intervalDataViewModel[i].GetType().GetProperty("TimeSlot").GetValue(intervalDataViewModel[i]);
                    worksheet.Cells[row, 4].Value = intervalDataViewModel[i].GetType().GetProperty("SlotVal").GetValue(intervalDataViewModel[i]);
                    i++;
                }

                 package.Save();
            }

            return file.ToString();
        }

        
    }
}

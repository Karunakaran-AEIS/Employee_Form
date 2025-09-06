using System;
using System.IO;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Employee_Form.HelperClass
{
    public class ExcelHelp
    {
        private Excel.Application excelApp;
        private Excel.Workbook workbook;
        private Excel.Worksheet worksheet;
        public string Name, AgeDob,Age,DOB, PerAdd, PreNO, AltNo, Fathername, Bloodgroup, EmailID, LocDet, EmrPhone,LocName,LocPhone, LocAdd, NomDetial,NomName,NomDob,NomRel,NomPhone,NomAddress;
        public bool IsFileExist;
        public void OpenExcel(string filePath)
        {
            excelApp = new Excel.Application();
            try
            {
                IsFileExist=false;
                if (!File.Exists(filePath))
                {
                    workbook = excelApp.Workbooks.Add();
                    workbook.SaveAs(filePath);
                    IsFileExist = false;
                }
                else
                {
                    IsFileExist = true;
                    workbook = excelApp.Workbooks.Open(filePath, ReadOnly: false);
                }
                worksheet = workbook.Sheets[1];
            }
            catch (Exception e) { 
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void WriteHeader()
        {
            Excel.Range rangeToMerge = worksheet.Range["A1:C1"];
            rangeToMerge.Merge();
            
            rangeToMerge.WrapText = true;
            rangeToMerge.Value = "Ataritech Effective Industrial Solutions (OPC) Pvt Ltd\n49/1 8 th Cross Venkatapura Koramangala Bangalore, Karnataka, 560034, India " +
                                 "\nWorks: No.20, Shantipura main road, Electronic city phase 2, Bangalore, KA, 560100";

            rangeToMerge.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rangeToMerge.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            string valueToBold = "Ataritech Effective Industrial Solutions (OPC) Pvt Ltd";
            string cellText = rangeToMerge.Cells[1, 1].Value.ToString();
            int startIndex = cellText.IndexOf(valueToBold);

            if (startIndex >= 0)
            {
                rangeToMerge.Characters[startIndex + 1, valueToBold.Length].Font.Bold = true;
            }

            rangeToMerge.Columns.AutoFit();
            rangeToMerge.Rows.AutoFit();

            for (int i = 2; i <= 13; i++)
            {
                worksheet.Cells[i, 1] = i - 1;
            }

                worksheet.Cells[2, 2] = "Name";
                worksheet.Cells[3, 2] = "Age & DOB";
                worksheet.Cells[4, 2] = "Permanent Address";
                worksheet.Cells[5, 2] = "Personal No";
                worksheet.Cells[6, 2] = "Alternate No";
                worksheet.Cells[7, 2] = "Father Name";
                worksheet.Cells[8, 2] = "Blood Group";
                worksheet.Cells[9,  2] = "Email Id";
                worksheet.Cells[10, 2] = "Local Contact Person Name & number";
                worksheet.Cells[11, 2] = "Emergency Contact No ";
                worksheet.Cells[12, 2] = "Local Address";
                worksheet.Cells[13, 2] = "Nominee Details\nName\nDate Of Birth\nRelation\nPhone Number: Address\n*(For insurance purpose)\n";
            
            workbook.Save();
            
        }

        public void InsertData(string Name, string AgeDob,string PerAdd, string PreNO,string AltNo, string Fathername, string Bloodgroup,string EmailID, string LocDet, string EmrPhone,string LocAdd, string NomDetial)
        {
            

            worksheet.Cells[2, 3] = Name;
            worksheet.Cells[3, 3] = AgeDob;
            worksheet.Cells[4, 3] = PerAdd;
            worksheet.Cells[5, 3] = PreNO;
            worksheet.Cells[6, 3] = AltNo;
            worksheet.Cells[7, 3] = Fathername;
            worksheet.Cells[8, 3] = Bloodgroup;
            worksheet.Cells[9, 3] = EmailID;
            worksheet.Cells[10, 3] = LocDet;
            worksheet.Cells[11, 3] = EmrPhone;
            worksheet.Cells[12,3] = LocAdd; 
            worksheet.Cells[13,3]= NomDetial;
            

            workbook.Save();
        }

        public void GetData()
        {
            
             Name = ReadCellValue(2, 3);
             AgeDob = ReadCellValue(3, 3);
             string[] AgDob = AgeDob.Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries);

             Age = AgDob.Length > 0 ? AgDob[0] : string.Empty;
             DOB =AgDob.Length > 1 ? AgDob[1] : string.Empty;


             PerAdd = ReadCellValue(4, 3);
             PreNO = ReadCellValue(5, 3);
             AltNo = ReadCellValue(6, 3);
             Fathername = ReadCellValue(7, 3);
             Bloodgroup = ReadCellValue(8, 3);
             EmailID = ReadCellValue(9, 3);
             LocDet = ReadCellValue(10, 3);

            string[] LDet = LocDet.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            LocName = LDet.Length > 0 ? LDet[0] : string.Empty;
            LocPhone = LDet.Length > 1 ? LDet[1] : string.Empty;

            EmrPhone = ReadCellValue(11, 3);
             LocAdd = ReadCellValue(12, 3);
             NomDetial = ReadCellValue(13, 3);
            string[] NDet = NomDetial.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            NomName = NDet.Length >0? NDet[0] : string.Empty;
            NomDob = NDet.Length > 1 ? NDet[1] : string.Empty;
            NomRel = NDet.Length > 2 ? NDet[2] : string.Empty;
            NomPhone = NDet.Length > 3 ? NDet[3] : string.Empty;
            NomAddress = NDet.Length > 4 ? NDet[4] : string.Empty;

        }


        public string ReadCellValue(int row, int column)
        {
            if (worksheet == null)
                throw new Exception("Excel file is not open. Call OpenExcel() first.");

            Excel.Range cell = worksheet.Cells[row, column];
            return cell?.Value?.ToString() ?? string.Empty;
        }

        public void Footer()
        {
            Excel.Range rtm = worksheet.Range["A14:C14"];
            rtm.Merge();
            rtm.WrapText = true;
            rtm.Value = "Declaration: I,______________________, hereby declare that the details furnished above are true and " +
                      "\ncorrect to the best of my knowledge and belief and I undertake to inform you of any changes therein, " +
                      "\nimmediately.";
            worksheet.Cells[15, 3] = "Signature :";
            worksheet.Cells[16, 3] = "Place :";
            worksheet.Cells[17, 3] = "Date :";
            workbook.Save();
        }

        public void SaveAndClose(string filePath)
        {
            try
            {
                Excel.Range usedRange = worksheet.UsedRange;
                usedRange.Columns.AutoFit();
                usedRange.Rows.AutoFit();
                workbook?.Save();
                workbook?.Close(false);
                excelApp?.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during Excel cleanup: " + ex.Message);
            }
            finally
            {
                
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);

                worksheet = null;
                workbook = null;
                excelApp = null;


                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}

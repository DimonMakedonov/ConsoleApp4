using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastReport;
using FastReport.Export.Pdf;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Report report = new Report();

            report.Load(@"C:\Users\Dima\Desktop\FR\frx\1.frx");

            //report.SetParameterValue();

            report.Prepare();

            PDFExport export = new PDFExport();

            report.Export(export, "result.pdf");

            report.Dispose();
        }
    }
}

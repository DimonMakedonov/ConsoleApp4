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
            // create report instance
            Report report = new Report();

            // load the existing report
            report.Load(@"C:\Users\Dima\Desktop\FR\frx\1.frx");

            // run the report
            report.Prepare();

            // create export instance
            FastReport.Export.Pdf.PDFExport export = new PDFExport();

            // export the report
            report.Export(export, "result.pdf");

            // free resources used by report
            report.Dispose();
        }
    }
}

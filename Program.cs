using System;
using System.Text;
using System.IO;

namespace PdfToText
{
    /// <summary>
    /// The main entry point to the program.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 1)
                {
                    DisplayUsage();
                    return;
                }

                //string file = args[0];

                var file = Environment.CurrentDirectory + "\\sample.pdf";  //it gets the pdf file from the debug folder

                if (!File.Exists(file))
                {
                    file = Path.GetFullPath(file);
                    if (!File.Exists(file))
                    {
                        Console.WriteLine("Please give in the path to the PDF file.");
                        Console.ReadLine();
                    }
                }

                PDFParser pdfParser = new PDFParser();
                pdfParser.ExtractText(file, Path.GetFileNameWithoutExtension(file)+".txt"); //corresponding text file is saved at ~PDFToText_src\PdfToText\bin\Debug
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

        static void DisplayUsage()
        {
            Console.WriteLine();
            Console.WriteLine("Usage:\tpdftotext FILE");
            Console.WriteLine();
            Console.WriteLine("\tFILE\t the path to the PDF file, it may be relative or absolute.");
            Console.WriteLine();
        }
    }
}

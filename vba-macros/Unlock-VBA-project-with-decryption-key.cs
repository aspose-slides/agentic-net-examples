using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input file path
            string inputFileName = "protected.pptm";
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);

            // Define password for VBA project
            string vbaPassword = "myVbaPassword";

            // Check if input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Input file does not exist: " + inputFilePath);
                return;
            }

            try
            {
                // Load presentation with password using LoadOptions
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.Password = vbaPassword;
                Presentation presentation = new Presentation(inputFilePath, loadOptions);

                // Check if VBA project is password protected
                if (presentation.VbaProject.IsPasswordProtected)
                {
                    Console.WriteLine("VBA project is password protected.");
                }
                else
                {
                    Console.WriteLine("VBA project is not password protected.");
                }

                // Save presentation without reapplying any password (removes VBA protection)
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                string outputFilePath = Path.Combine(outputDir, "unprotected.pptm");
                presentation.Save(outputFilePath, SaveFormat.Pptm);
                presentation.Dispose();

                Console.WriteLine("Presentation saved without VBA password: " + outputFilePath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
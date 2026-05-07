using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OdpToPdfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.odp");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Verify that the input ODP file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the ODP presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Save all slides to PDF using default settings
                    pres.Save(outputPath, SaveFormat.Pdf);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
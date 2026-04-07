using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input file path as first argument
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the path to a PPT file.");
                return;
            }

            string inputPath = args[0];

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Convert to TIFF
            string tiffPath = Path.ChangeExtension(inputPath, ".tiff");
            try
            {
                presentation.Save(tiffPath, SaveFormat.Tiff);
                Console.WriteLine("TIFF saved to: " + tiffPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save TIFF: " + ex.Message);
            }

            // Attempt to convert to DOCX (unsupported format)
            string docxPath = Path.ChangeExtension(inputPath, ".docx");
            try
            {
                // Aspose.Slides does not support DOCX; using an invalid enum value to trigger exception
                SaveFormat docxFormat = (SaveFormat)999;
                presentation.Save(docxPath, docxFormat);
                Console.WriteLine("DOCX saved to: " + docxPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("DOCX format is not supported by Aspose.Slides.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error while saving DOCX: " + ex.Message);
            }

            // Save presentation before exit (already saved in previous steps)
            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}
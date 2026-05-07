using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input and output paths
            string inputPath;
            string outputPath;
            if (args.Length >= 2)
            {
                inputPath = args[0];
                outputPath = args[1];
            }
            else
            {
                inputPath = "sample.pptx";
                outputPath = Path.ChangeExtension(inputPath, ".pdf");
            }

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Embed the source filename as a document property (Title)
                    IDocumentProperties documentProperties = presentation.DocumentProperties;
                    documentProperties.Title = Path.GetFileName(inputPath);

                    // Save the presentation as PDF
                    presentation.Save(outputPath, SaveFormat.Pdf);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // TODO: Add handling for unsupported file formats if needed
            }
        }
    }
}
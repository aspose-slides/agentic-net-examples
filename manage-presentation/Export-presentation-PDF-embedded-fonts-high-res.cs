using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPresentationToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for loading.");
                return;
            }
            catch (Exception ex)
            {
                // Other loading errors
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Configure PDF export options
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.EmbedFullFonts = true;               // Embed all fonts
            pdfOptions.SufficientResolution = 300;          // High resolution images
            pdfOptions.BestImagesCompressionRatio = true;   // Optional: best compression

            try
            {
                // Save the presentation as PDF with the specified options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
            catch (Exception ex)
            {
                // Handle any errors during saving
                Console.WriteLine("Error saving PDF: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }

            Console.WriteLine("Export completed.");
        }
    }
}
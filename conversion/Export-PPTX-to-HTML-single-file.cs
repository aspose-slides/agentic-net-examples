using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportPptxToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.html";

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
                    // Create HTML export options (single file with embedded resources)
                    HtmlOptions htmlOptions = new HtmlOptions();

                    // Save the presentation as a single HTML file
                    presentation.Save(outputPath, SaveFormat.Html, htmlOptions);
                }

                Console.WriteLine("Presentation successfully exported to HTML: " + outputPath);
            }
            // Handle unsupported file format exception
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation file format is not supported for conversion.");
            }
            // Handle any other exceptions
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
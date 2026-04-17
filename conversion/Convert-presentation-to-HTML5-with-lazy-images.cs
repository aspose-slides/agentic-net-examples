using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPresentationToHtml5
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
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Configure HTML5 export options for lazy‑loaded images
                    Aspose.Slides.Export.Html5Options html5Options = new Aspose.Slides.Export.Html5Options();
                    html5Options.EmbedImages = false; // Images will be linked, not embedded

                    // Optional: specify output folder for external resources (images, scripts, etc.)
                    // html5Options.OutputPath = "output_resources";

                    // Save the presentation as HTML5
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, html5Options);
                }
            }
            // Handle unsupported file format exception
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            // Handle any other exceptions (e.g., network errors if external resources are accessed)
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
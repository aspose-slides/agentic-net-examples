using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HtmlExportLazyLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure HTML5 export options for lazy-loaded images
                Html5Options htmlOptions = new Html5Options();
                htmlOptions.EmbedImages = false; // Images will be external, enabling lazy loading

                // Save the presentation as HTML5
                presentation.Save(outputPath, SaveFormat.Html5, htmlOptions);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle format not supported or other errors
                // Format not supported
                Console.WriteLine("Error during export: " + ex.Message);
            }
        }
    }
}
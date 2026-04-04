using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideShowPreview
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "preview.html";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Enable animation in slide show settings
                    presentation.SlideShowSettings.ShowAnimation = true;

                    // Save as HTML5 with animation options
                    Html5Options htmlOptions = new Html5Options();
                    htmlOptions.AnimateShapes = true;
                    htmlOptions.AnimateTransitions = true;

                    presentation.Save(outputPath, SaveFormat.Html5, htmlOptions);
                }

                Console.WriteLine("HTML preview generated successfully: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported for HTML5 export.
            }
        }
    }
}
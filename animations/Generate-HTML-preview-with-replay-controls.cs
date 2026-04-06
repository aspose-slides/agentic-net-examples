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
                    // Optional: configure slide show settings to show animations
                    presentation.SlideShowSettings.ShowAnimation = true;

                    // Save the presentation as an HTML5 file with animation enabled
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, new Aspose.Slides.Export.Html5Options()
                    {
                        AnimateShapes = true,
                        AnimateTransitions = true
                    });
                }

                Console.WriteLine("HTML5 preview generated successfully: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
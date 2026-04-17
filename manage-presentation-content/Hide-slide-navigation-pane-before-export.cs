using System;
using System.IO;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Hide the slide navigation pane by setting kiosk mode
                    presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.BrowsedAtKiosk();

                    // Export the presentation to PDF
                    presentation.Save(outputPath, SaveFormat.Pdf);
                }
            }
            // Handle unsupported file format exceptions
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                Console.WriteLine("The file format is not supported.");
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
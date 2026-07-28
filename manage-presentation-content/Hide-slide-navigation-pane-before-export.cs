// -----------------------------------------------------------------------------
// Example: Hide slide navigation pane before export using C#
//
// Description:
// Demonstrates how to hide the slide navigation pane by enabling kiosk mode 
// before exporting a PowerPoint presentation to PDF using Aspose.Slides for .NET. 
// The example loads a PPTX file, sets the presentation to kiosk mode to suppress 
// the slide navigation pane, and saves the result as a PDF document. This pattern 
// is useful for preparing presentation assets for distribution where navigation 
// controls should be hidden.
//
// Keywords:
// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, Hide, Slide, Navigation, Pane, 
// Kiosk Mode, Presentation Processing, Office Automation, Export
//
// Use Cases:
// - Automate hiding slide navigation pane before exporting presentations.
// - Create C# tools for preparing PDF versions of PowerPoint files without UI elements.
// - Integrate presentation processing into .NET applications with controlled export settings.
// - Ensure consistent presentation output for publishing or sharing.
// -----------------------------------------------------------------------------

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

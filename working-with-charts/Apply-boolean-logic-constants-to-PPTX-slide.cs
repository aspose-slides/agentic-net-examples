using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyBooleanLogicToPPTX
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Predefined boolean constants controlling slide show behavior
                bool enableLoop = true;
                bool showAnimation = false;
                bool showMediaControls = true;
                bool useTimings = false;
                bool isKioskMode = false;

                // Apply boolean constants to SlideShowSettings
                presentation.SlideShowSettings.Loop = enableLoop;
                presentation.SlideShowSettings.ShowAnimation = showAnimation;
                presentation.SlideShowSettings.ShowMediaControls = showMediaControls;
                presentation.SlideShowSettings.UseTimings = useTimings;

                // Set the slide show type based on the kiosk mode flag
                if (isKioskMode)
                {
                    presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.BrowsedAtKiosk();
                }
                else
                {
                    presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved successfully to " + outputPath);
        }
    }
}
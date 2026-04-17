using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace ValidateSmartArtHidden
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation and external theme files
            string inputPath = "input.pptx";
            string themePath = "theme.thmx";
            string outputPath = "output.pptx";

            // Verify that the input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            if (!File.Exists(themePath))
            {
                Console.WriteLine("Theme file not found: " + themePath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a SmartArt diagram to the slide
                ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

                // Set the Hidden property to true (expected visibility)
                smartArt.Hidden = true;

                // Apply the external theme to the first master slide
                IMasterSlide newMaster = pres.Masters[0].ApplyExternalThemeToDependingSlides(themePath);

                // Validate that the Hidden property remains as expected after applying the theme
                bool isHidden = smartArt.Hidden;
                if (isHidden)
                {
                    Console.WriteLine("SmartArt hidden property is correctly set to true after applying the theme.");
                }
                else
                {
                    Console.WriteLine("SmartArt hidden property does not match the expected value after applying the theme.");
                }

                // Save the presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (PptxReadException ex)
            {
                // Handle errors related to reading the presentation or theme files
                Console.WriteLine("Error reading PPTX or theme file: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., unsupported format)
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
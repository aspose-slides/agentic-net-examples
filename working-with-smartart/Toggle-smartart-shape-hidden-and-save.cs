using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ToggleSmartArtHidden
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // format not supported
                return;
            }

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Find the first SmartArt shape and toggle its Hidden property
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                    smartArt.Hidden = !smartArt.Hidden;
                    break; // Assuming only one SmartArt needs to be toggled
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}
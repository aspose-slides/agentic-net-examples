using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtLayoutDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "SmartArtLayoutChanged.pptx";

            // Ensure the output directory exists
            string outputDirectory = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDirectory) && !Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram with an initial layout
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                    0f, 0f, 400f, 400f,
                    Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                // Change the layout to BasicProcess
                smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicProcess;

                // Verify the layout change
                if (smartArt.Layout == Aspose.Slides.SmartArt.SmartArtLayoutType.BasicProcess)
                {
                    Console.WriteLine("Layout successfully changed to BasicProcess.");
                }
                else
                {
                    Console.WriteLine("Failed to change layout.");
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                // Format not supported.
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
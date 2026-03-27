using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ZoomFrameDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file not found: " + inputFile);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFile);

            // Get the first slide (where zoom frames will be placed)
            Aspose.Slides.ISlide firstSlide = pres.Slides[0];

            // Add a zoom frame for each subsequent slide
            for (int i = 1; i < pres.Slides.Count; i++)
            {
                // Position and size for the zoom frame
                float x = 20f + (i - 1) * 120f;
                float y = 20f;
                float width = 100f;
                float height = 100f;

                // Create the zoom frame linking to the target slide
                Aspose.Slides.IZoomFrame zoomFrame = firstSlide.Shapes.AddZoomFrame(x, y, width, height, pres.Slides[i]);

                // Ensure the zoom returns to the parent slide after navigation
                zoomFrame.ReturnToParent = true;
            }

            // Save the modified presentation
            pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
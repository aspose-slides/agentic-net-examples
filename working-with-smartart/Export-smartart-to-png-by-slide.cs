using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSmartArtToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is a SmartArt diagram
                        if (shape is Aspose.Slides.SmartArt.SmartArt smartArt)
                        {
                            // Render the SmartArt to an image
                            IImage smartArtImage = smartArt.GetImage();

                            // Build output file name using slide index (1‑based)
                            string outputFileName = $"SmartArt_Slide_{slideIndex + 1}.png";

                            // Save the image as PNG
                            smartArtImage.Save(outputFileName, Aspose.Slides.ImageFormat.Png);
                        }
                    }
                }

                // Save the presentation (optional, but required by the rules)
                string outputPresentationPath = "output.pptx";
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
        }
    }
}
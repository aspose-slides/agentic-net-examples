using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RenderSmartArtToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";

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
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is a SmartArt diagram
                            if (shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
                            {
                                // Render the SmartArt to a PNG image
                                using (Aspose.Slides.IImage smartArtImage = smartArt.GetImage())
                                {
                                    string outputFileName = $"SmartArt_Slide_{slideIndex}_Shape_{shapeIndex}.png";
                                    smartArtImage.Save(outputFileName, Aspose.Slides.ImageFormat.Png);
                                }
                            }
                        }
                    }

                    // Save the presentation (required by lifecycle rules)
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
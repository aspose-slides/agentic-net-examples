using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RenderSmartArt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(sourcePath))
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
                            if (shape is Aspose.Slides.SmartArt.SmartArt)
                            {
                                // Render the SmartArt shape to an image
                                using (IImage smartArtImage = shape.GetImage())
                                {
                                    // Build output file name using slide index and shape index
                                    string outputFile = $"smartart_slide_{slideIndex}_shape_{shapeIndex}.png";

                                    // Save the image as PNG
                                    smartArtImage.Save(outputFile, ImageFormat.Png);
                                    Console.WriteLine("Saved SmartArt image: " + outputFile);
                                }
                            }
                        }
                    }

                    // Save the (potentially unchanged) presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
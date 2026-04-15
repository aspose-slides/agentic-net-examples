using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AdjustSlideMargins
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Store original slide dimensions
                    ISlideSize originalSize = presentation.SlideSize;
                    float originalWidth = originalSize.Size.Width;
                    float originalHeight = originalSize.Size.Height;

                    // Define new slide dimensions (example: 1024x768 points)
                    float newWidth = 1024f;
                    float newHeight = 768f;

                    // Apply new slide size without scaling existing content
                    presentation.SlideSize.SetSize(newWidth, newHeight, SlideSizeScaleType.DoNotScale);

                    // Calculate scaling factors
                    float scaleX = newWidth / originalWidth;
                    float scaleY = newHeight / originalHeight;

                    // Adjust each shape on every slide proportionally
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        foreach (IShape shape in slide.Shapes)
                        {
                            shape.X *= scaleX;
                            shape.Y *= scaleY;
                            shape.Width *= scaleX;
                            shape.Height *= scaleY;
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
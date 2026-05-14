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
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Store original slide dimensions
                    ISlideSize originalSize = presentation.SlideSize;
                    float originalWidth = originalSize.Size.Width;
                    float originalHeight = originalSize.Size.Height;

                    // Define new slide dimensions (example: 1024x768 points)
                    float newWidth = 1024f;
                    float newHeight = 768f;

                    // Apply new slide size without automatic scaling
                    presentation.SlideSize.SetSize(newWidth, newHeight, SlideSizeScaleType.DoNotScale);

                    // Compute scaling factors
                    float scaleX = newWidth / originalWidth;
                    float scaleY = newHeight / originalHeight;

                    // Adjust each shape on every slide proportionally
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        for (int j = 0; j < slide.Shapes.Count; j++)
                        {
                            IShape shape = slide.Shapes[j];
                            shape.X = shape.X * scaleX;
                            shape.Y = shape.Y * scaleY;
                            shape.Width = shape.Width * scaleX;
                            shape.Height = shape.Height * scaleY;
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX files
                Console.WriteLine("The provided file format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported for PPT files
                Console.WriteLine("The provided file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
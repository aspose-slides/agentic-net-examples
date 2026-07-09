using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
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
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is an ellipse
                            IAutoShape autoShape = shape as IAutoShape;
                            if (autoShape != null && autoShape.ShapeType == ShapeType.Ellipse)
                            {
                                // Set fill to solid red
                                autoShape.FillFormat.FillType = FillType.Solid;
                                autoShape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX
                Console.WriteLine("The file format is not supported for PPTX.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported for PPT
                Console.WriteLine("The file format is not supported for PPT.");
            }
            catch (Aspose.Slides.PptxReadException)
            {
                // Error reading the presentation
                Console.WriteLine("Error reading the presentation file.");
            }
            catch (Aspose.Slides.PptReadException)
            {
                // Error reading the presentation
                Console.WriteLine("Error reading the presentation file.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
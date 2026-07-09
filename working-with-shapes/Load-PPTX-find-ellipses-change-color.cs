using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Define the target fill color to search for (e.g., Red)
                    Color targetFillColor = Color.Red;
                    // Define the new line color (e.g., Blue)
                    Color newLineColor = Color.Blue;

                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            // Cast to IAutoShape to access ShapeType
                            IAutoShape autoShape = shape as IAutoShape;
                            if (autoShape == null)
                                continue;

                            // Check if the shape is an ellipse
                            if (autoShape.ShapeType != ShapeType.Ellipse)
                                continue;

                            // Ensure the shape has a solid fill
                            if (autoShape.FillFormat == null || autoShape.FillFormat.FillType != FillType.Solid)
                                continue;

                            // Compare the fill color
                            Color shapeFillColor = autoShape.FillFormat.SolidFillColor.Color;
                            if (shapeFillColor.ToArgb() != targetFillColor.ToArgb())
                                continue;

                            // Change the line (outline) color
                            if (autoShape.LineFormat != null && autoShape.LineFormat.FillFormat != null)
                            {
                                autoShape.LineFormat.FillFormat.SolidFillColor.Color = newLineColor;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
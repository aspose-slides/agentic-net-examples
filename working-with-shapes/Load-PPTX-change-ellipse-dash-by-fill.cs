using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
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
                    // Define the target fill color to search for
                    Color targetFillColor = Color.Chocolate;

                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Process only auto shapes that are ellipses
                            if (shape is IAutoShape autoShape && autoShape.ShapeType == ShapeType.Ellipse)
                            {
                                // Ensure the shape has a solid fill
                                if (autoShape.FillFormat != null && autoShape.FillFormat.FillType == FillType.Solid)
                                {
                                    // Compare the fill color
                                    if (autoShape.FillFormat.SolidFillColor.Color.ToArgb() == targetFillColor.ToArgb())
                                    {
                                        // Change the line dash style
                                        autoShape.LineFormat.DashStyle = LineDashStyle.Dash;
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
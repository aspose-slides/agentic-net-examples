using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ReplaceRectangleSolidOrangeTitleSlide
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
                    // Assume the first slide is the title slide
                    ISlide titleSlide = presentation.Slides[0];

                    // Iterate through all shapes on the title slide
                    foreach (IShape shape in titleSlide.Shapes)
                    {
                        // Process only AutoShape rectangles
                        if (shape is IAutoShape autoShape && autoShape.ShapeType == ShapeType.Rectangle)
                        {
                            // Ensure the shape has a FillFormat
                            if (autoShape.FillFormat != null)
                            {
                                // Set fill type to solid
                                autoShape.FillFormat.FillType = FillType.Solid;
                                // Set solid fill color to orange while keeping existing line (border)
                                autoShape.FillFormat.SolidFillColor.Color = Color.Orange;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
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
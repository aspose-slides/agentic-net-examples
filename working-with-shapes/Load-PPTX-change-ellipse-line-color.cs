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
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Target fill color to search for and the new line color to apply
            Color targetFillColor = Color.Chocolate;
            Color newLineColor = Color.Black;

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
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Process only auto shapes that are ellipses
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                            {
                                // Ensure the shape has a solid fill
                                if (autoShape.FillFormat != null && autoShape.FillFormat.FillType == Aspose.Slides.FillType.Solid)
                                {
                                    // Compare the fill color with the target color
                                    if (autoShape.FillFormat.SolidFillColor.Color.ToArgb() == targetFillColor.ToArgb())
                                    {
                                        // Change the line (outline) color
                                        if (autoShape.LineFormat != null && autoShape.LineFormat.FillFormat != null)
                                        {
                                            autoShape.LineFormat.FillFormat.SolidFillColor.Color = newLineColor;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            // Handle unsupported format exceptions
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            // Handle corrupt file exception
            catch (Aspose.Slides.PptCorruptFileException)
            {
                Console.WriteLine("The presentation file appears to be corrupt.");
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
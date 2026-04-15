using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Path to the input presentation
            string inputPath = "input.pptx";

            // Verify that the file exists
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
                    // Define the target fill color (example: solid red)
                    Color targetFillColor = Color.FromArgb(255, 0, 0);

                    // Iterate through all slides
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Check if the shape is an ellipse auto shape
                            Aspose.Slides.IAutoShape ellipse = shape as Aspose.Slides.IAutoShape;
                            if (ellipse != null && ellipse.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                            {
                                // Ensure the shape has a fill format
                                Aspose.Slides.IFillFormat fillFormat = ellipse.FillFormat;
                                if (fillFormat != null && fillFormat.FillType == Aspose.Slides.FillType.Solid)
                                {
                                    // Compare the solid fill color with the target color
                                    if (fillFormat.SolidFillColor.Color.ToArgb() == targetFillColor.ToArgb())
                                    {
                                        // Ensure the shape has a line format before modifying
                                        if (ellipse.LineFormat != null)
                                        {
                                            // Change the line dash style to Dash
                                            ellipse.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
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
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
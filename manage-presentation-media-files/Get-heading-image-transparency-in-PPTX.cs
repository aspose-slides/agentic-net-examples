using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Get the Title layout slide
                ILayoutSlide titleLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Title);
                if (titleLayout == null)
                {
                    Console.WriteLine("Title layout slide not found.");
                }
                else
                {
                    // Find the first shape that has a solid fill (assumed to be the heading image)
                    IShape headingShape = null;
                    foreach (IShape shape in titleLayout.Shapes)
                    {
                        if (shape.FillFormat != null && shape.FillFormat.FillType == FillType.Solid)
                        {
                            headingShape = shape;
                            break;
                        }
                    }

                    if (headingShape == null)
                    {
                        Console.WriteLine("Heading shape with solid fill not found.");
                    }
                    else
                    {
                        // Retrieve the alpha component of the fill color (0-255)
                        Color fillColor = headingShape.FillFormat.SolidFillColor.Color;
                        int alpha = fillColor.A;

                        // Calculate transparency as a percentage (0% fully opaque, 100% fully transparent)
                        double transparencyPercent = (1.0 - (alpha / 255.0)) * 100.0;

                        Console.WriteLine($"Heading image transparency: {transparencyPercent:F2}% (Alpha = {alpha})");
                    }
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
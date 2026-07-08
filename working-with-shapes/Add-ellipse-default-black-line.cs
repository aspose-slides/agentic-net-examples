using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
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
            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate over all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                    // Iterate over all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        // Process only AutoShape objects
                        if (shape is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            // Identify ellipses
                            if (autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                            {
                                // Check if the shape has no line defined
                                if (autoShape.LineFormat.IsFormatNotDefined)
                                {
                                    // Assign a default black line
                                    autoShape.LineFormat.Width = 1.0;
                                    autoShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                    autoShape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (System.NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., web service errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
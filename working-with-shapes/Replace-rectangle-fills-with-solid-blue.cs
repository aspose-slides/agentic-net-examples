using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides and shapes
                foreach (Aspose.Slides.ISlide slide in pres.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Only AutoShape objects have a ShapeType property
                        Aspose.Slides.AutoShape autoShape = shape as Aspose.Slides.AutoShape;
                        if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Rectangle)
                        {
                            Aspose.Slides.IFillFormat fill = autoShape.FillFormat;
                            if (fill != null)
                            {
                                // Set solid fill type and apply blue color
                                fill.FillType = Aspose.Slides.FillType.Solid;
                                fill.SolidFillColor.Color = System.Drawing.Color.Blue;
                            }
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
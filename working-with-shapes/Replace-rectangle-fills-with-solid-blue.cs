using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                int slideCount = presentation.Slides.Count;
                for (int i = 0; i < slideCount; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];

                    // Iterate through all shapes on the slide
                    int shapeCount = slide.Shapes.Count;
                    for (int j = 0; j < shapeCount; j++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[j];

                        // Process only rectangle auto shapes
                        if (shape is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            if (autoShape.ShapeType == Aspose.Slides.ShapeType.Rectangle)
                            {
                                // Set solid blue fill
                                autoShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                autoShape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
                            }
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
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
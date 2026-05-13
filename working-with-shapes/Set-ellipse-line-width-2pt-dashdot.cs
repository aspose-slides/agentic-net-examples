using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Aspose.Slides.Presentation presentation = null;

        try
        {
            // Load existing presentation if it exists, otherwise create a new one
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
                // Add a sample ellipse so the code has something to modify
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
                firstSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 100);
            }

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = shapes[shapeIndex];

                    // Process only auto shapes that are ellipses
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                    {
                        // Change line width to 2 points
                        autoShape.LineFormat.Width = 2;

                        // Set dash style to DashDot
                        autoShape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
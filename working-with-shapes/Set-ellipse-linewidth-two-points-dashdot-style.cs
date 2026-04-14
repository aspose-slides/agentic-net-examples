using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Aspose.Slides.Presentation presentation = null;

        if (File.Exists(inputPath))
        {
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }
        }
        else
        {
            // Create a new presentation with a sample ellipse if input file does not exist
            presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 100);
        }

        // Iterate through all slides and shapes
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                if (autoShape != null && autoShape.ShapeType == Aspose.Slides.ShapeType.Ellipse)
                {
                    // Set line width to 2 points
                    autoShape.LineFormat.Width = 2.0;
                    // Set dash style to DashDot
                    autoShape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;
                }
            }
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
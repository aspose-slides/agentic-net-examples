using System;
using System.Drawing;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a line shape to simulate an ink stroke
                Aspose.Slides.IAutoShape lineShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line, 100, 100, 300, 0);

                // Apply a scribble sketch effect to make it look like freehand ink
                lineShape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

                // Set the line color to transparent to simulate erasing
                lineShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                lineShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Transparent;

                // Optionally set the line width
                lineShape.LineFormat.Width = 5;

                // Save the presentation
                presentation.Save("InkEraseSimulation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (NotSupportedException ex)
        {
            // format not supported
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
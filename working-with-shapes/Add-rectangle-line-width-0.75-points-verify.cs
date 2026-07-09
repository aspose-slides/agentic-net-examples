using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "output.pptx";

        try
        {
            // Create a new presentation
            using (var pres = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                var slide = pres.Slides[0];

                // Add a rectangle shape
                var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100f, 100f, 300f, 200f);

                // Set fill to solid white (optional, ensures no visual artifacts)
                shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.White;

                // Configure line format
                shape.LineFormat.Style = Aspose.Slides.LineStyle.ThickThin;
                shape.LineFormat.Width = 0.75f; // line width in points
                shape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;
                shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define output directory
            string dataDir = "Output";
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a rectangle shape
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 150, 150, 50);

                // Customize fill: solid color using a scheme color
                shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;

                // Customize line: width and solid color
                shape.LineFormat.Width = 5;
                shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Dark1;

                // Save the presentation
                pres.Save(Path.Combine(dataDir, "RectangleCustom.pptx"), Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
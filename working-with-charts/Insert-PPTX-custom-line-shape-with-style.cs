using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a line shape at position (100, 150) with a length of 300 points
                Aspose.Slides.IAutoShape lineShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line, 100, 150, 300, 0);

                // Configure line style: width and solid blue color
                Aspose.Slides.ILineFormat lineFormat = lineShape.LineFormat;
                lineFormat.Width = 5;
                lineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                lineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

                // Save the presentation
                presentation.Save("CustomLinePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
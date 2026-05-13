using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "output.pdf";
        try
        {
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];
            IAutoShape lineShape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50f, 100f, 300f, 0f);
            lineShape.LineFormat.Width = 0.5;
            presentation.Save(outputPath, SaveFormat.Pdf);
        }
        catch (Exception ex)
        {
            // Handle exceptions such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
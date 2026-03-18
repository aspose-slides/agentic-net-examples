using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangular auto shape with specified position and size
            Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100f,   // X position
                100f,   // Y position
                300f,   // Width
                200f);  // Height

            // Set solid fill color
            rectangle.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            rectangle.FillFormat.SolidFillColor.Color = Color.LightBlue;

            // Configure line format
            rectangle.LineFormat.Width = 2f;
            rectangle.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            rectangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;

            // Save the presentation
            presentation.Save("RectangleShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
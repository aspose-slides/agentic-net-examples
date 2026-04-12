using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 75, 150, 50);
            autoShape.AddTextFrame("Sample text");
            bool isTextBox = autoShape.IsTextBox;
            Console.WriteLine("Is the shape a text box? " + isTextBox);
            try
            {
                pres.Save("IsTextBoxDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception)
            {
                // Handle other exceptions
            }
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                var presentation = new Aspose.Slides.Presentation();
                var slide = presentation.Slides[0];
                var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                shape.AddTextFrame("Initial");
                var paragraph = shape.TextFrame.Paragraphs[0];
                var portion = paragraph.Portions[0];
                portion.Text = "Assigned specific string";
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
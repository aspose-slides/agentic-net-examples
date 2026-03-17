using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyPresentationApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                var presentation = new Presentation();
                var slide = presentation.Slides[0];
                slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
                presentation.Save("EditedPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
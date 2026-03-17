using System;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                using (var presentation = new Aspose.Slides.Presentation())
                {
                    var slide = presentation.Slides[0];
                    slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

                    var factory = new Aspose.Slides.Export.SaveOptionsFactory();
                    var options = factory.CreatePptxOptions();

                    presentation.Save("output.pptx", SaveFormat.Pptx, options);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
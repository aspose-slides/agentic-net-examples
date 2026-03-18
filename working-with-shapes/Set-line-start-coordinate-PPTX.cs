using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Presentation presentation = new Presentation())
                {
                    ISlide slide = presentation.Slides[0];
                    // Add a line shape with a defined starting coordinate (50,150) and length 300 points
                    IAutoShape lineShape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50f, 150f, 300f, 0f);
                    // Save the presentation
                    presentation.Save("LineStartCoordinate_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
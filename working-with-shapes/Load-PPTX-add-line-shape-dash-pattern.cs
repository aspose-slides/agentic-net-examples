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
                var inputPath = "input.pptx";
                var outputPath = "output.pptx";

                using (var presentation = new Presentation(inputPath))
                {
                    var slide = presentation.Slides[0];
                    var lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
                    lineShape.LineFormat.DashStyle = LineDashStyle.Dash;

                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
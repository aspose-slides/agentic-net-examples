using System;
using Aspose.Slides;
using Aspose.Slides.Export;

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
                // Increase X and Y coordinates of each shape on every slide
                for (var i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    var shapes = slide.Shapes;
                    for (var j = 0; j < shapes.Count; j++)
                    {
                        var shape = shapes[j];
                        shape.X = shape.X + 10;
                        shape.Y = shape.Y + 5;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
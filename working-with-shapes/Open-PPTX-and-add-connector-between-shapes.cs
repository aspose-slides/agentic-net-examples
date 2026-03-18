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

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var slide = presentation.Slides[0];

                // Add first shape (rectangle)
                var shape1 = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 100, 50);

                // Add second shape (ellipse)
                var shape2 = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 300, 200, 100, 100);

                // Add connector shape
                var connector = slide.Shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);
                connector.StartShapeConnectedTo = shape1;
                connector.EndShapeConnectedTo = shape2;
                connector.Reroute();

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
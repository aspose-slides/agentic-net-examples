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
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var slide = presentation.Slides[0];
                var groupShape = slide.Shapes.AddGroupShape();

                // Add shapes inside the group
                groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
                groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 150, 150, 100, 100);

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
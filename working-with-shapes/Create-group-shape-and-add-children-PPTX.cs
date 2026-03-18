using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var presentation = new Presentation())
            {
                var slide = presentation.Slides[0];
                var slideShapes = slide.Shapes;
                var groupShape = slideShapes.AddGroupShape();

                // Add child shapes to the group
                groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
                groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 350, 100, 100, 100);
                groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 250, 150, 80);
                groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 300, 250, 120, 80);

                // Example manipulation: rotate the group
                groupShape.Rotation = 30;

                // Save the presentation
                presentation.Save("GroupShapeExample.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
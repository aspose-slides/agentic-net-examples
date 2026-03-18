using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Presentation();

            // Get the first slide
            var slide = presentation.Slides[0];

            // Add some shapes to the slide
            var rect = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
            var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

            // Create a group shape and add shapes inside it
            var group = slide.Shapes.AddGroupShape();
            group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 100, 100);
            group.Shapes.AddAutoShape(ShapeType.Ellipse, 120, 0, 100, 100);

            // Ungroup: clone each shape from the group back to the slide, then remove the group
            foreach (var shape in group.Shapes.ToArray())
            {
                slide.Shapes.AddClone(shape);
            }
            slide.Shapes.Remove(group);

            // Save the presentation
            presentation.Save("GroupUngroup_out.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
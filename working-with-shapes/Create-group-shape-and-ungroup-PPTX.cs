using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GroupShapeExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Access the shape collection of the slide
                IShapeCollection slideShapes = slide.Shapes;

                // Add an empty group shape to the slide
                IGroupShape groupShape = slideShapes.AddGroupShape();

                // Add child shapes to the group
                groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 150, 100);
                groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 300, 100, 150, 100);
                groupShape.Shapes.AddAutoShape(ShapeType.Triangle, 100, 250, 150, 100);
                groupShape.Shapes.AddAutoShape(ShapeType.Hexagon, 300, 250, 150, 100);

                // Ungroup: clone each child shape back to the slide and remove the group
                foreach (IShape childShape in groupShape.Shapes)
                {
                    // Clone the shape to the slide's shape collection
                    slideShapes.AddClone(childShape);
                }

                // Remove the original group shape
                slideShapes.Remove(groupShape);

                // Save the presentation
                presentation.Save("GroupShape_Ungrouped.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
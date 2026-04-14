using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddGroupShapeMixedTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add an empty group shape to the slide
                IGroupShape groupShape = slide.Shapes.AddGroupShape();

                // Add a rectangle auto shape inside the group
                groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 50f, 50f, 100f, 100f);

                // Add an ellipse auto shape inside the group
                groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 200f, 50f, 100f, 100f);

                // Add a line shape inside the group
                groupShape.Shapes.AddAutoShape(ShapeType.Line, 50f, 200f, 300f, 0f);

                // Add a triangle shape inside the group
                groupShape.Shapes.AddAutoShape(ShapeType.Triangle, 150f, 150f, 100f, 100f);

                // Assign a collective alternative text description to the group
                groupShape.AlternativeText = "Group of mixed shape types";

                // Save the presentation
                try
                {
                    pres.Save("GroupShapeMixedTypes.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception)
                {
                    // Handle other possible exceptions
                }
            }
        }
    }
}
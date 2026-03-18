using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace SeparateGroupShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide (as ISlide)
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a group shape to the slide
                    Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();

                    // Add some shapes inside the group
                    groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 150, 100);
                    groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 300, 100, 150, 100);
                    groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Triangle, 200, 250, 150, 100);

                    // Separate the group shape into individual shapes
                    Aspose.Slides.IShape[] innerShapes = groupShape.Shapes.ToArray();

                    foreach (Aspose.Slides.IShape innerShape in innerShapes)
                    {
                        // Clone each inner shape back to the slide's shape collection
                        slide.Shapes.AddClone(innerShape);
                    }

                    // Remove the original group shape from the slide
                    slide.Shapes.Remove(groupShape);

                    // Save the presentation
                    presentation.Save("SeparatedShapes_out.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing PPTX presentation
                Presentation presentation = new Presentation("input.pptx");

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Get the shape collection of the slide
                IShapeCollection slideShapes = slide.Shapes;

                // Assume there is at least one shape to clone
                IShape sourceShape = slideShapes[0];

                // Create a new empty group shape on the slide
                IGroupShape groupShape = slideShapes.AddGroupShape();

                // Clone the source shape into the group shape
                IShape clonedShape = groupShape.Shapes.AddClone(sourceShape);

                // Optionally adjust the cloned shape's position within the group
                clonedShape.X = 0;
                clonedShape.Y = 0;

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
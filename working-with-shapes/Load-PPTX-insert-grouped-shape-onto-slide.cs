using System;
using System.IO;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
                {
                    // Access the target slide (e.g., first slide)
                    Aspose.Slides.ISlide targetSlide = presentation.Slides[0];

                    // Get the shape collection of the slide
                    Aspose.Slides.IShapeCollection shapeCollection = targetSlide.Shapes;

                    // Insert a new empty group shape at index 0
                    Aspose.Slides.IGroupShape groupShape = shapeCollection.InsertGroupShape(0);

                    // Add shapes inside the group shape
                    groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                    groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 300, 50, 100, 100);

                    // Save the modified presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
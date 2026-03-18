using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddShapeToGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Get the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a group shape to the slide
                    Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();

                    // Add an initial auto shape inside the group (optional)
                    Aspose.Slides.IAutoShape initialShape = groupShape.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 50, 50, 100, 100);

                    // Add an additional auto shape to the existing group shape
                    Aspose.Slides.IAutoShape additionalShape = groupShape.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Ellipse, 200, 50, 100, 100);

                    // Save the presentation
                    presentation.Save("GroupShapeWithAdditionalShape.pptx",
                        Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
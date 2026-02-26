using System;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a straight line shape to the slide
                Aspose.Slides.IAutoShape line = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line, // Shape type
                    50,   // X position
                    150,  // Y position
                    300,  // Width
                    0);   // Height (0 for a straight line)

                // Save the presentation
                presentation.Save("LinePresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
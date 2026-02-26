using System;

namespace CalloutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a callout shape to the slide
            Aspose.Slides.IAutoShape callout = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Callout1, // Callout shape type
                100, // X position (points)
                100, // Y position (points)
                300, // Width (points)
                100  // Height (points)
            );

            // Add text to the callout
            callout.AddTextFrame("This is a callout");

            // Save the presentation
            presentation.Save("CalloutPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
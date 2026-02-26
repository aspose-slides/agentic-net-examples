using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationAccessibilityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100, 100, 200, 100);

            // Set alternative text for accessibility
            shape.AlternativeText = "Rectangle shape for accessibility";

            // Set document properties (metadata)
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
            docProps.Title = "Accessible Presentation";
            docProps.Subject = "Demo of accessibility features";
            docProps.Author = "Aspose.Slides Example";

            // Save the presentation
            presentation.Save("AccessiblePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}
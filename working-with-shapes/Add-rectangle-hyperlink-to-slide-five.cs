using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "HyperlinkToSlide5.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Ensure the presentation has at least 5 slides
            while (presentation.Slides.Count < 5)
            {
                // Add empty slides using the layout of the first slide
                presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Get reference to slide five (zero‑based index)
            Aspose.Slides.ISlide targetSlide = presentation.Slides[4];

            // Add a rectangle shape on the first slide
            Aspose.Slides.IAutoShape rectangle = (Aspose.Slides.IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 50);

            // Add text to the rectangle
            rectangle.AddTextFrame("Go to Slide 5");

            // Assign an internal hyperlink that navigates to slide five
            rectangle.HyperlinkManager.SetInternalHyperlinkClick(targetSlide);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
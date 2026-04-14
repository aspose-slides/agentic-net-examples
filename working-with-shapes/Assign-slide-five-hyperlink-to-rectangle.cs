using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Ensure there are at least 5 slides
            while (presentation.Slides.Count < 5)
            {
                // Add empty slide using layout of first slide
                presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Get reference to target slide (slide index 4 = slide five)
            Aspose.Slides.ISlide targetSlide = presentation.Slides[4];

            // Add a rectangle shape on the first slide
            Aspose.Slides.IAutoShape rectangle = (Aspose.Slides.IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 50);
            rectangle.AddTextFrame("Go to Slide 5");

            // Set internal hyperlink to navigate to slide five
            Aspose.Slides.IHyperlinkManager hyperlinkManager = rectangle.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
            hyperlinkManager.SetInternalHyperlinkClick(targetSlide);

            // Save the presentation
            presentation.Save("HyperlinkToSlide5.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
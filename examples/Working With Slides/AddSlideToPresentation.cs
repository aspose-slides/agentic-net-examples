using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing PPTX file
            Presentation presentation = new Presentation("input.pptx");

            // Get a layout slide from the first master slide
            ILayoutSlide layout = presentation.Masters[0].LayoutSlides[0];

            // Add a new empty slide using the layout
            ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

            // Optionally, you can add content to the new slide here
            // e.g., newSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);

            // Save the presentation with the added slide
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}
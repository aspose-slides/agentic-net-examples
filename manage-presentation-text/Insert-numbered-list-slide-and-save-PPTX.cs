using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a new empty slide based on the layout of the first slide
                ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Add a title shape to the new slide
                IAutoShape titleShape = (IAutoShape)newSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 600, 50);
                titleShape.AddTextFrame("Why Use Numbered Lists?");

                // Save the presentation as PPTX
                presentation.Save("UpdatedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
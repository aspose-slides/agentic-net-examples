using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Define custom width and height in points
            float width = 960f;
            float height = 540f;

            // Set the slide size with no scaling of existing content
            presentation.SlideSize.SetSize(width, height, Aspose.Slides.SlideSizeScaleType.DoNotScale);

            // Save the presentation in PPTX format
            presentation.Save("CustomSizePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
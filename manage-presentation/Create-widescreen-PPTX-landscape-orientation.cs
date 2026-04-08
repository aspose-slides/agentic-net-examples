using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideSizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "WidescreenPresentation.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Set slide size to widescreen 16:9 and ensure landscape orientation
                presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.OnScreen16x9, Aspose.Slides.SlideSizeScaleType.DoNotScale);
                presentation.SlideSize.Orientation = Aspose.Slides.SlideOrientation.Landscape;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, I/O errors)
                // Comment: format not supported
            }
        }
    }
}
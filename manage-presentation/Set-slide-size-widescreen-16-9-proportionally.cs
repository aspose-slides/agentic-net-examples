using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation presentation = new Presentation())
        {
            // Set slide size to widescreen 16:9 and scale existing content proportionally
            presentation.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.EnsureFit);

            // Save the presentation
            try
            {
                presentation.Save("WidescreenPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported
            }
        }
    }
}
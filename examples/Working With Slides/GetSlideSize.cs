using System;

namespace SlideSizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation from a file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
            // Set slide size to 16:9 without scaling existing content
            presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.OnScreen16x9, Aspose.Slides.SlideSizeScaleType.DoNotScale);
            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            // Release resources
            presentation.Dispose();
        }
    }
}
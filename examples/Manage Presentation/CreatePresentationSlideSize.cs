using System;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            System.String outputPath = "CustomSlideSize.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Set custom slide size (width: 720 points, height: 540 points) and ensure content fits
            presentation.SlideSize.SetSize(720f, 540f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

            // Alternatively, set slide size to A4 paper size and maximize content scaling
            presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.A4Paper, Aspose.Slides.SlideSizeScaleType.Maximize);

            // Save the presentation in PPTX format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}
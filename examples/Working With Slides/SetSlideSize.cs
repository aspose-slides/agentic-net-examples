using System;

namespace SetSlideSizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            System.String inputPath = "input.pptx";
            System.String outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Set custom slide size (width: 780 points, height: 540 points) without scaling content
            presentation.SlideSize.SetSize(780f, 540f, Aspose.Slides.SlideSizeScaleType.DoNotScale);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
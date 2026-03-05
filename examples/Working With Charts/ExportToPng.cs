using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        System.String inputPath = "input.pptx";
        // Format string for PNG output files
        System.String outputFormat = "slide_{0}.png";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Export each slide to a PNG image
        for (int index = 0; index < pres.Slides.Count; index++)
        {
            Aspose.Slides.ISlide slide = pres.Slides[index];
            using (Aspose.Slides.IImage image = slide.GetImage())
            {
                System.String outputPath = System.String.Format(outputFormat, index);
                image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
            }
        }

        // Save the presentation before exiting (optional)
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}
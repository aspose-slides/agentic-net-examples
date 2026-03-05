using System;

namespace ConvertPptToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source PPT file
            System.String inputPath = "input.ppt";
            // Output file name pattern (slide index starts from 1)
            System.String outputPattern = "slide_{0}.png";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides and save each as PNG
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[i];
                using (Aspose.Slides.IImage image = slide.GetImage())
                {
                    System.String outputPath = System.String.Format(outputPattern, i + 1);
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }
            }

            // Save the presentation (required by authoring rules)
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}
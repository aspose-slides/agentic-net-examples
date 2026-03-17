using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source presentation
            string inputPath = "input.pptx";

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    // Get the current slide
                    ISlide slide = pres.Slides[i];

                    // Render the slide to an image with full scale
                    using (IImage image = slide.GetImage(1f, 1f))
                    {
                        // Save the image as PNG
                        string outputPath = $"slide_{i + 1}.png";
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the presentation before exiting (optional)
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
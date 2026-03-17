using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RenderPptxToImages
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation("input.pptx"))
                {
                    // Iterate through all slides
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        ISlide slide = presentation.Slides[index];
                        // Generate a full‑scale image of the slide
                        IImage image = slide.GetImage();
                        // Save the image as PNG
                        string imagePath = $"slide_{index}.png";
                        image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the presentation (required before exit)
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
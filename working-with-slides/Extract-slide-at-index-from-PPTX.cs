using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideRetriever
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            int slideIndex = 0; // zero‑based index

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    if (slideIndex < 0 || slideIndex >= presentation.Slides.Count)
                    {
                        throw new ArgumentOutOfRangeException(nameof(slideIndex), "Slide index is out of range.");
                    }

                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Example usage: display slide number
                    Console.WriteLine("Retrieved slide number: " + slide.SlideNumber);

                    // Save the presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
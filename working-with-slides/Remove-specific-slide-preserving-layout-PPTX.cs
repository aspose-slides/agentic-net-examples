using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths for input and output presentations
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Index of the slide to delete (zero‑based)
                int slideIndex = 1; // example: delete the second slide

                // Ensure the index is within range
                if (slideIndex >= 0 && slideIndex < presentation.Slides.Count)
                {
                    // Remove the specified slide
                    presentation.Slides.RemoveAt(slideIndex);
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
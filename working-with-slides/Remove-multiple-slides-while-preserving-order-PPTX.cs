using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideRemovalExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                var presentation = new Presentation("input.pptx");

                // Indices of slides to remove (zero‑based)
                var slidesToRemove = new int[] { 1, 3 };

                // Sort indices in descending order to avoid re‑indexing issues
                Array.Sort(slidesToRemove);
                Array.Reverse(slidesToRemove);

                // Remove each specified slide
                foreach (var index in slidesToRemove)
                {
                    // Ensure the index is within range
                    if (index >= 0 && index < presentation.Slides.Count)
                    {
                        var slide = presentation.Slides[index];
                        slide.Remove();
                    }
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
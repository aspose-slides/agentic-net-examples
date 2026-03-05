using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideDifferenceDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Get the total number of slides
                int slideCount = presentation.Slides.Count;

                // Compare each pair of slides
                for (int i = 0; i < slideCount; i++)
                {
                    for (int j = i + 1; j < slideCount; j++)
                    {
                        // Use BaseSlide.Equals to determine if slides are identical
                        bool areEqual = presentation.Slides[i].Equals(presentation.Slides[j]);

                        if (!areEqual)
                        {
                            Console.WriteLine(string.Format("Slide #{0} is different from Slide #{1}", i, j));
                        }
                    }
                }

                // Save the presentation (required by lifecycle rules)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
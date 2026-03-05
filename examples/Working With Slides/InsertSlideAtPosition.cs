using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddSlideAtPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";
            // Path to save the modified presentation
            string outputPath = "output.pptx";
            // Index at which the new slide will be inserted (0‑based)
            int insertIndex = 1;

            // Load the existing presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Choose a slide to clone (e.g., the first slide)
                Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];

                // Insert a clone of the chosen slide at the specified position
                presentation.Slides.InsertClone(insertIndex, sourceSlide);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
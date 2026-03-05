using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths of source presentations to be combined
        string[] sourceFiles = new string[] { "pres1.pptx", "pres2.pptx", "pres3.pptx" };

        // Create a new presentation that will hold the combined slides
        using (Aspose.Slides.Presentation targetPresentation = new Aspose.Slides.Presentation())
        {
            // Remove the initially created empty slide
            targetPresentation.Slides.RemoveAt(0);

            // Iterate through each source file
            foreach (string sourcePath in sourceFiles)
            {
                // Load the source presentation
                using (Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(sourcePath))
                {
                    // Clone each slide from the source into the target presentation
                    foreach (Aspose.Slides.ISlide sourceSlide in sourcePresentation.Slides)
                    {
                        targetPresentation.Slides.AddClone(sourceSlide);
                    }
                }
            }

            // Save the combined presentation to disk
            targetPresentation.Save("CombinedPresentation.pptx", SaveFormat.Pptx);
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation that will hold the merged slides
        Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation();

        // List of source presentation files to merge
        string[] sourceFiles = new string[] { "source1.pptx", "source2.pptx", "source3.pptx" };

        // Iterate over each source file
        foreach (string sourcePath in sourceFiles)
        {
            // Load the source presentation
            Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(sourcePath);

            // Clone each slide from the source into the destination
            foreach (Aspose.Slides.ISlide sourceSlide in sourcePresentation.Slides)
            {
                destinationPresentation.Slides.AddClone(sourceSlide);
            }

            // Release resources of the source presentation
            sourcePresentation.Dispose();
        }

        // Save the merged presentation to a PPTX file
        destinationPresentation.Save("merged_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources of the destination presentation
        destinationPresentation.Dispose();
    }
}
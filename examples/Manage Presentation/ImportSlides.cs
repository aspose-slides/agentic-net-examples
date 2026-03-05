using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        System.String sourcePath = "SourcePresentation.pptx";
        // Path to the output presentation
        System.String destPath = "MergedPresentation.pptx";

        // Load the source presentation
        Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath);
        // Create a new destination presentation
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

        // Clone all slides from the source to the destination
        for (int i = 0; i < srcPres.Slides.Count; i++)
        {
            destPres.Slides.AddClone(srcPres.Slides[i]);
        }

        // Save the merged presentation
        destPres.Save(destPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        srcPres.Dispose();
        destPres.Dispose();
    }
}
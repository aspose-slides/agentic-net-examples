using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string sourcePath1 = "Presentation1.pptx";
        string sourcePath2 = "Presentation2.pptx";
        string outputPath = "MergedPresentation.pptx";

        // Verify that input files exist
        if (!File.Exists(sourcePath1) || !File.Exists(sourcePath2))
        {
            Console.WriteLine("One or both input files do not exist.");
            return;
        }

        try
        {
            // Load source presentations
            using (Presentation sourcePres1 = new Presentation(sourcePath1))
            using (Presentation sourcePres2 = new Presentation(sourcePath2))
            // Create destination presentation
            using (Presentation destPres = new Presentation())
            {
                // Clone slides from the first source presentation
                foreach (Aspose.Slides.ISlide slide in sourcePres1.Slides)
                {
                    destPres.Slides.AddClone(slide);
                }

                // Clone slides from the second source presentation
                foreach (Aspose.Slides.ISlide slide in sourcePres2.Slides)
                {
                    destPres.Slides.AddClone(slide);
                }

                // Save the merged presentation
                destPres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
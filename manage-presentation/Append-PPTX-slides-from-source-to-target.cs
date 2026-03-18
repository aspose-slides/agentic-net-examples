using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to source, target, and output presentations
            string sourcePath = "source.pptx";
            string targetPath = "target.pptx";
            string outputPath = "merged.pptx";

            // Load source and target presentations
            using (Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(sourcePath))
            using (Aspose.Slides.Presentation targetPres = new Aspose.Slides.Presentation(targetPath))
            {
                // Append each slide from source to target
                for (int i = 0; i < sourcePres.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[i];
                    targetPres.Slides.AddClone(sourceSlide);
                }

                // Save the merged presentation
                targetPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
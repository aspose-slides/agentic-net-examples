using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var sourcePath = "source.pptx";
            var targetPath = "target.pptx";
            var outputPath = "merged.pptx";

            using (var sourcePres = new Aspose.Slides.Presentation(sourcePath))
            using (var targetPres = new Aspose.Slides.Presentation(targetPath))
            {
                // Get the first slide from the source presentation
                var sourceSlide = sourcePres.Slides[0];

                // Insert the cloned slide at the end of the target presentation
                var insertIndex = targetPres.Slides.Count;
                targetPres.Slides.InsertClone(insertIndex, sourceSlide);

                // Save the updated target presentation
                targetPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var templatePath = "template.pptx";
            var targetPath = "target.pptx";
            var outputPath = "merged.pptx";

            using (var templatePres = new Presentation(templatePath))
            using (var targetPres = new Presentation(targetPath))
            {
                // Get the first slide from the template presentation
                var sourceSlide = templatePres.Slides[0];

                // Insert a clone of the source slide at the end of the target presentation
                var insertedSlide = targetPres.Slides.InsertClone(targetPres.Slides.Count, sourceSlide);

                // Save the merged presentation
                targetPres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
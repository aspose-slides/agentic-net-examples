using System;
using Aspose.Slides;

namespace AddSlideFromTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths for the template and the target presentations
            string dataDir = @"C:\Data\";
            string templatePath = System.IO.Path.Combine(dataDir, "Template.pptx");
            string targetPath = System.IO.Path.Combine(dataDir, "Target.pptx");
            string outputPath = System.IO.Path.Combine(dataDir, "Result.pptx");

            // Load the template presentation
            Aspose.Slides.Presentation templatePres = new Aspose.Slides.Presentation(templatePath);
            // Load the target presentation
            Aspose.Slides.Presentation targetPres = new Aspose.Slides.Presentation(targetPath);

            // Clone the first slide from the template into the target presentation
            targetPres.Slides.AddClone(templatePres.Slides[0]);

            // Save the modified target presentation
            targetPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose presentations to release resources
            templatePres.Dispose();
            targetPres.Dispose();
        }
    }
}
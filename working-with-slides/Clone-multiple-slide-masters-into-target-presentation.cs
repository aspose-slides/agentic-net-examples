using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths to the source (template) and target presentations
        string templatePath = "Template.pptx";
        string targetPath = "Target.pptx";
        string outputPath = "Result.pptx";

        // Verify that the source files exist
        if (!File.Exists(templatePath))
        {
            Console.WriteLine("Template file not found: " + templatePath);
            return;
        }

        if (!File.Exists(targetPath))
        {
            Console.WriteLine("Target file not found: " + targetPath);
            return;
        }

        try
        {
            // Load the template presentation
            using (Presentation sourcePres = new Presentation(templatePath))
            {
                // Load the target presentation
                using (Presentation targetPres = new Presentation(targetPath))
                {
                    // Clone each master slide from the source into the target
                    for (int i = 0; i < sourcePres.Masters.Count; i++)
                    {
                        IMasterSlide sourceMaster = sourcePres.Masters[i];
                        // AddClone copies the master slide (including linked layouts) to the target
                        targetPres.Masters.AddClone(sourceMaster);
                    }

                    // Save the modified target presentation
                    targetPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Handle unsupported file format
            Console.WriteLine("Unsupported file format: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
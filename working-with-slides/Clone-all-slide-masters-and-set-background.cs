using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string sourcePath = "source.pptx";
        string outputPath = "template.pptx";

        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist: " + sourcePath);
            return;
        }

        try
        {
            using (Presentation srcPres = new Presentation(sourcePath))
            {
                using (Presentation destPres = new Presentation())
                {
                    // Clone each master slide from the source presentation
                    for (int i = 0; i < srcPres.Masters.Count; i++)
                    {
                        IMasterSlide sourceMaster = srcPres.Masters[i];
                        IMasterSlide clonedMaster = destPres.Masters.AddClone(sourceMaster);

                        // Apply a uniform background to the cloned master slide
                        clonedMaster.Background.Type = BackgroundType.OwnBackground;
                        clonedMaster.Background.FillFormat.FillType = FillType.Solid;
                        clonedMaster.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;
                    }

                    // Save the new presentation as a template
                    destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
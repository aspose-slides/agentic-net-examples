using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "source.pptx";
        string outputPath = "template.pptx";

        // Check if the source file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the source presentation
            using (Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(inputPath))
            {
                // Create a new destination presentation
                using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation())
                {
                    // Clone all master slides from source to destination
                    int masterCount = srcPres.Masters.Count;
                    for (int i = 0; i < masterCount; i++)
                    {
                        Aspose.Slides.IMasterSlide sourceMaster = srcPres.Masters[i];
                        Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);

                        // Apply a uniform background to the cloned master slide
                        destPres.Masters[i].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                        destPres.Masters[i].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        destPres.Masters[i].Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.ForestGreen;
                    }

                    // Save the new template presentation
                    destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
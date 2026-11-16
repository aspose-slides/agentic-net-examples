// -----------------------------------------------------------------------------
// Example: Clone All Slide Masters and Apply LightGray Background
//
// Description:
// This console application clones every slide master from a source PPTX file,
// sets a uniform LightGray background on each cloned master, and saves the
// result as a new PPTX template. It demonstrates using Aspose.Slides for .NET
// to manipulate slide masters and backgrounds in PowerPoint presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, clone slide masters, set background
//
// Use Cases:
// - Create a template PPTX with consistent master backgrounds.
// - Automate master slide customization across multiple presentations.
// - Prepare presentation assets for branding or corporate styling.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

class Program
{
    static int Main(string[] args)
    {
        string sourcePath = "source.pptx";
        string outputPath = "cloned_template.pptx";

        try
        {
            // Ensure source presentation exists; create a sample if missing
            if (!File.Exists(sourcePath))
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                // Add a sample slide to ensure there is at least one master layout
                Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                samplePres.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            // Load source presentation
            Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath);

            // Create destination presentation
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

            // Clone each master slide and set LightGray background
            for (int i = 0; i < srcPres.Masters.Count; i++)
            {
                Aspose.Slides.IMasterSlide srcMaster = srcPres.Masters[i];
                Aspose.Slides.IMasterSlide clonedMaster = destPres.Masters.AddClone(srcMaster);

                clonedMaster.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                clonedMaster.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                clonedMaster.Background.FillFormat.SolidFillColor.Color = Color.LightGray;
            }

            // Save the resulting presentation
            destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            srcPres.Dispose();
            destPres.Dispose();

            Console.WriteLine("Cloned masters saved to: " + outputPath);
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
            return 1;
        }
    }
}

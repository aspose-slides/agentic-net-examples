// -----------------------------------------------------------------------------
// Example: Clone all slide masters and set background using C#
//
// Description:
// Demonstrates how to clone all slide masters from a source presentation,
// apply a uniform LightGray background to each cloned master, and save the
// result as a new PPTX template using Aspose.Slides for .NET. The example
// shows the required presentation-processing steps for PowerPoint files and
// produces the requested output in a standalone console application. Developers
// can use this pattern to automate PPTX workflows, validate results, or
// integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Slide Masters,
// Background, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of all slide masters and setting a uniform background.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
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
                    destPres.Save(outputPath, SaveFormat.Pptx);
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

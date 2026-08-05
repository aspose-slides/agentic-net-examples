// -----------------------------------------------------------------------------
// Example: Set all slides background to light gray using C#
//
// Description:
// Demonstrates how to set all slides background to light gray using C# and 
// Aspose.Slides for .NET. The example processes an existing PPTX file if it 
// exists, applying a solid light‑gray background to every slide. If the input 
// file is missing, it creates a new presentation with a single slide and sets 
// its background to light gray. The modified or newly created presentation is 
// then saved as a PPTX file. This pattern can be used to automate background 
// styling in PowerPoint files within .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slides, Background, Light, 
// Gray, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting all slides background to light gray.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (File.Exists(inputPath))
        {
            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        // Set background color of each slide to LightGray
                        presentation.Slides[i].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                        presentation.Slides[i].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        presentation.Slides[i].Background.FillFormat.SolidFillColor.Color = Color.LightGray;
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions such as unsupported format
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        else
        {
            // Input file does not exist; create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Set background color of the first (and only) slide to LightGray
                presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                presentation.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.LightGray;

                // Save the new presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}

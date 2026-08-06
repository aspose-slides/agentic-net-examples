// -----------------------------------------------------------------------------
// Example: Assign random fill to SmartArt nodes and export slide as PNG using C#
//
// Description:
// Demonstrates how to assign random solid fill colors to all SmartArt node shapes
// in a presentation and then export the first slide as a high‑resolution PNG file
// using Aspose.Slides for .NET. The example shows loading a PPTX, modifying SmartArt,
// saving the updated presentation, and rendering a slide image.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Random Fill, PNG Export,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically apply random colors to SmartArt elements in bulk.
// - Generate visual previews of slides after SmartArt modifications.
// - Build .NET tools for PowerPoint content styling and image extraction.
// - Validate SmartArt appearance programmatically before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPresentationPath = "output.pptx";
        string outputPngPath = "slide.png";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                System.Random random = new System.Random();

                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.SmartArt.ISmartArt)
                    {
                        Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                        foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                        {
                            foreach (Aspose.Slides.SmartArt.ISmartArtShape nodeShape in node.Shapes)
                            {
                                nodeShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                int r = random.Next(256);
                                int g = random.Next(256);
                                int b = random.Next(256);
                                nodeShape.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(r, g, b);
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Export the slide as a high‑resolution PNG
                float scaleX = 2f;
                float scaleY = 2f;
                using (Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY))
                {
                    image.Save(outputPngPath, Aspose.Slides.ImageFormat.Png);
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

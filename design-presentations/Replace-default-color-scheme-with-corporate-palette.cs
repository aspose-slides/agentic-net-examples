using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            Presentation pres;
            if (File.Exists(inputPath))
            {
                pres = new Presentation(inputPath);
            }
            else
            {
                pres = new Presentation();
            }

            // Define corporate palette (example RGB values)
            Color[] corporatePalette = new Color[]
            {
                Color.FromArgb(30, 60, 90),   // Accent1
                Color.FromArgb(70, 120, 150), // Accent2
                Color.FromArgb(110, 180, 210),// Accent3
                Color.FromArgb(150, 210, 240),// Accent4
                Color.FromArgb(190, 240, 255),// Accent5
                Color.FromArgb(230, 255, 255) // Accent6
            };

            // Apply corporate colors to each slide background and first shape (if any)
            foreach (ISlide slide in pres.Slides)
            {
                // Set slide background to first corporate color
                slide.Background.Type = BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = FillType.Solid;
                slide.Background.FillFormat.SolidFillColor.Color = corporatePalette[0];

                // Apply corporate colors to shapes (example: first six shapes)
                for (int i = 0; i < Math.Min(slide.Shapes.Count, corporatePalette.Length); i++)
                {
                    IShape shape = slide.Shapes[i];
                    if (shape.FillFormat != null)
                    {
                        shape.FillFormat.FillType = FillType.Solid;
                        shape.FillFormat.SolidFillColor.Color = corporatePalette[i];
                    }
                }
            }

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., file I/O, network)
        }
    }
}
// -----------------------------------------------------------------------------
// Example: Replace connector colors with theme to PPTX using C#
//
// Description:
// Demonstrates how to replace connector line colors with the first accent color
// from the master theme in a PPTX file using C# and Aspose.Slides for .NET.
// The example loads a presentation, updates all connector shapes to use a solid
// fill with the theme accent color, and saves the modified presentation.
// This pattern can be used to automate theme‑based styling of connectors in
// PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Connector, Colors,
// Theme, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replacement of connector colors with a theme accent in PPTX files.
// - Build C# tools for PowerPoint presentation styling and processing.
// - Generate or transform PPTX files with consistent theme colors in .NET applications.
// - Validate and enforce presentation design guidelines before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Use the first accent color from the master theme
                    Color themeColor = pres.MasterTheme.ColorScheme.Accent1.Color;

                    foreach (ISlide slide in pres.Slides)
                    {
                        for (int i = 0; i < slide.Shapes.Count; i++)
                        {
                            IShape shape = slide.Shapes[i];
                            // Identify connector shapes
                            if (shape is Aspose.Slides.Connector)
                            {
                                shape.LineFormat.FillFormat.FillType = FillType.Solid;
                                shape.LineFormat.FillFormat.SolidFillColor.Color = themeColor;
                            }
                        }
                    }

                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

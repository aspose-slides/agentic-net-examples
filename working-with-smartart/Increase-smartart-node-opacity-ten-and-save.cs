using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            try
            {
                // Load the presentation
                var pres = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides
                for (var i = 0; i < pres.Slides.Count; i++)
                {
                    var slide = pres.Slides[i];

                    // Iterate through all shapes on the slide
                    foreach (var shape in slide.Shapes)
                    {
                        // Process only SmartArt shapes
                        if (shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
                        {
                            // Iterate over all SmartArt nodes
                            foreach (var node in smartArt.AllNodes)
                            {
                                var fill = node.BulletFillFormat;
                                if (fill != null && fill.FillType == Aspose.Slides.FillType.Solid)
                                {
                                    // Increase opacity by 10%
                                    var color = fill.SolidFillColor.Color;
                                    var newAlpha = Math.Min(255, color.A + (int)(255 * 0.1));
                                    var newColor = Color.FromArgb(newAlpha, color.R, color.G, color.B);
                                    fill.SolidFillColor.Color = newColor;
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;
using System.Drawing;

namespace IncreaseSmartArtOpacity
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex] as IShape;

                            // Process only SmartArt shapes
                            ISmartArt smartArt = shape as ISmartArt;
                            if (smartArt == null)
                                continue;

                            // Iterate through all nodes of the SmartArt
                            foreach (ISmartArtNode node in smartArt.AllNodes)
                            {
                                // Iterate through all shapes associated with the node
                                foreach (ISmartArtShape nodeShape in node.Shapes)
                                {
                                    IFillFormat fillFormat = nodeShape.FillFormat;
                                    if (fillFormat == null)
                                        continue;

                                    // Only modify solid fill types
                                    if (fillFormat.FillType == FillType.Solid)
                                    {
                                        Color currentColor = fillFormat.SolidFillColor.Color;
                                        int currentAlpha = currentColor.A;

                                        // Increase opacity by 10% of full opacity (255)
                                        int increasedAlpha = currentAlpha + (int)(0.1 * 255);
                                        if (increasedAlpha > 255)
                                            increasedAlpha = 255;

                                        // Set new color with updated alpha
                                        fillFormat.SolidFillColor.Color = Color.FromArgb(increasedAlpha, currentColor);
                                    }
                                }
                            }
                        }
                    }

                    // Save the updated presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
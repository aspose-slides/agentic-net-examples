using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;
using System.Drawing;

namespace SmartArtOpacityExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                ISlide slide = pres.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex] as IShape;

                    // Check if the shape is a SmartArt diagram
                    ISmartArt smartArt = shape as ISmartArt;
                    if (smartArt == null)
                        continue;

                    // Iterate over all nodes in the SmartArt
                    foreach (ISmartArtNode node in smartArt.AllNodes)
                    {
                        // Iterate over all shapes associated with the node
                        foreach (ISmartArtShape nodeShape in node.Shapes)
                        {
                            // Ensure the shape has a FillFormat and is using solid fill
                            if (nodeShape.FillFormat != null && nodeShape.FillFormat.FillType == FillType.Solid)
                            {
                                // Get the current solid fill color
                                Color currentColor = nodeShape.FillFormat.SolidFillColor.Color;

                                // Increase the alpha (opacity) by 10%
                                int newAlpha = (int)(currentColor.A * 1.1);
                                if (newAlpha > 255) newAlpha = 255;

                                // Apply the new color with increased opacity
                                nodeShape.FillFormat.SolidFillColor.Color = Color.FromArgb(newAlpha, currentColor);
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation object
            pres.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}
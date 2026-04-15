using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesSmartArtRandomFill
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPresentationPath = "output.pptx";
            string outputImagePath = "output.png";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Assume the first slide contains a SmartArt diagram
                    ISlide slide = presentation.Slides[0];
                    // Find the first SmartArt shape on the slide
                    ISmartArt smartArt = null;
                    foreach (IShape shape in slide.Shapes)
                    {
                        smartArt = shape as ISmartArt;
                        if (smartArt != null)
                        {
                            break;
                        }
                    }

                    if (smartArt == null)
                    {
                        Console.WriteLine("No SmartArt diagram found on the first slide.");
                    }
                    else
                    {
                        // Random number generator for colors
                        Random random = new Random();

                        // Iterate through all nodes in the SmartArt diagram
                        foreach (ISmartArtNode node in smartArt.AllNodes)
                        {
                            // Each node can contain multiple shapes; apply fill to each shape
                            foreach (IShape nodeShape in node.Shapes)
                            {
                                // Set solid fill type
                                nodeShape.FillFormat.FillType = FillType.Solid;
                                // Generate a random color
                                Color randomColor = Color.FromArgb(
                                    random.Next(256),
                                    random.Next(256),
                                    random.Next(256));
                                // Apply the random color
                                nodeShape.FillFormat.SolidFillColor.Color = randomColor;
                            }
                        }
                    }

                    // Save the modified presentation (required before exit)
                    presentation.Save(outputPresentationPath, SaveFormat.Pptx);

                    // Export the first slide as PNG
                    IImage slideImage = slide.GetImage();
                    slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested file format is not supported.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
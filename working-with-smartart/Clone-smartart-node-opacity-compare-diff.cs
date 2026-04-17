using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace CloneSmartArtOpacityDiff
{
    class Program
    {
        static void Main()
        {
            // Define file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string originalImagePath = "original.png";
            string clonedImagePath = "cloned.png";

            // Verify that the input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a SmartArt diagram to the slide (if none exists)
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                    20, 20, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                // Export the original SmartArt shape as an image
                using (Aspose.Slides.IImage originalImg = smartArt.GetImage())
                {
                    originalImg.Save(originalImagePath, Aspose.Slides.ImageFormat.Png);
                }

                // Clone the SmartArt shape using the shape collection AddClone method
                Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(smartArt);
                Aspose.Slides.SmartArt.ISmartArt clonedSmartArt = (Aspose.Slides.SmartArt.ISmartArt)clonedShape;

                // Apply a different fill opacity to the cloned SmartArt
                clonedSmartArt.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                clonedSmartArt.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
                // Reduce opacity to 50%
                clonedSmartArt.FillFormat.SolidFillColor.ColorTransform.Add(
                    Aspose.Slides.ColorTransformOperation.AddAlpha, 0.5f);

                // Export the cloned SmartArt shape as an image
                using (Aspose.Slides.IImage clonedImg = clonedSmartArt.GetImage())
                {
                    clonedImg.Save(clonedImagePath, Aspose.Slides.ImageFormat.Png);
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();

                // At this point you can use any external image‑diff tool to compare
                // "original.png" and "cloned.png" and observe the visual difference.
                Console.WriteLine("Processing completed successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported for saving
                // (Comment: format not supported)
                Console.WriteLine("The requested save format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
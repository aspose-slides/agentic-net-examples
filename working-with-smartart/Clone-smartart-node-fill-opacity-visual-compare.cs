using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string originalImagePath = "original.png";
            string clonedImagePath = "cloned.png";
            string diffImagePath = "diff.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load presentation
            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Get first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a SmartArt diagram if none exists
            Aspose.Slides.SmartArt.SmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList) as Aspose.Slides.SmartArt.SmartArt;

            // Apply fill opacity to original SmartArt (example using solid fill)
            if (smartArt != null && smartArt.FillFormat != null)
            {
                smartArt.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                // Set solid fill color (e.g., blue) with 50% opacity using ImageTransform
                if (smartArt.FillFormat.SolidFillColor != null)
                {
                    smartArt.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(128, 0, 0, 255);
                }
            }

            // Clone the SmartArt shape using AddClone and cast to SmartArt
            Aspose.Slides.SmartArt.SmartArt clonedSmartArt = slide.Shapes.AddClone(smartArt) as Aspose.Slides.SmartArt.SmartArt;

            // Apply different fill opacity to cloned SmartArt (e.g., 20% opacity)
            if (clonedSmartArt != null && clonedSmartArt.FillFormat != null)
            {
                clonedSmartArt.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                if (clonedSmartArt.FillFormat.SolidFillColor != null)
                {
                    clonedSmartArt.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(51, 255, 0, 0);
                }
            }

            // Export original slide image
            using (Aspose.Slides.IImage originalImage = slide.GetImage())
            {
                originalImage.Save(originalImagePath, Aspose.Slides.ImageFormat.Png);
            }

            // Export cloned slide image (same slide after cloning)
            using (Aspose.Slides.IImage clonedImage = slide.GetImage())
            {
                clonedImage.Save(clonedImagePath, Aspose.Slides.ImageFormat.Png);
            }

            // Compare images using external diff utility (e.g., ImageMagick)
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "magick";
                startInfo.Arguments = $"compare \"{originalImagePath}\" \"{clonedImagePath}\" \"{diffImagePath}\"";
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                Process proc = Process.Start(startInfo);
                proc.WaitForExit();
                Console.WriteLine("Image comparison completed. Diff saved to " + diffImagePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Image comparison failed: " + ex.Message);
            }

            // Save the modified presentation
            try
            {
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Comment: format not supported
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Dispose presentation
            pres.Dispose();
        }
    }
}
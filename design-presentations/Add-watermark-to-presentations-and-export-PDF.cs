using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchWatermarkPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input folder
            string inputFolder;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputFolder = args[0];
            }
            else
            {
                inputFolder = Directory.GetCurrentDirectory();
            }

            // Verify folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist.");
                return;
            }

            // Get presentation files
            string[] files = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in files)
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".pptx" && extension != ".ppt" && extension != ".odp")
                {
                    continue; // Skip non‑presentation files
                }

                if (!File.Exists(filePath))
                {
                    continue; // Safety check
                }

                try
                {
                    // Load presentation
                    Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath);

                    // Add watermark to master slide (applies to all slides)
                    Aspose.Slides.IMasterSlide master = pres.Masters[0];
                    Aspose.Slides.IAutoShape watermarkShape = master.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle,
                        0, 0, 500, 50);
                    watermarkShape.AddTextFrame("CONFIDENTIAL");
                    watermarkShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
                    watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                    watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                    // Save as PDF in the same folder
                    string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";
                    string outputPath = Path.Combine(inputFolder, outputFileName);
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);

                    // Dispose presentation
                    pres.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported – skip this file
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file '{filePath}': {ex.Message}");
                }
            }
        }
    }
}
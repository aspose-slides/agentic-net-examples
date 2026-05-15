using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchWatermark
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
                inputFolder = "InputPresentations";
            }

            // Verify folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist: " + inputFolder);
                return;
            }

            // Create output folder
            string outputFolder = Path.Combine(inputFolder, "Watermarked");
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Process each PPTX file
            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");
            foreach (string filePath in pptxFiles)
            {
                try
                {
                    // Load presentation
                    Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath);

                    // Get first master slide
                    Aspose.Slides.IMasterSlide master = pres.Masters[0];

                    // Add watermark shape to master
                    Aspose.Slides.IAutoShape watermarkShape = master.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle,
                        100,   // X position
                        100,   // Y position
                        500,   // Width
                        100    // Height
                    );

                    // Add text to the shape
                    watermarkShape.AddTextFrame("Corporate Confidential");

                    // Center the text
                    watermarkShape.TextFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                    // Make shape transparent (no fill, no line)
                    watermarkShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                    watermarkShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                    // Save the modified presentation to output folder (overwrite if exists)
                    string outputPath = Path.Combine(outputFolder, Path.GetFileName(filePath));
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                    // Dispose presentation
                    pres.Dispose();

                    Console.WriteLine("Processed: " + filePath);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("Skipping unsupported format: " + filePath);
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
                }
            }
        }
    }
}
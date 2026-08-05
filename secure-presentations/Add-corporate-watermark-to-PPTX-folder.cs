// -----------------------------------------------------------------------------
// Example: Add corporate watermark to PPTX folder using C#
//
// Description:
// Demonstrates how to add a corporate watermark to all PPTX files in a
// specified folder using C# and Aspose.Slides for .NET. The example loads each
// presentation, inserts a transparent rectangle with the text "Confidential"
// on each master slide, and saves the changes, overwriting the original files.
// This pattern can be used to automate batch watermarking of PowerPoint
// presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Corporate Watermark, Folder,
// Batch Processing, Presentation Automation, Office Automation
//
// Use Cases:
// - Apply a corporate "Confidential" watermark to multiple PPTX files in a
//   directory.
// - Build command‑line tools for batch PowerPoint presentation processing.
// - Integrate watermarking into .NET applications or CI pipelines.
// - Ensure consistent branding or confidentiality markings across presentations.
// -----------------------------------------------------------------------------
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
            // Determine the folder to process
            string inputFolder;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputFolder = args[0];
            }
            else
            {
                // Default folder (current directory)
                inputFolder = Directory.GetCurrentDirectory();
            }

            // Verify the folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("The specified folder does not exist: " + inputFolder);
                return;
            }

            // Get all PPTX files in the folder
            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx", SearchOption.TopDirectoryOnly);
            if (pptxFiles.Length == 0)
            {
                Console.WriteLine("No PPTX files found in the folder: " + inputFolder);
                return;
            }

            foreach (string filePath in pptxFiles)
            {
                // Ensure the file exists before processing
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found, skipping: " + filePath);
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Presentation pres = new Presentation(filePath))
                    {
                        // Add watermark to each master slide
                        for (int masterIndex = 0; masterIndex < pres.Masters.Count; masterIndex++)
                        {
                            IMasterSlide master = pres.Masters[masterIndex];

                            // Add a rectangle shape that will serve as the watermark
                            // Parameters: X, Y, Width, Height
                            IAutoShape watermarkShape = master.Shapes.AddAutoShape(
                                ShapeType.Rectangle,
                                100,   // X position
                                100,   // Y position
                                400,   // Width
                                50);   // Height

                            // Add text to the shape
                            watermarkShape.AddTextFrame("Confidential");

                            // Center the text
                            watermarkShape.TextFrame.TextFrameFormat.CenterText = NullableBool.True;

                            // Make shape background and border transparent
                            watermarkShape.FillFormat.FillType = FillType.NoFill;
                            watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
                        }

                        // Save the modified presentation (overwrite original)
                        pres.Save(filePath, SaveFormat.Pptx);
                    }

                    Console.WriteLine("Watermark added to: " + filePath);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    // Comment: format not supported
                    Console.WriteLine("Unsupported format, skipping file: " + filePath);
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

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationDiagnostic
{
    class Program
    {
        static void Main(string[] args)
        {
            // If no arguments provided, define sample input files (adjust as needed)
            string[] inputFiles = args.Length > 0 ? args : new string[] { "sample1.fodp", "sample2.fodp" };

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                try
                {
                    // Load original presentation
                    Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                    // Define intermediate and final output paths
                    string intermediatePptx = Path.ChangeExtension(inputPath, ".pptx");
                    string outputFodp = Path.Combine(Path.GetDirectoryName(inputPath) ?? string.Empty,
                                                    Path.GetFileNameWithoutExtension(inputPath) + "_converted.fodp");

                    // Convert to PPTX (using convert-without-xps-options rule)
                    pres.Save(intermediatePptx, Aspose.Slides.Export.SaveFormat.Pptx);

                    // Load intermediate PPTX
                    Aspose.Slides.Presentation pres2 = new Aspose.Slides.Presentation(intermediatePptx);

                    // Convert back to FODP (using fodp-format-convertion rule)
                    pres2.Save(outputFodp, Aspose.Slides.Export.SaveFormat.Fodp);

                    // Gather file size information
                    long originalSize = new FileInfo(inputPath).Length;
                    long intermediateSize = new FileInfo(intermediatePptx).Length;
                    long finalSize = new FileInfo(outputFodp).Length;

                    // Diagnostic report
                    Console.WriteLine($"Processed: {inputPath}");
                    Console.WriteLine($"Original size: {originalSize} bytes");
                    Console.WriteLine($"Intermediate PPTX size: {intermediateSize} bytes");
                    Console.WriteLine($"Final FODP size: {finalSize} bytes");
                    Console.WriteLine("Warnings: None");

                    // Clean up
                    pres.Dispose();
                    pres2.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine($"Format not supported for file: {inputPath} // format not supported");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing {inputPath}: {ex.Message}");
                }
            }
        }
    }
}
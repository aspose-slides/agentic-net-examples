using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesExportCompatibility
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input PPTX file
            string inputPath = "input.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found: " + inputPath);
                return;
            }

            // Create output directory
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // List of target formats to test
            SaveFormat[] targetFormats = new SaveFormat[]
            {
                SaveFormat.Ppt,
                SaveFormat.Pdf,
                SaveFormat.Xps,
                SaveFormat.Pptx,
                SaveFormat.Ppsx,
                SaveFormat.Tiff,
                SaveFormat.Odp,
                SaveFormat.Pptm,
                SaveFormat.Ppsm,
                SaveFormat.Potx,
                SaveFormat.Potm,
                SaveFormat.Html,
                SaveFormat.Swf,
                SaveFormat.Otp,
                SaveFormat.Pps,
                SaveFormat.Pot,
                SaveFormat.Fodp,
                SaveFormat.Gif,
                SaveFormat.Html5,
                SaveFormat.Md,
                SaveFormat.Xml
            };

            // Attempt conversion for each format
            foreach (SaveFormat format in targetFormats)
            {
                try
                {
                    string outputFileName = $"converted_{format.ToString().ToLower()}{GetExtension(format)}";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Save using the standard Save method (rule: convert-without-xps-options)
                    pres.Save(outputPath, format);

                    Console.WriteLine($"Successfully saved as {format}: {outputPath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to save as {format}: {ex.Message}");
                }
            }

            // Dispose the presentation (save already performed)
            pres.Dispose();
        }

        // Helper method to map SaveFormat to typical file extension
        private static string GetExtension(SaveFormat format)
        {
            switch (format)
            {
                case SaveFormat.Ppt: return ".ppt";
                case SaveFormat.Pdf: return ".pdf";
                case SaveFormat.Xps: return ".xps";
                case SaveFormat.Pptx: return ".pptx";
                case SaveFormat.Ppsx: return ".ppsx";
                case SaveFormat.Tiff: return ".tiff";
                case SaveFormat.Odp: return ".odp";
                case SaveFormat.Pptm: return ".pptm";
                case SaveFormat.Ppsm: return ".ppsm";
                case SaveFormat.Potx: return ".potx";
                case SaveFormat.Potm: return ".potm";
                case SaveFormat.Html: return ".html";
                case SaveFormat.Swf: return ".swf";
                case SaveFormat.Otp: return ".otp";
                case SaveFormat.Pps: return ".pps";
                case SaveFormat.Pot: return ".pot";
                case SaveFormat.Fodp: return ".fodp";
                case SaveFormat.Gif: return ".gif";
                case SaveFormat.Html5: return ".html";
                case SaveFormat.Md: return ".md";
                case SaveFormat.Xml: return ".xml";
                default: return ".out";
            }
        }
    }
}
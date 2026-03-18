using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportCompatibilityCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "sample.pptx";
            string outputDir = "ExportResults";

            try
            {
                // Ensure output directory exists
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Load the PPTX presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all SaveFormat enum values
                    Array formatValues = Enum.GetValues(typeof(SaveFormat));
                    foreach (SaveFormat format in formatValues)
                    {
                        try
                        {
                            // Determine file extension for the current format
                            string extension = GetExtensionForFormat(format);
                            if (string.IsNullOrEmpty(extension))
                            {
                                // Skip formats without a direct file extension
                                continue;
                            }

                            string outputPath = Path.Combine(outputDir, $"output_{format}{extension}");
                            presentation.Save(outputPath, format);
                            Console.WriteLine($"Successfully saved as {format}: {outputPath}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to save as {format}: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing presentation: {ex.Message}");
            }
        }

        // Helper method to map SaveFormat to a suitable file extension
        private static string GetExtensionForFormat(SaveFormat format)
        {
            switch (format)
            {
                case SaveFormat.Ppt:
                    return ".ppt";
                case SaveFormat.Pptx:
                    return ".pptx";
                case SaveFormat.Pdf:
                    return ".pdf";
                case SaveFormat.Xps:
                    return ".xps";
                case SaveFormat.Ppsx:
                    return ".ppsx";
                case SaveFormat.Tiff:
                    return ".tiff";
                case SaveFormat.Odp:
                    return ".odp";
                case SaveFormat.Pptm:
                    return ".pptm";
                case SaveFormat.Ppsm:
                    return ".ppsm";
                case SaveFormat.Potx:
                    return ".potx";
                case SaveFormat.Potm:
                    return ".potm";
                case SaveFormat.Html:
                    return ".html";
                case SaveFormat.Swf:
                    return ".swf";
                case SaveFormat.Otp:
                    return ".otp";
                case SaveFormat.Pps:
                    return ".pps";
                case SaveFormat.Pot:
                    return ".pot";
                case SaveFormat.Fodp:
                    return ".fodp";
                case SaveFormat.Gif:
                    return ".gif";
                case SaveFormat.Html5:
                    return ".html";
                case SaveFormat.Md:
                    return ".md";
                case SaveFormat.Xml:
                    return ".xml";
                default:
                    return string.Empty;
            }
        }
    }
}
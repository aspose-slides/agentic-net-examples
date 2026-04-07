using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvertOdp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please provide ODP file paths as command line arguments.");
                return;
            }

            foreach (string inputPath in args)
            {
                try
                {
                    // Check if the input ODP file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Load the ODP presentation
                    using (Presentation pres = new Presentation(inputPath))
                    {
                        string directory = Path.GetDirectoryName(inputPath);
                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

                        // Create output directory for SVG files
                        string svgOutputDir = Path.Combine(directory, fileNameWithoutExt + "_svg");
                        if (!Directory.Exists(svgOutputDir))
                        {
                            Directory.CreateDirectory(svgOutputDir);
                        }

                        // Export each slide as SVG
                        for (int index = 0; index < pres.Slides.Count; index++)
                        {
                            string svgFilePath = Path.Combine(svgOutputDir, $"slide_{index}.svg");
                            using (FileStream svgStream = File.Create(svgFilePath))
                            {
                                pres.Slides[index].WriteAsSvg(svgStream);
                            }
                        }

                        // Convert the presentation to XPS format
                        string xpsOutputPath = Path.Combine(directory, fileNameWithoutExt + ".xps");
                        // Using rule: convert-without-xps-options
                        pres.Save(xpsOutputPath, SaveFormat.Xps);
                    }

                    Console.WriteLine($"Successfully processed: {inputPath}");
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine($"The format of the file is not supported for conversion: {inputPath}");
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine($"Error processing file {inputPath}: {ex.Message}");
                }
            }
        }
    }
}
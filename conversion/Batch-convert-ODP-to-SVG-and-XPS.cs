using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // List of ODP files to process
        string[] inputFiles;
        if (args.Length > 0)
        {
            inputFiles = args;
        }
        else
        {
            inputFiles = new string[] { "sample1.odp", "sample2.odp" };
        }

        foreach (string inputFile in inputFiles)
        {
            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"Input file not found: {inputFile}");
                continue;
            }

            try
            {
                using (Presentation pres = new Presentation(inputFile))
                {
                    // Create directory for SVG files
                    string baseName = Path.GetFileNameWithoutExtension(inputFile);
                    string svgDirectory = Path.Combine(Path.GetDirectoryName(inputFile) ?? "", baseName + "_svg");
                    if (!Directory.Exists(svgDirectory))
                    {
                        Directory.CreateDirectory(svgDirectory);
                    }

                    // Export each slide to SVG
                    for (int i = 0; i < pres.Slides.Count; i++)
                    {
                        string svgPath = Path.Combine(svgDirectory, $"slide_{i + 1}.svg");
                        using (FileStream svgStream = File.Create(svgPath))
                        {
                            pres.Slides[i].WriteAsSvg(svgStream);
                        }
                    }

                    // Save presentation as XPS
                    string xpsPath = Path.Combine(Path.GetDirectoryName(inputFile) ?? "", baseName + ".xps");
                    // Convert without XPS options (rule: convert-without-xps-options)
                    pres.Save(xpsPath, Aspose.Slides.Export.SaveFormat.Xps);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine($"Format not supported for file: {inputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file {inputFile}: {ex.Message}");
            }
        }
    }
}
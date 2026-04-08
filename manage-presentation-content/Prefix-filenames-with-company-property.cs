using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputDir = "InputPresentations";
        var outputDir = "ExportedPresentations";

        if (!Directory.Exists(inputDir))
        {
            Console.WriteLine($"Input directory does not exist: {inputDir}");
            return;
        }

        Directory.CreateDirectory(outputDir);

        foreach (var filePath in Directory.GetFiles(inputDir, "*.*"))
        {
            try
            {
                var ext = Path.GetExtension(filePath).ToLowerInvariant();
                if (ext != ".pptx" && ext != ".ppt" && ext != ".odp")
                {
                    // Format not supported
                    continue;
                }

                using (var presentation = new Presentation(filePath))
                {
                    var docProps = presentation.DocumentProperties;
                    var company = docProps.Company;
                    if (string.IsNullOrEmpty(company))
                    {
                        company = "NoCompany";
                    }

                    var fileName = Path.GetFileNameWithoutExtension(filePath);
                    var outFile = Path.Combine(outputDir, $"{company}_{fileName}.pptx");

                    presentation.Save(outFile, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
            }
        }
    }
}
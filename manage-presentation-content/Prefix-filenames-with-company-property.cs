// -----------------------------------------------------------------------------
// Example: Prefix filenames with company property using C#
//
// Description:
// Demonstrates how to read the Company document property from a PowerPoint
// presentation using Aspose.Slides for .NET and prefix the output file name
// with that value. The console application scans an input folder, processes
// PPTX, PPT, and ODP files, applies a default when the property is missing,
// and saves the resulting presentations as PPTX files in an output folder.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, PPT, ODP, DocumentProperties, Company,
// Filename prefix, File I/O, Presentation processing, Office automation
//
// Use Cases:
// - Batch rename PowerPoint files based on their Company metadata.
// - Create automated pipelines that reorganize presentation assets.
// - Generate consistent naming conventions for archived or published decks.
// - Integrate document‑property‑driven logic into .NET PowerPoint tools.
// -----------------------------------------------------------------------------

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

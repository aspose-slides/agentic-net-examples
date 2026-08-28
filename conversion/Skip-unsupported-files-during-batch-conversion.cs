// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Skip unsupported files during batch conversion using C#

//

// Description:

// Demonstrates how to iterate over a list of file paths, skip files that are

// not supported for conversion (e.g., non‑PowerPoint formats), handle

// unsupported PPTX/PPT formats gracefully, and convert supported presentations

// (.pptx and .odp) to PDF using Aspose.Slides for .NET. The example is a

// standalone console application suitable for automating batch conversion

// workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, ODP, PDF, Aspose.Slides for .NET, Skip, Unsupported,

// Files, Batch Conversion, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of PowerPoint and OpenDocument presentations to PDF.

// - Skip unsupported file types and formats during large‑scale conversion jobs.

// - Build command‑line tools for presentation processing in .NET applications.

// - Ensure robust handling of format exceptions in automated workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        if (args == null || args.Length == 0)

        {

            Console.WriteLine("Please provide file paths as arguments.");

            return;

        }



        foreach (string inputPath in args)

        {

            if (string.IsNullOrEmpty(inputPath))

            {

                continue;

            }



            if (!File.Exists(inputPath))

            {

                Console.WriteLine($"File not found: {inputPath}");

                continue;

            }



            string extension = Path.GetExtension(inputPath).ToLowerInvariant();

            if (extension != ".pptx" && extension != ".odp")

            {

                Console.WriteLine($"Unsupported file type: {inputPath}");

                continue;

            }



            try

            {

                using (Presentation pres = new Presentation(inputPath))

                {

                    string directory = Path.GetDirectoryName(inputPath);

                    string filenameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

                    string outputPath = Path.Combine(directory ?? string.Empty, filenameWithoutExt + ".pdf");



                    pres.Save(outputPath, SaveFormat.Pdf);

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                Console.WriteLine($"Skipped unsupported PPTX format: {inputPath}");

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                Console.WriteLine($"Skipped unsupported PPT format: {inputPath}");

            }

            catch (Exception ex)

            {

                Console.WriteLine($"Error processing {inputPath}: {ex.Message}");

            }

        }

    }

}


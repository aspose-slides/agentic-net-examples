// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch export PPT and PPTX to ODP preserving order using C#

//

// Description:

// Demonstrates how to batch export PowerPoint presentations (PPT and PPTX) to

// OpenDocument Presentation (ODP) format while preserving the order of files

// during processing. The example uses Aspose.Slides for .NET to load each

// presentation, convert it to ODP, and save it to a specified output folder.

// It includes basic argument validation, folder handling, and error handling

// suitable for console applications.

//

// Keywords:

// C#, PowerPoint, PPT, PPTX, ODP, Aspose.Slides for .NET, Batch Export, Preserve Order,

// Presentation Conversion, Console Application

//

// Use Cases:

// - Automate conversion of multiple PPT/PPTX files to ODP in a defined sequence.

// - Integrate PowerPoint to ODP conversion into .NET build or deployment pipelines.

// - Create command‑line tools for bulk presentation format migration.

// - Validate and process presentations before publishing to OpenDocument platforms.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Expect two arguments: input folder and output folder

        if (args.Length < 2)

        {

            Console.WriteLine("Usage: BatchExport <inputFolder> <outputFolder>");

            return;

        }



        string inputFolder = args[0];

        string outputFolder = args[1];



        // Verify input folder exists

        if (!Directory.Exists(inputFolder))

        {

            Console.WriteLine("Input folder does not exist: " + inputFolder);

            return;

        }



        // Ensure output folder exists

        if (!Directory.Exists(outputFolder))

        {

            Directory.CreateDirectory(outputFolder);

        }



        // Get all PPT and PPTX files in the input folder

        string[] pptFiles = Directory.GetFiles(inputFolder, "*.ppt", SearchOption.TopDirectoryOnly);

        string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx", SearchOption.TopDirectoryOnly);

        string[] allFiles = new string[pptFiles.Length + pptxFiles.Length];

        pptFiles.CopyTo(allFiles, 0);

        pptxFiles.CopyTo(allFiles, pptFiles.Length);



        foreach (string inputPath in allFiles)

        {

            try

            {

                // Verify the file exists before loading

                if (!File.Exists(inputPath))

                {

                    Console.WriteLine("File not found: " + inputPath);

                    continue;

                }



                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".odp");



                    // Save the presentation as ODP

                    presentation.Save(outputPath, SaveFormat.Odp);

                }



                Console.WriteLine("Converted: " + inputPath);

            }

            catch (NotSupportedException)

            {

                // Handle unsupported format

                Console.WriteLine("Format not supported for file: " + inputPath);

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine("Error processing file " + inputPath + ": " + ex.Message);

            }

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Process presentations alphabetically and convert to SWF using C#

//

// Description:

// Demonstrates how to enumerate PowerPoint files in a folder, sort them

// alphabetically, and convert each presentation to SWF format using

// Aspose.Slides for .NET. The example creates an input and output directory,

// loads each supported presentation, and saves the result as a SWF file.

// This pattern can be used to batch‑process PPT/PPTX files for web preview

// or archival purposes in a standalone console application.

//

// Keywords:

// C#, PowerPoint, PPT, PPTX, SWF, Aspose.Slides for .NET, Batch Conversion,

// Alphabetical Sorting, Presentation Processing, Office Automation

//

// Use Cases:

// - Batch convert a collection of PowerPoint files to SWF for web viewing.

// - Automate alphabetical processing of presentations before conversion.

// - Integrate PowerPoint to SWF conversion into .NET build or deployment pipelines.

// - Validate and handle unsupported formats during bulk conversion.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input and output directories

        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");

        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");



        // Verify input directory exists

        if (!Directory.Exists(inputDirectory))

        {

            Console.WriteLine("Input directory does not exist.");

            return;

        }



        // Create output directory if it does not exist

        if (!Directory.Exists(outputDirectory))

        {

            Directory.CreateDirectory(outputDirectory);

        }



        // Get all files in the input directory and sort them alphabetically

        string[] inputFiles = Directory.GetFiles(inputDirectory);

        Array.Sort(inputFiles, StringComparer.OrdinalIgnoreCase);



        // Process each presentation file

        foreach (string inputFilePath in inputFiles)

        {

            // Check if the file actually exists

            if (!File.Exists(inputFilePath))

            {

                Console.WriteLine("File not found: " + inputFilePath);

                continue;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputFilePath))

                {

                    // Prepare output file path with .swf extension

                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(inputFilePath);

                    string outputFilePath = Path.Combine(outputDirectory, fileNameWithoutExtension + ".swf");



                    // Save the presentation as SWF

                    presentation.Save(outputFilePath, SaveFormat.Swf);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: The source presentation format is not supported for SWF conversion.

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., I/O errors)

                Console.WriteLine("Error processing file '" + inputFilePath + "': " + ex.Message);

            }

        }

    }

}


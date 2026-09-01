// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert ODP to SWF default settings using C#

//

// Description:

// Demonstrates how to convert all ODP files in a specified directory to SWF

// using the default conversion settings with Aspose.Slides for .NET. The

// example loads each ODP presentation, saves it as SWF, and handles basic

// error conditions. It can be used as a template for batch conversion of

// OpenDocument presentations to Flash format in console applications.

//

// Keywords:

// C#, Aspose.Slides for .NET, ODP, SWF, Convert, Default Settings, Batch

// Conversion, Presentation Processing, Office Automation

//

// Use Cases:

// - Batch convert ODP files to SWF with default options.

// - Build command‑line tools for OpenDocument to Flash conversion.

// - Integrate ODP to SWF conversion into .NET automation pipelines.

// - Validate ODP presentations before publishing as SWF.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Determine the directory to process

        string directoryPath;

        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))

        {

            directoryPath = args[0];

        }

        else

        {

            directoryPath = Directory.GetCurrentDirectory();

        }



        // Verify the directory exists

        if (!Directory.Exists(directoryPath))

        {

            Console.WriteLine("Directory does not exist: " + directoryPath);

            return;

        }



        // Get all ODP files in the directory

        string[] files = Directory.GetFiles(directoryPath, "*.odp", SearchOption.TopDirectoryOnly);

        foreach (string inputPath in files)

        {

            // Ensure the file exists before processing

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("File not found: " + inputPath);

                continue;

            }



            // Prepare output SWF file path

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);

            string outputPath = Path.Combine(directoryPath, fileNameWithoutExt + ".swf");



            try

            {

                // Load the ODP presentation

                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))

                {

                    // Convert to SWF using default options (rule: convert-without-xps-options)

                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf);

                }



                Console.WriteLine("Converted: " + inputPath + " -> " + outputPath);

            }

            catch (InvalidOperationException)

            {

                // Format not supported

                Console.WriteLine("Conversion not supported for file: " + inputPath);

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine("Error processing file: " + inputPath);

                Console.WriteLine(ex.Message);

            }

        }

    }

}


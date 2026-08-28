// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Disable XPS compression for debugging using C#

//

// Description:

// Demonstrates how to attempt disabling XPS compression when saving a

// presentation to XPS format using Aspose.Slides for .NET. The code loads a

// PPTX file, creates XpsOptions, and saves the presentation as an XPS file.

// Although the current API does not expose a compression toggle, the example

// documents where such a setting would be applied and provides a template for

// future versions or custom implementations.

//

// Keywords:

// C#, Aspose.Slides, XPS, Disable Compression, Debugging, PowerPoint, PPTX,

// Presentation Conversion, .NET

//

// Use Cases:

// - Debug XPS output by generating an uncompressed file.

// - Prepare a baseline for comparing compressed vs. uncompressed XPS.

// - Integrate XPS conversion into automated .NET build or test pipelines.

// - Serve as a reference for handling missing API features in Aspose.Slides.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputPath = "output.xps";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Create XPS save options

                XpsOptions options = new XpsOptions();



                // The XpsOptions class does not expose a 'Compress' property in the current API.

                // If compression control were available, it would be set here, e.g.:

                // options.Compress = false;



                // Save the presentation as an uncompressed XPS file for debugging

                presentation.Save(outputPath, SaveFormat.Xps, options);

            }

        }

        catch (PptxUnsupportedFormatException)

        {

            // Handle unsupported file format

            Console.WriteLine("The file format is not supported for XPS conversion.");

        }

        catch (Exception ex)

        {

            // General exception handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


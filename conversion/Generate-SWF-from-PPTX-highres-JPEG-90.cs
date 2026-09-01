// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Generate SWF from PPTX highres JPEG 90 using C#

//

// Description:

// Demonstrates how to generate a SWF file from a PPTX presentation with

// high‑resolution JPEG quality set to 90 using C# and Aspose.Slides for .NET.

// The example loads a PowerPoint file, configures SWF export options to use

// JPEG quality 90, and saves the result as a SWF file. This pattern can be used

// to automate PPTX to SWF conversions, integrate presentation processing into

// .NET applications, or validate output quality before publishing.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, JPEG, Generate, Highres,

// Jpeg, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to SWF with high JPEG quality.

// - Build C# utilities for PowerPoint presentation processing and export.

// - Integrate SWF generation into .NET workflows or web services.

// - Validate presentation rendering quality before distribution.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.swf";



        // Check if the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Configure SWF options with high JPEG quality

            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

            swfOptions.JpegQuality = 90;



            // Save the presentation as SWF with the specified options

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);



            // Dispose the presentation object

            presentation.Dispose();



            Console.WriteLine("Conversion to SWF completed successfully.");

        }

        catch (NotSupportedException ex)

        {

            // Handle unsupported format exception

            Console.WriteLine("The file format is not supported: " + ex.Message);

        }

        catch (Exception ex)

        {

            // Handle other exceptions

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


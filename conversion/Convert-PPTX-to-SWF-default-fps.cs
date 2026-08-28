// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to SWF default fps using C#

//

// Description:

// Demonstrates how to convert a PPTX file to SWF using the default frame

// rate with Aspose.Slides for .NET. The example loads a presentation,

// applies default SWF export options, and saves the result as an SWF file.

// This pattern can be used in console applications to automate PowerPoint

// conversion tasks.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Convert, Default FPS,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX presentations to SWF with default frame rate.

// - Integrate PowerPoint to SWF conversion into .NET tools or services.

// - Generate SWF assets for web or e‑learning platforms from PPTX sources.

// - Validate presentation rendering before publishing.

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



        // Verify that the input PPTX file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation from the specified file

            Presentation presentation = new Presentation(inputPath);



            // Initialize SWF options with default settings

            SwfOptions swfOptions = new SwfOptions();



            // Save the presentation as SWF using default frame rate

            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);



            // Release resources

            presentation.Dispose();



            Console.WriteLine("Conversion to SWF completed successfully.");

        }

        catch (NotSupportedException)

        {

            // format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set SWF default font timesnewroman using C#

//

// Description:

// Demonstrates how to set the default regular font to Times New Roman when

// converting a PowerPoint presentation (PPTX) to SWF format using C# and

// Aspose.Slides for .NET. The example loads an existing PPTX file, configures

// SWF export options to specify the default font, and saves the result as an

// SWF file. This pattern can be used in console applications or automated

// workflows that require consistent font rendering in SWF output.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Default, Font, Times New Roman,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to SWF with a specific default font.

// - Build C# tools for PowerPoint presentation processing that need SWF output.

// - Ensure consistent font rendering in SWF files generated from presentations.

// - Integrate presentation conversion into .NET applications or CI pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.swf";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Presentation presentation = new Presentation(inputPath);



            // Create SWF options and set the default regular font

            SwfOptions swfOptions = new SwfOptions();

            swfOptions.DefaultRegularFont = "Times New Roman";



            // Save the presentation as SWF using the specified options

            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception)

        {

            // Handle other exceptions as needed

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to XPS preserving layout and fonts using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to an XPS document

// while preserving the original layout and embedded fonts. The example uses

// Aspose.Slides for .NET to load the presentation, configure XpsOptions with

// default settings that retain layout and fonts, and save the result as XPS.

// This pattern can be used in console applications or automated workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, XPS, Aspose.Slides for .NET, Convert, Preserve, Layout,

// Fonts, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to XPS with layout and font fidelity.

// - Build .NET tools for high‑quality document archiving or printing.

// - Integrate PowerPoint to XPS conversion into server‑side or desktop apps.

// - Ensure visual consistency when distributing presentations in XPS format.

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

        string outputPath = "output.xps";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Create XPS options (default settings preserve layout and fonts)

            Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();



            // Save the presentation as XPS

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);



            // Release resources

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

            // Comment: The provided file format is not supported for conversion to XPS.

        }

        catch (Exception ex)

        {

            // Handle other exceptions

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


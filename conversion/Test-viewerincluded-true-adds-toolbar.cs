// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test viewerincluded true adds toolbar using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to SWF format with the

// viewer toolbar included using Aspose.Slides for .NET. The example loads an

// input PPTX file, sets SwfOptions.ViewerIncluded to true, and saves the

// presentation as an SWF file. This pattern can be used to generate

// self‑contained SWF files that display a toolbar for navigation.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, ViewerIncluded, Toolbar,

// Conversion, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX files to SWF with an interactive viewer toolbar.

// - Create self‑contained SWF presentations for web embedding.

// - Automate batch conversion of PowerPoint files to SWF with toolbar support.

// - Validate SWF output that includes navigation controls.

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

        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            using (Presentation pres = new Presentation(inputPath))

            {

                // Configure SWF options to include the viewer toolbar

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.ViewerIncluded = true;



                // Save as SWF preserving original slide layout

                string outputPath = Path.Combine(Environment.CurrentDirectory, "output.swf");

                pres.Save(outputPath, SaveFormat.Swf, swfOptions);

                Console.WriteLine("Presentation saved to SWF with viewer included: " + outputPath);

            }

        }

        catch (Exception ex)

        {

            // Handle errors such as unsupported format

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to XPS landscape orientation using C#

//

// Description:

// Demonstrates how to convert a PPTX file to an XPS document with landscape

// slide orientation using C# and Aspose.Slides for .NET. The example loads a

// presentation, sets the slide size orientation to landscape, and saves the

// result as an XPS file. It includes basic file existence checks and error

// handling suitable for console applications.

//

// Keywords:

// C#, PowerPoint, PPTX, XPS, Aspose.Slides for .NET, Convert, Landscape, 

// Orientation, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX presentations to XPS format with landscape layout.

// - Build C# utilities for PowerPoint slide orientation adjustments.

// - Integrate PPTX to XPS conversion into .NET workflows or services.

// - Validate and process presentation files before distribution or printing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input and output file paths

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

                // Set slide orientation to landscape

                presentation.SlideSize.Orientation = SlideOrientation.Landscape;



                // Save the presentation as XPS

                presentation.Save(outputPath, SaveFormat.Xps);

            }

        }

        catch (NotSupportedException)

        {

            // Handle unsupported format

            Console.WriteLine("The file format is not supported for conversion.");

        }

        catch (Exception ex)

        {

            // General exception handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


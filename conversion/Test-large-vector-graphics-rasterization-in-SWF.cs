// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test large vector graphics rasterization in SWF using C#

//

// Description:

// Demonstrates how to rasterize large vector graphics when converting a PowerPoint

// presentation to SWF format using Aspose.Slides for .NET. The example loads a PPTX

// file, applies default SWF options that rasterize vector shapes, and saves the

// result as an SWF file. This pattern can be used to verify rasterization behavior

// for complex graphics in automated tests or conversion tools.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Rasterization, Large Vector Graphics,

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Test rasterization of large vector graphics during PPTX to SWF conversion.

// - Build C# utilities for converting presentations to SWF with default rasterization.

// - Validate visual fidelity of complex graphics in SWF output.

// - Integrate SWF conversion into .NET automation pipelines.

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

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                // Configure SWF options (default settings rasterize vector graphics)

                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();



                // Save the presentation as SWF

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                // Presentation is saved before exiting the using block

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


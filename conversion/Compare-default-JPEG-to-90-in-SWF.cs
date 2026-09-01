// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Compare default JPEG to 90 in SWF using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to SWF format twice:

// once using the default JPEG quality (95) and once with a manually set JPEG

// quality of 90. The example shows the required presentation‑processing steps

// for PowerPoint files and produces two SWF files that can be compared to

// evaluate the impact of JPEG quality settings. This pattern can be used in

// standalone console applications to automate PPTX to SWF conversion and

// quality testing with Aspose.Slides for .NET.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Compare, Default, Jpeg,

// SWF, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate comparison of default JPEG quality versus custom quality in SWF.

// - Build C# tools for PowerPoint to SWF conversion with quality control.

// - Generate SWF files from PPTX in .NET applications for web or e‑learning.

// - Validate visual fidelity of presentations after JPEG compression.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Path to the source presentation

        string inputPath = "input.pptx";



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

                // Save SWF with default JPEG quality (default is 95)

                string outputDefault = "output_default.swf";

                presentation.Save(outputDefault, SaveFormat.Swf);



                // Save SWF with manually set JPEG quality of 90

                string outputCustom = "output_quality90.swf";

                SwfOptions swfOptions = new SwfOptions();

                swfOptions.JpegQuality = 90;

                presentation.Save(outputCustom, SaveFormat.Swf, swfOptions);

            }



            // At this point you can manually compare output_default.swf and output_quality90.swf

        }

        catch (NotSupportedException ex)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported: " + ex.Message);

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


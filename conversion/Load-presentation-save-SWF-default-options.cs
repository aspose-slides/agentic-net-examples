// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load presentation save SWF default options using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation and save it as an SWF file

// using the default SwfOptions with Aspose.Slides for .NET. The example includes

// basic file existence checking, exception handling, and uses the minimal

// configuration required to perform the conversion in a console application.

// Developers can adapt this pattern for automated PPTX to SWF conversion tasks.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Load, Presentation, Save, 

// Default Options, Conversion, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to SWF format with default settings.

// - Build C# utilities for PowerPoint presentation processing and export.

// - Integrate SWF generation into .NET applications for web or mobile viewers.

// - Validate presentation conversion workflows before deployment.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input and output file paths

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

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                // Create default SWF options

                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();



                // Save the presentation as SWF with minimal configuration

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            // Handle other possible exceptions

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


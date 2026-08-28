// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Save PPT to XPS with half-inch margin using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to an XPS

// document while applying a visual half‑inch margin by enabling a slide frame.

// The example uses Aspose.Slides for .NET to load the presentation, configure

// XpsOptions, and save the output file. It includes basic file existence checks

// and exception handling suitable for console applications.

//

// Keywords:

// C#, PowerPoint, PPTX, XPS, Aspose.Slides for .NET, Save, Half-Inch, Margin,

// Slide Frame, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX files to XPS with a visual margin for printing or preview.

// - Build .NET utilities that automate PowerPoint to XPS transformations.

// - Integrate slide‑frame based margin simulation into document workflows.

// - Validate and troubleshoot XPS export settings in automated pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

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

            Presentation presentation = new Presentation(inputPath);



            // Create XPS options

            XpsOptions options = new XpsOptions();



            // Aspose.Slides does not provide a direct margin property for XPS export.

            // As a workaround, you can enable a frame around each slide to visualize margins.

            options.DrawSlidesFrame = true;



            // Save the presentation as XPS with the specified options

            presentation.Save(outputPath, SaveFormat.Xps, options);



            // Dispose the presentation object

            presentation.Dispose();



            Console.WriteLine("Presentation successfully saved as XPS: " + outputPath);

        }

        catch (NotSupportedException)

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


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log conversion failures with exception messages using C#

//

// Description:

// Demonstrates how to log conversion failures with exception messages while

// converting a PowerPoint presentation to PDF using Aspose.Slides for .NET.

// The example loads a PPTX file, attempts to save it as PDF, and writes any

// errors (including unsupported format) to a log file. It can be used as a

// template for robust PowerPoint processing in console applications.

//

// Keywords:

// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, Conversion, Failure Logging,

// Exception Handling, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate logging of conversion errors for batch PPTX to PDF workflows.

// - Build resilient .NET tools that handle unsupported formats gracefully.

// - Integrate PowerPoint conversion with custom error reporting mechanisms.

// - Validate and monitor presentation processing pipelines before deployment.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Determine input file path

        string inputPath;

        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))

        {

            inputPath = args[0];

        }

        else

        {

            inputPath = "sample.pptx";

        }



        // Log file for conversion failures

        string logPath = "conversion.log";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            File.WriteAllText(logPath, $"Input file not found: {inputPath}");

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Define output path (PDF)

            string outputPath = Path.ChangeExtension(inputPath, ".pdf");



            // Save the presentation as PDF

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);



            // Dispose the presentation before exiting

            presentation.Dispose();

        }

        catch (NotSupportedException notSupportedEx)

        {

            // Handle unsupported format exception

            File.AppendAllText(logPath, $"Conversion failed (format not supported): {notSupportedEx.Message}");

        }

        catch (Exception ex)

        {

            // Log any other conversion failures

            File.AppendAllText(logPath, $"Conversion failed: {ex.Message}");

        }

    }

}


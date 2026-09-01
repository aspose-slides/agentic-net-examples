// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create unsupported features report for PPTX conversion using C#

//

// Description:

// Demonstrates how to generate a diagnostic report while converting a PPTX

// presentation to FODP format using Aspose.Slides for .NET. The example loads

// an input PPTX, saves an intermediate PPTX, converts it to FODP, and writes

// a report that captures success, unsupported format warnings, or errors.

// This pattern helps developers automate conversion workflows and capture

// detailed diagnostics.

//

// Keywords:

// C#, PowerPoint, PPTX, FODP, Aspose.Slides for .NET, Unsupported, Features,

// Report, Presentation Conversion, Office Automation

//

// Use Cases:

// - Automate creation of a diagnostic report for PPTX to FODP conversion.

// - Build C# tools that validate PowerPoint presentations before conversion.

// - Generate conversion logs for troubleshooting unsupported features.

// - Integrate presentation conversion and reporting into .NET applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Text;

using Aspose.Slides;

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

            inputPath = "input.pptx"; // default placeholder

        }



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        // Prepare intermediate and output file paths

        string intermediatePptx = Path.Combine(Path.GetDirectoryName(inputPath) ?? string.Empty, "intermediate.pptx");

        string outputFodp = Path.Combine(Path.GetDirectoryName(inputPath) ?? string.Empty, "output.fodp");

        string reportPath = Path.Combine(Path.GetDirectoryName(inputPath) ?? string.Empty, "diagnostic_report.txt");



        // StringBuilder for diagnostic report

        StringBuilder reportBuilder = new StringBuilder();



        try

        {

            // Load the original presentation

            Presentation pres1 = new Presentation(inputPath);

            // Save as intermediate PPTX (fodp-format-convertion rule)

            pres1.Save(intermediatePptx, SaveFormat.Pptx);

            pres1.Dispose();



            // Load the intermediate PPTX

            Presentation pres2 = new Presentation(intermediatePptx);

            // Save as final FODP (fodp-format-convertion rule)

            pres2.Save(outputFodp, SaveFormat.Fodp);

            pres2.Dispose();



            reportBuilder.AppendLine("Conversion succeeded.");

        }

        catch (PptxUnsupportedFormatException ex)

        {

            // Handle unsupported PPTX format

            reportBuilder.AppendLine("Warning: PPTX format unsupported. " + ex.Message);

        }

        catch (PptUnsupportedFormatException ex)

        {

            // Handle unsupported PPT format

            reportBuilder.AppendLine("Warning: PPT format unsupported. " + ex.Message);

        }

        catch (Exception ex)

        {

            // General error handling

            reportBuilder.AppendLine("Error: " + ex.Message);

        }



        // Write the diagnostic report to a file

        try

        {

            File.WriteAllText(reportPath, reportBuilder.ToString());

            Console.WriteLine("Diagnostic report written to " + reportPath);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Failed to write diagnostic report: " + ex.Message);

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log substituted font names during SWF conversion using C#

//

// Description:

// Demonstrates how to enumerate and log font substitutions that Aspose.Slides

// will apply when converting a PowerPoint presentation to SWF format. The

// example loads a PPTX file, prints each original‑to‑substituted font mapping,

// configures optional SWF options, and saves the result as a SWF file.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Font Substitution, 

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Identify missing fonts before converting PPTX to SWF.

// - Create diagnostic tools for PowerPoint to SWF workflows.

// - Automate batch conversion while logging font substitution details.

// - Ensure visual fidelity of converted presentations in .NET applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input and output file paths

        var inputPath = "input.pptx";

        var outputPath = "output.swf";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            var presentation = new Aspose.Slides.Presentation(inputPath);



            // Log font substitutions that will occur during rendering

            foreach (var substitution in presentation.FontsManager.GetSubstitutions())

            {

                Console.WriteLine("{0} -> {1}", substitution.OriginalFontName, substitution.SubstitutedFontName);

            }



            // Set SWF conversion options (optional)

            var swfOptions = new Aspose.Slides.Export.SwfOptions();

            swfOptions.Compressed = true; // example option



            // Save the presentation as SWF

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            // Format not supported

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


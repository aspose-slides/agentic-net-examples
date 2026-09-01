// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Generate missing font report during SWF conversion using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, retrieve missing font

// information via Aspose.Slides for .NET, output a report of font substitutions,

// and then convert the presentation to SWF format. The example is a complete

// console application that can be used to automate font validation before

// SWF export.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, SWF, Font Substitution, Missing Font Report,

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Identify missing fonts before converting PPTX to SWF.

// - Generate a console report of font substitutions for quality checks.

// - Integrate font validation into automated PowerPoint processing pipelines.

// - Build .NET tools that convert presentations while ensuring font compatibility.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Collections.Generic;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input and output file paths

        string inputPath = "input.pptx";

        string outputSwfPath = "output.swf";



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Presentation presentation = new Presentation(inputPath);



            // Retrieve font substitutions (missing fonts)

            IEnumerable<FontSubstitutionInfo> missingFonts = presentation.FontsManager.GetSubstitutions();



            Console.WriteLine("Missing fonts detected during SWF conversion:");

            foreach (FontSubstitutionInfo info in missingFonts)

            {

                Console.WriteLine("{0} -> {1}", info.OriginalFontName, info.SubstitutedFontName);

            }



            // Configure SWF conversion options

            SwfOptions swfOptions = new SwfOptions();

            // Example: set a default font if needed

            // swfOptions.DefaultRegularFont = "Arial";



            // Save presentation as SWF

            presentation.Save(outputSwfPath, SaveFormat.Swf, swfOptions);



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle errors such as unsupported format

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


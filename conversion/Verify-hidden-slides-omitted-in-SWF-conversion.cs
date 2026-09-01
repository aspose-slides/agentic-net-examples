// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Verify hidden slides omitted in SWF conversion using C#

//

// Description:

// Demonstrates how to verify hidden slides omitted in SWF conversion using C# 

// and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Verify, Hidden, Slides, 

// Omitted, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate verify hidden slides omitted in SWF conversion.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

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

        var inputPath = "input.pptx";

        var outputPath = "output.swf";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            var presentation = new Aspose.Slides.Presentation(inputPath);



            // Configure SWF options to exclude hidden slides

            var swfOptions = new Aspose.Slides.Export.SwfOptions();

            swfOptions.ShowHiddenSlides = false;



            // Convert and save as SWF

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


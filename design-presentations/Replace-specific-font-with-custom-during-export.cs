// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Replace specific font with custom during export using C#

//

// Description:

// Demonstrates how to replace a specific font with a custom font during export 

// using C# and Aspose.Slides for .NET. The example loads a PowerPoint file, 

// substitutes all occurrences of the source font with the destination font, 

// and saves the modified presentation. This pattern can be used to ensure 

// consistent typography across exported presentations.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Specific, Font, 

// Custom, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate replacement of a specific font with a custom font during export.

// - Build C# tools for PowerPoint presentation processing and font management.

// - Generate or transform PPTX files in .NET applications with consistent fonts.

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

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



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



            // Define the source font to replace and the destination custom font

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Calibri");



            // Replace all occurrences of the source font with the custom font

            presentation.FontsManager.ReplaceFont(sourceFont, destFont);



            // Save the modified presentation

            presentation.Save(outputPath, SaveFormat.Pptx);



            // Clean up

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


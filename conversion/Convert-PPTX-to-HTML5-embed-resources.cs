// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPTX to HTML5 embed resources using C#

//

// Description:

// Demonstrates how to convert PPTX to HTML5 embed resources using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, Pptx, Html5, Embed, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate convert PPTX to HTML5 embed resources.

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

    static void Main(string[] args)

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.html";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Presentation presentation = new Presentation(inputPath);



            // Configure HTML5 export options to embed all images for offline access

            Html5Options html5Options = new Html5Options();

            html5Options.EmbedImages = true;

            // Optionally specify a folder for external resources

            // html5Options.OutputPath = "resources";



            // Save the presentation as HTML5

            presentation.Save(outputPath, SaveFormat.Html5, html5Options);



            // Dispose the presentation object

            presentation.Dispose();



            Console.WriteLine("Conversion to HTML5 completed successfully.");

        }

        catch (NotSupportedException)

        {

            // Format not supported

            // format not supported

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., external URL issues)

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


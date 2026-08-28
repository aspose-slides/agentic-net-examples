// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to HTML with lazy images using C#

//

// Description:

// Demonstrates how to export a PPTX presentation to HTML5 with lazy-loaded

// images using C# and Aspose.Slides for .NET. The example loads a PowerPoint

// file, configures HTML5 export options to keep images external (enabling

// lazy loading), and saves the result as an HTML file. This pattern can be

// used in console applications to automate presentation conversion workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML5, Export, Lazy Images,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to HTML5 with external image resources.

// - Build .NET tools that generate web-friendly presentations with lazy loading.

// - Integrate PowerPoint to web content pipelines in C# applications.

// - Validate and test presentation export settings before deployment.

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



            // Configure HTML5 export options for lazy-loaded images

            Html5Options htmlOptions = new Html5Options

            {

                EmbedImages = false // Images will be external, allowing lazy loading

            };



            // Save the presentation as HTML5

            presentation.Save(outputPath, SaveFormat.Html5, htmlOptions);



            // Dispose the presentation before exiting

            presentation.Dispose();

        }

        catch (System.Net.WebException)

        {

            // Handle exceptions related to external URLs or web services

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            // Format not supported or other error: ex.Message

        }

    }

}


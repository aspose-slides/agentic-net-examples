// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to HTML5 with react component using C#

//

// Description:

// Demonstrates how to export a PPTX file to HTML5 using Aspose.Slides for .NET.

// The example creates a Presentation object, configures Html5Options to enable

// shape and transition animations, and saves the result as an HTML5 file that

// can be embedded in a React component for dynamic rendering.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, HTML5, React, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PowerPoint presentations to HTML5 for web applications.

// - Integrate exported HTML5 slides into React components.

// - Automate PPTX to HTML5 conversion in .NET tools.

// - Validate and preview presentations before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPath = "output.html";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            Presentation presentation = new Presentation(inputPath);

            Html5Options html5Options = new Html5Options();

            html5Options.AnimateShapes = true;

            html5Options.AnimateTransitions = true;

            // html5Options.OutputPath = "resources"; // optional: set folder for external resources



            presentation.Save(outputPath, SaveFormat.Html5, html5Options);

            presentation.Dispose();



            Console.WriteLine("Presentation exported to HTML5 successfully: " + outputPath);

            // The generated HTML file can be loaded into a React component for dynamic rendering.

        }

        catch (Exception ex)

        {

            // Format not supported.

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to HTML with separate css using C#

//

// Description:

// Demonstrates how to export a PPTX file to an HTML document that references

// an external CSS stylesheet using C# and Aspose.Slides for .NET. The example

// loads a presentation, configures HTML export options to use a separate CSS

// file, and saves the resulting HTML.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML, Export, Separate CSS,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX presentations to HTML with external styling.

// - Build .NET tools that generate web-friendly versions of PowerPoint files.

// - Integrate presentation export functionality into larger applications.

// - Separate content from style for easier web maintenance.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Input PPTX file path

        string inputPath = "input.pptx";

        // Output HTML file path

        string outputPath = "output.html";

        // URL of external CSS file

        string cssUrl = "styles.css";



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



            // Set up HTML export options with external CSS

            HtmlOptions htmlOptions = new HtmlOptions();

            htmlOptions.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(cssUrl, false);



            // Export to HTML

            presentation.Save(outputPath, SaveFormat.Html, htmlOptions);



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to HTML single embedded resources using C#

//

// Description:

// Demonstrates how to export a PPTX file to a single HTML file with all

// resources (images, CSS, scripts) embedded using Aspose.Slides for .NET.

// The example loads a presentation, creates the output directory if needed,

// configures Html5Options to embed images, and saves the result as

// presentation.html.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML, Export, Single Embedded Resources,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PowerPoint presentations to self-contained HTML for web publishing.

// - Build .NET utilities that need to embed all assets into a single HTML file.

// - Automate batch conversion of PPTX files to portable HTML documents.

// - Validate and test presentation rendering in browsers without external files.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        var inputPath = "input.pptx";

        var outputDir = "output";

        var outputHtml = Path.Combine(outputDir, "presentation.html");



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            using (var pres = new Aspose.Slides.Presentation(inputPath))

            {

                if (!Directory.Exists(outputDir))

                {

                    Directory.CreateDirectory(outputDir);

                }



                var options = new Aspose.Slides.Export.Html5Options()

                {

                    EmbedImages = true,

                    OutputPath = outputDir

                };



                pres.Save(outputHtml, Aspose.Slides.Export.SaveFormat.Html5, options);

            }

        }

        catch (Exception ex)

        {

            // If the file format is not supported, handle accordingly.

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


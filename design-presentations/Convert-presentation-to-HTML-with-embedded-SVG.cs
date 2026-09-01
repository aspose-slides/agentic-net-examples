// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert presentation to HTML with embedded SVG using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to an HTML file with

// embedded SVG graphics using C# and Aspose.Slides for .NET. The example loads

// a PPTX file, configures HTML and SVG options to embed vector graphics, and

// saves the result as a standalone HTML document. This pattern can be used to

// automate PPTX to HTML conversion, integrate presentation processing into

// .NET applications, or generate web‑ready versions of slides.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML, SVG, Convert, Presentation,

// Html, Embedded, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PowerPoint presentations to HTML with embedded SVG.

// - Build .NET tools for web‑friendly rendering of slide decks.

// - Integrate slide conversion into server‑side or desktop applications.

// - Validate and preview presentation content before publishing online.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace PresentationToHtml

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output paths

            string inputPath = "input.pptx";

            string outputHtml = "output.html";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // Set up HTML controller for embedding SVG graphics

                string baseUri = "";

                VideoPlayerHtmlController controller = new VideoPlayerHtmlController("", outputHtml, baseUri);



                // Configure HTML and SVG options

                HtmlOptions htmlOptions = new HtmlOptions(controller);

                SVGOptions svgOptions = new SVGOptions(controller);

                htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

                htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);



                // Save presentation as HTML with embedded SVG

                presentation.Save(outputHtml, SaveFormat.Html, htmlOptions);



                // Clean up

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


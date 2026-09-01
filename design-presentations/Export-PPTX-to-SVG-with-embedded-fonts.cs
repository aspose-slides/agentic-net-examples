// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to SVG with embedded fonts using C#

//

// Description:

// Demonstrates how to load a PPTX file, export each slide to an SVG file with

// embedded fonts, and optionally save the presentation. The example uses

// Aspose.Slides for .NET to handle PowerPoint processing and SVGOptions to

// embed fonts directly into the SVG output, ensuring visual fidelity without

// external font dependencies.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Export, Embedded Fonts,

// Slide Export, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PowerPoint slides to SVG with embedded fonts for web or print.

// - Create automated tools that generate SVG assets from PPTX files.

// - Ensure SVG outputs retain original typography without requiring external fonts.

// - Integrate slide-to-SVG conversion into .NET applications or CI pipelines.

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

        if (!File.Exists(inputPath))

        {

            // Input file does not exist

            return;

        }



        try

        {

            Presentation presentation = new Presentation(inputPath);

            SVGOptions svgOptions = new SVGOptions

            {

                // Preserve theme colors and embed fonts

                ExternalFontsHandling = SvgExternalFontsHandling.Embed

            };



            for (int i = 0; i < presentation.Slides.Count; i++)

            {

                string outputSvg = $"slide_{i + 1}.svg";

                using (FileStream fileStream = File.Create(outputSvg))

                {

                    presentation.Slides[i].WriteAsSvg(fileStream, svgOptions);

                }

            }



            // Save presentation before exit (optional, retains original content)

            presentation.Save("output.pptx", SaveFormat.Pptx);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (System.Net.WebException)

        {

            // Handle external URL or web service exception

        }

    }

}


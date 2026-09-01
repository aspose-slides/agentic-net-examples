// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to HTML with semantic sections using C#

//

// Description:

// Demonstrates how to load a PPTX file with Aspose.Slides for .NET, export it to

// HTML using SVG images for slides, and then post‑process the generated HTML to

// replace the default <div class="slide"> containers with semantic <section>

// elements. The example includes file existence checks and basic error handling

// in a console application.

//

// Keywords:

// C#, Aspose.Slides for .NET, PPTX, PowerPoint, HTML export, SVG, Semantic sections,

// Presentation conversion, Office automation, SlideImageFormat, HtmlOptions

//

// Use Cases:

// - Convert PowerPoint presentations to HTML with high‑quality SVG slide images.

// - Produce HTML output that follows semantic markup guidelines.

// - Integrate PPTX‑to‑HTML conversion into .NET automation scripts or tools.

// - Customize exported HTML structure for web publishing or further processing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportPptxToHtmlWithSemanticSections

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "presentation.pptx";

            string outputPath = "presentation.html";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Configure HTML export options to use SVG for slide images

                    HtmlOptions htmlOptions = new HtmlOptions();

                    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(SVGOptions.WYSIWYG);



                    // Save the presentation as HTML

                    pres.Save(outputPath, SaveFormat.Html, htmlOptions);

                }



                // Post‑process the generated HTML to replace slide containers with <section> elements

                string htmlContent = File.ReadAllText(outputPath);

                // Replace opening div that represents a slide with <section>

                htmlContent = htmlContent.Replace("<div class=\"slide\"", "<section");

                // Replace the corresponding closing div with </section>

                htmlContent = htmlContent.Replace("</div>", "</section>");

                File.WriteAllText(outputPath, htmlContent);



                Console.WriteLine("Export completed successfully.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., I/O errors, Aspose.Slides errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


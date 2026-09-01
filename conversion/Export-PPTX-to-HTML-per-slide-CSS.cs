// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to HTML per slide CSS using C#

//

// Description:

// Demonstrates how to export each slide of a PPTX file to a separate HTML file

// with its own CSS stylesheet using Aspose.Slides for .NET. The example creates

// an output folder, iterates through all slides, configures HtmlOptions to

// generate per‑slide CSS via HtmlFormatter.CreateSlideShowFormatter, and saves

// each slide as an individual HTML file. It also shows how to optionally save

// the original presentation after processing. This pattern is useful for

// automating PowerPoint to web‑ready HTML conversion in console applications.

// 

// Keywords:

// C#, Aspose.Slides for .NET, PPTX, HTML, CSS, per‑slide export, SlideShowFormatter,

// Presentation processing, Office automation, console application

//

// Use Cases:

// - Convert PowerPoint presentations to web‑friendly HTML with separate CSS per slide.

// - Build command‑line tools for batch exporting PPTX files to HTML.

// - Integrate slide‑by‑slide HTML generation into .NET services or pipelines.

// - Preserve the original PPTX while creating HTML representations for publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "sample.pptx";

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        string outputDir = "HtmlOutput";

        if (!Directory.Exists(outputDir))

        {

            Directory.CreateDirectory(outputDir);

        }



        try

        {

            using (Presentation presentation = new Presentation(inputPath))

            {

                int slideCount = presentation.Slides.Count;

                for (int i = 0; i < slideCount; i++)

                {

                    string cssFileName = $"slide_{i + 1}.css";

                    string htmlFileName = Path.Combine(outputDir, $"slide_{i + 1}.html");



                    HtmlOptions htmlOptions = new HtmlOptions();

                    htmlOptions.HtmlFormatter = HtmlFormatter.CreateSlideShowFormatter(cssFileName, true);

                    htmlOptions.SlideImageFormat = new SlideImageFormat();



                    int[] slideIndices = new int[] { i + 1 };

                    presentation.Save(htmlFileName, slideIndices, SaveFormat.Html, htmlOptions);

                }



                // Save the original presentation (optional)

                string presSavePath = Path.Combine(outputDir, "original.pptx");

                presentation.Save(presSavePath, SaveFormat.Pptx);

            }

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException ex)

        {

            Console.WriteLine("The presentation format is not supported: " + ex.Message);

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to HTML with inline SVG using C#

//

// Description:

// Demonstrates how to export a PPTX file to an HTML5 document with inline SVG

// images using Aspose.Slides for .NET. The example loads a presentation,

// configures HTML export options to embed each slide as an SVG, saves the

// resulting HTML file, and optionally saves a copy of the original presentation.

// This pattern can be used in console applications, automation scripts, or

// integration scenarios where PPTX content needs to be displayed in web pages.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML5, SVG, Export, Inline SVG,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PowerPoint presentations to web-friendly HTML with scalable graphics.

// - Build .NET tools that embed slide content directly into HTML pages.

// - Automate batch conversion of PPTX files for publishing or documentation.

// - Validate and preview PPTX content in browsers without external image files.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        var inputPath = "input.pptx";

        var outputPath = "output.html";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            using (var pres = new Aspose.Slides.Presentation(inputPath))

            {

                var htmlOptions = new Aspose.Slides.Export.HtmlOptions();

                var svgOptions = new Aspose.Slides.Export.SVGOptions();

                htmlOptions.SlideImageFormat = Aspose.Slides.Export.SlideImageFormat.Svg(svgOptions);



                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, htmlOptions);



                // Save presentation before exit (optional)

                pres.Save("temp.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


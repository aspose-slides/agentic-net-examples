// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load presentation apply fallback stream SVG using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, configure a font fallback

// rule, and stream a slide as SVG using Aspose.Slides for .NET. The example

// shows how to apply a Unicode range fallback to a specific font, generate an

// SVG representation of the first slide via a memory stream, and save the

// modified presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Load, Presentation, Apply,

// Fallback, FontFallBack, Stream, Slide, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate loading a presentation and applying font fallback rules.

// - Generate SVG streams of slides for web or API delivery.

// - Build .NET tools that modify and export PowerPoint content.

// - Validate and transform PPTX files before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace MyApp

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                // Load the presentation

                var presentation = new Presentation(inputPath);



                // Apply a font fallback rule

                var rules = new FontFallBackRulesCollection();

                rules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

                presentation.FontsManager.FontFallBackRulesCollection = rules;



                // Get the first slide

                var slide = presentation.Slides[0];



                // Stream the slide as SVG (example uses a memory stream)

                using (var svgStream = new MemoryStream())

                {

                    slide.WriteAsSvg(svgStream);

                    svgStream.Position = 0;

                    // TODO: send svgStream to client (e.g., HTTP response)

                }



                // Save the modified presentation before exiting

                var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

                using (var outStream = new FileStream(outputPath, FileMode.Create))

                {

                    presentation.Save(outStream, SaveFormat.Pptx);

                }



                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine($"Error: {ex.Message}");

            }

        }

    }

}


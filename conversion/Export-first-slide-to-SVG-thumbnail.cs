// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export first slide to SVG thumbnail using C#

//

// Description:

// Demonstrates how to export the first slide of a PowerPoint presentation

// to an SVG thumbnail using Aspose.Slides for .NET. The example loads a PPTX

// file, writes the first slide as an SVG image, and saves the presentation

// back to disk. This pattern can be used in console applications to automate

// slide thumbnail generation or integrate SVG export into .NET workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Export, First Slide,

// Thumbnail, Presentation Processing, Office Automation

//

// Use Cases:

// - Generate SVG thumbnails for the first slide of presentations.

// - Build C# tools for PowerPoint slide extraction and conversion.

// - Automate batch processing of PPTX files to create preview images.

// - Integrate slide export functionality into .NET applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideToSvgExport

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

            string svgOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "slide1.svg");

            string presentationSavePath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Export the first slide as SVG using the slide's WriteAsSvg method

                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

                using (FileStream svgStream = File.Create(svgOutputPath))

                {

                    firstSlide.WriteAsSvg(svgStream);

                }



                // Save the presentation before exiting (required by the task)

                presentation.Save(presentationSavePath, Aspose.Slides.Export.SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: The requested format is not supported by Aspose.Slides.

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


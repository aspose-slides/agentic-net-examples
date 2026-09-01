// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create animated GIF from PPTX default delay using C#

//

// Description:

// Demonstrates how to convert a PowerPoint PPTX file to an animated GIF using

// the default frame delay and loop settings with Aspose.Slides for .NET. The

// example loads a presentation, applies default GifOptions, and saves the

// result as a GIF file. It includes basic error handling for missing input

// files and other exceptions.

//

// Keywords:

// C#, Aspose.Slides, PPTX, GIF, Animated GIF, Default Delay, Presentation

// Conversion, .NET, Office Automation

//

// Use Cases:

// - Generate animated GIFs from PowerPoint presentations with default timing.

// - Automate batch conversion of PPTX files to GIF for web or documentation.

// - Integrate simple PPTX-to-GIF conversion into .NET applications.

// - Validate presentation assets before publishing.

//

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



namespace MyApp

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "presentation.pptx";

            string outputPath = "animation.gif";



            // Check if the input PPTX file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                // Load the presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Create GIF options with default settings (default loop count and frame delay)

                Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();



                // Save the presentation as an animated GIF

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);



                // Dispose the presentation object

                presentation.Dispose();



                Console.WriteLine("Animated GIF created successfully.");

            }

            catch (Exception ex)

            {

                // Handle errors such as unsupported file format

                // Format not supported

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}


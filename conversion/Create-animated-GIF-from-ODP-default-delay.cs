// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create animated GIF from ODP default delay using C#

//

// Description:

// Demonstrates how to load an OpenDocument Presentation (ODP) file and

// export it as an animated GIF using the default frame delay and loop

// settings with Aspose.Slides for .NET. The example includes basic file

// existence checking and exception handling in a console application.

// Developers can adapt this pattern to automate ODP to GIF conversions.

//

// Keywords:

// C#, Aspose.Slides for .NET, ODP, GIF, Animated GIF, Default Delay, Presentation Conversion, Office Automation

//

// Use Cases:

// - Convert ODP presentations to animated GIFs with default timing.

// - Build command‑line tools for batch ODP to GIF conversion.

// - Integrate ODP rendering into .NET applications.

// - Validate ODP files before publishing as GIF animations.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace GifFromOdp

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input ODP file and output GIF paths

            string inputPath = "presentation.odp";

            string outputPath = "presentation.gif";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the ODP presentation

                Presentation presentation = new Presentation(inputPath);



                // Save as animated GIF using default options (default delay and loop settings)

                presentation.Save(outputPath, SaveFormat.Gif, new GifOptions());



                // Ensure the presentation is saved before exiting

                presentation.Dispose();



                Console.WriteLine("Animated GIF created successfully at: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Handle unsupported file format

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


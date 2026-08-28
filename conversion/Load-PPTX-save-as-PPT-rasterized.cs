// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load PPTX and save as rasterized PPT using C#

//

// Description:

// Demonstrates how to load a PPTX file and save it as a legacy PPT file using

// Aspose.Slides for .NET. The conversion rasterizes advanced effects that are

// not supported in the older PPT format. This console application shows the

// necessary steps for loading, converting, and handling errors.

//

// Keywords:

// C#, PowerPoint, PPTX, PPT, Aspose.Slides for .NET, conversion, rasterized,

// presentation processing, file format conversion, console app

//

// Use Cases:

// - Convert modern PPTX presentations to legacy PPT for compatibility.

// - Automate batch conversion of PowerPoint files in .NET environments.

// - Preserve visual fidelity by rasterizing unsupported features.

// - Integrate PPTX to PPT conversion into custom tools or workflows.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlidesConversion

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = args.Length > 0 ? args[0] : "sample.pptx";

            string outputPath = args.Length > 1 ? args[1] : "sample_converted.ppt";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the PPTX presentation

                Presentation presentation = new Presentation(inputPath);



                // Note: Advanced effects may be rasterized when saving to PPT format

                presentation.Save(outputPath, SaveFormat.Ppt);

                Console.WriteLine("Presentation saved successfully to: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., file access issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


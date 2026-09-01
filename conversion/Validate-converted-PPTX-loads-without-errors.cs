// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate converted PPTX loads without errors using C#

//

// Description:

// Demonstrates how to load a converted PPTX file using Aspose.Slides for .NET,

// verify it opens without errors, and save it to confirm successful validation.

// The example includes a file existence check, handling of unsupported format

// exceptions, generic error handling, and proper disposal of the presentation

// object.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Converted, Load, 

// Presentation, Error Handling, Office Automation

//

// Use Cases:

// - Validate that a converted PPTX file can be opened without errors.

// - Build tools to verify PPTX conversion pipelines.

// - Ensure PPTX files are compatible before further processing or publishing.

// - Automate validation in CI/CD for presentation assets.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ValidatePptx

{

    class Program

    {

        static void Main(string[] args)

        {

            // Path to the converted PPTX file

            string inputPath = "converted.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation to ensure it opens without errors

                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);



                // Save the presentation before exiting (validation succeeded)

                string outputPath = "validated_output.pptx";

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                Console.WriteLine("Presentation loaded and saved successfully.");



                // Dispose the presentation object

                pres.Dispose();

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Comment: format not supported

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other loading errors

                Console.WriteLine("Error loading presentation: " + ex.Message);

            }

        }

    }

}


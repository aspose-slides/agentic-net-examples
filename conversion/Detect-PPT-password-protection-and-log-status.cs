// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Detect PPT password protection and log status using C#

//

// Description:

// Demonstrates how to detect whether a PowerPoint presentation is password

// protected and log the result using Aspose.Slides for .NET. The example also

// creates an empty audit presentation and saves it to an output folder.

// This pattern can be used to automate validation of PPTX files before

// processing or publishing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PPT, Detect, Password,

// Protection, Status, Presentation Processing, Office Automation, Audit

//

// Use Cases:

// - Detect PPT password protection and log the status in a console tool.

// - Integrate password validation into .NET PowerPoint processing pipelines.

// - Generate audit output files for reporting or further analysis.

// - Ensure presentations meet security requirements before transformation.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace PresentationAudit

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine input file name (use first argument or default)

            string inputFileName;

            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))

            {

                inputFileName = args[0];

            }

            else

            {

                inputFileName = "sample.pptx";

            }



            // Build full path to the input file

            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);



            // Verify that the file exists

            if (!File.Exists(inputFilePath))

            {

                Console.WriteLine("Input file does not exist: " + inputFilePath);

                return;

            }



            try

            {

                // Get presentation information without loading the full file

                Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputFilePath);

                bool isPasswordProtected = presentationInfo.IsPasswordProtected;



                // Log the protection status

                if (isPasswordProtected)

                {

                    Console.WriteLine("The presentation '" + inputFileName + "' is protected by a password to open.");

                }

                else

                {

                    Console.WriteLine("The presentation '" + inputFileName + "' is NOT protected by a password.");

                }

            }

            catch (NotSupportedException)

            {

                // Handle unsupported file format

                Console.WriteLine("The file format is not supported for file: " + inputFileName);

            }

            catch (Exception ex)

            {

                // General exception handling (e.g., I/O errors)

                Console.WriteLine("An error occurred while processing the file: " + ex.Message);

            }



            // Save a new (empty) presentation before exiting as required

            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "output");

            if (!Directory.Exists(outputDirectory))

            {

                Directory.CreateDirectory(outputDirectory);

            }



            string outputFilePath = Path.Combine(outputDirectory, "audit_output.pptx");

            Aspose.Slides.Presentation newPresentation = new Aspose.Slides.Presentation();

            newPresentation.Save(outputFilePath, Aspose.Slides.Export.SaveFormat.Pptx);

            newPresentation.Dispose();



            Console.WriteLine("Audit completed. Output saved to: " + outputFilePath);

        }

    }

}


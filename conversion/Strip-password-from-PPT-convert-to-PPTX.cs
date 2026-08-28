// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Strip password from PPT and convert to PPTX using C#

//

// Description:

// Demonstrates how to remove password protection from a PPT file and save it

// as an unprotected PPTX using Aspose.Slides for .NET. The example loads a

// password‑protected presentation, strips its encryption, and writes the

// result to an output folder.

//

// Keywords:

// C#, PowerPoint, PPT, PPTX, Aspose.Slides for .NET, Strip Password, Convert,

// Presentation Encryption, Office Automation

//

// Use Cases:

// - Remove password protection from legacy PPT files.

// - Convert protected PPT presentations to PPTX for further editing.

// - Automate batch processing of encrypted PowerPoint files.

// - Integrate password‑removal into .NET document management workflows.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace PresentationConversion

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input PPT file (password protected)

            string inputFileName = "protected.ppt";

            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Password for the protected presentation

            string password = "myPassword";



            try

            {

                // Load the presentation with password

                LoadOptions loadOptions = new LoadOptions();

                loadOptions.Password = password;

                Presentation presentation = new Presentation(inputPath, loadOptions);



                // Remove encryption (strip password)

                presentation.ProtectionManager.RemoveEncryption();



                // Prepare output directory

                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");

                if (!Directory.Exists(outputDir))

                {

                    Directory.CreateDirectory(outputDir);

                }



                // Save as PPTX without password

                string outputFileName = "unprotected.pptx";

                string outputPath = Path.Combine(outputDir, outputFileName);

                presentation.Save(outputPath, SaveFormat.Pptx);



                // Log operation for audit

                Console.WriteLine("Converted password-protected PPT to PPTX without password.");

                Console.WriteLine("Input : " + inputPath);

                Console.WriteLine("Output: " + outputPath);



                // Dispose presentation

                presentation.Dispose();

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred during conversion: " + ex.Message);

                // Format not supported comment

                // Note: If the exception indicates an unsupported format, handle accordingly.

            }

        }

    }

}


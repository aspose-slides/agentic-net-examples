// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPT to PPTX with new password using C#

//

// Description:

// Demonstrates how to convert an existing PPT file to PPTX format while

// applying a new password protection using Aspose.Slides for .NET. The example

// loads a PPT presentation, encrypts it with a specified password, and saves

// the result as a PPTX file. This pattern can be used in console applications

// to automate secure PowerPoint file conversions.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PPT, Convert, Password, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert legacy PPT files to PPTX with added password protection.

// - Build .NET tools for securing PowerPoint presentations.

// - Automate batch processing of presentations with encryption.

// - Integrate password-protected PPTX generation into larger workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace PresentationPasswordChange

{

    class Program

    {

        static void Main()

        {

            // Define input PPT file path

            string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.ppt");

            if (!File.Exists(inputFile))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            // Define output directory and file path

            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            if (!Directory.Exists(outputDir))

            {

                Directory.CreateDirectory(outputDir);

            }

            string outputFile = Path.Combine(outputDir, "output.pptx");



            // New password to set

            string newPassword = "NewSecurePassphrase123!";



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputFile);



                // Set new password

                presentation.ProtectionManager.Encrypt(newPassword);



                // Save as PPTX with the new password

                presentation.Save(outputFile, SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URLs)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


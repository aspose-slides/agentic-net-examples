// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Encrypt presentation with password and restrict editing using C#

//

// Description:

// Demonstrates how to encrypt a PowerPoint presentation with a password and

// restrict editing by applying write protection using Aspose.Slides for .NET.

// The example loads an existing PPTX file, sets write protection, encrypts the

// file with the same password, and saves the protected presentation to an

// output folder. This pattern can be used to secure PPTX files before

// distribution or storage.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Encrypt, Presentation, Password,

// Restrict, Write Protection, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate encryption and write protection of PowerPoint presentations.

// - Build C# tools for securing PPTX files in .NET applications.

// - Generate or transform PPTX files with protection before publishing.

// - Validate presentation security workflows in automated pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input and output paths

        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        if (!Directory.Exists(outputDir))

        {

            Directory.CreateDirectory(outputDir);

        }



        string password = "myPassword";



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Restrict editing by setting write protection

            presentation.ProtectionManager.SetWriteProtection(password);



            // Encrypt the presentation with the same password

            presentation.ProtectionManager.Encrypt(password);



            // Save the protected presentation

            string outputPath = Path.Combine(outputDir, "protected.pptx");

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);



            // Clean up

            presentation.Dispose();



            Console.WriteLine("Presentation saved with encryption and write protection.");

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


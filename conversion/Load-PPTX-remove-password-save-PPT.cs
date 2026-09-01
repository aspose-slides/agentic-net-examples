// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load PPTX remove password save PPT using C#

//

// Description:

// Demonstrates how to load a password‑protected PPTX file, remove its encryption 

// and write protection, and save the resulting unprotected presentation as a PPT 

// file using Aspose.Slides for .NET. The example includes file existence checks, 

// output directory handling, and basic error handling suitable for a standalone 

// console application.

//

// Keywords:

// C#, PowerPoint, PPTX, PPT, Aspose.Slides for .NET, Load, Remove Password, 

// Encryption, Write Protection, Save, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate removal of password protection from PPTX files.

// - Convert protected PPTX presentations to unprotected PPT format.

// - Build .NET tools for batch processing of encrypted PowerPoint files.

// - Integrate decryption and format conversion into larger Office automation workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input and output settings

        string inputPath = "protected.pptx";

        string outputDir = "output";

        string outputFileName = "unprotected.ppt";

        string password = "myPassword";



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        // Ensure output directory exists

        if (!Directory.Exists(outputDir))

        {

            Directory.CreateDirectory(outputDir);

        }



        try

        {

            // Load password‑protected presentation

            LoadOptions loadOptions = new LoadOptions();

            loadOptions.Password = password;

            Presentation presentation = new Presentation(inputPath, loadOptions);



            // Remove encryption if present

            if (presentation.ProtectionManager.IsEncrypted)

            {

                presentation.ProtectionManager.RemoveEncryption();

            }



            // Remove write protection if present

            if (presentation.ProtectionManager.IsWriteProtected)

            {

                presentation.ProtectionManager.RemoveWriteProtection();

            }



            // Save unprotected presentation as PPT

            string outputPath = Path.Combine(outputDir, outputFileName);

            presentation.Save(outputPath, SaveFormat.Ppt);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


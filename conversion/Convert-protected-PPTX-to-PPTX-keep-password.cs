// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert protected PPTX to PPTX keep password using C#

//

// Description:

// Demonstrates how to load a password‑protected PPTX file, re‑encrypt it with

// the same password, and save it as a new PPTX using Aspose.Slides for .NET.

// The example includes error handling for invalid passwords and unsupported

// formats, providing a ready‑to‑run console application.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, Protected, Password, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert a protected PPTX to another PPTX while preserving the password.

// - Build C# utilities for re‑encrypting or copying password‑protected presentations.

// - Automate batch processing of secured PowerPoint files in .NET applications.

// - Validate and maintain protection during presentation file transformations.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "protected.pptx";

        string outputPath = "output.pptx";

        string password = "myPassword";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        LoadOptions loadOptions = new LoadOptions();

        loadOptions.Password = password;



        try

        {

            using (Presentation presentation = new Presentation(inputPath, loadOptions))

            {

                // Re‑encrypt with the same password to retain protection

                presentation.ProtectionManager.Encrypt(password);

                presentation.Save(outputPath, SaveFormat.Pptx);

            }



            Console.WriteLine("Conversion completed successfully.");

        }

        catch (InvalidPasswordException)

        {

            Console.WriteLine("Invalid password provided for the input file.");

        }

        catch (PptxUnsupportedFormatException)

        {

            // format not supported

            Console.WriteLine("The file format is not supported for conversion.");

        }

        catch (NotSupportedException ex)

        {

            // e.g., trying to save encrypted file in unsupported format

            Console.WriteLine("Operation not supported: " + ex.Message);

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


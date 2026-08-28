// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert legacy PPT to PPTX with password using C#

//

// Description:

// Demonstrates how to convert a legacy PPT file to PPTX while handling password

// protection using C# and Aspose.Slides for .NET. The example checks whether the

// source presentation is password‑protected, loads it with the appropriate

// password, optionally re‑encrypts it, and saves the result as a PPTX file.

// This pattern can be used to automate secure conversion workflows in .NET

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PPT, Convert, Legacy, Pptx,

// Password, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of password‑protected legacy PPT files to PPTX.

// - Build C# utilities for secure PowerPoint presentation processing.

// - Integrate PPT to PPTX transformation into .NET applications with password handling.

// - Validate and preserve presentation protection during format migration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ConvertLegacyPpt

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input PPT file path

            string inputPath = "legacy.ppt";

            // Output directory and file name

            string outputDir = "Converted";

            string outputFileName = "converted.pptx";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Ensure output directory exists

            if (!Directory.Exists(outputDir))

                Directory.CreateDirectory(outputDir);



            // Full output path

            string outputPath = Path.Combine(outputDir, outputFileName);



            try

            {

                // Get presentation info to check for password protection

                IPresentationInfo presentationInfo = PresentationFactory.Instance.GetPresentationInfo(inputPath);

                bool isPasswordProtected = presentationInfo.IsPasswordProtected;



                // Placeholder password (replace with actual password if needed)

                string password = "your_password";



                Presentation presentation;



                if (isPasswordProtected)

                {

                    // Load with password

                    LoadOptions loadOptions = new LoadOptions();

                    loadOptions.Password = password;

                    presentation = new Presentation(inputPath, loadOptions);

                    // Re‑encrypt with the same password to preserve protection

                    presentation.ProtectionManager.Encrypt(password);

                }

                else

                {

                    // Load without password

                    presentation = new Presentation(inputPath);

                }



                // Save as PPTX

                presentation.Save(outputPath, SaveFormat.Pptx);

                presentation.Dispose();



                Console.WriteLine("Conversion completed successfully.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


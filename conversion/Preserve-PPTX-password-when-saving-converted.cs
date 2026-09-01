// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Preserve PPTX password when saving converted using C#

//

// Description:

// Demonstrates how to preserve PPTX password when saving converted using C# 

// and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Preserve, Pptx, Password, When, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate preserve PPTX password when saving converted.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace PreservePasswordExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Password for the source presentation (empty if not password‑protected)

            string password = "myPassword";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine($"Input file '{inputPath}' does not exist.");

                return;

            }



            // Prepare load options with password if needed

            LoadOptions loadOptions = new LoadOptions();

            if (!string.IsNullOrEmpty(password))

            {

                loadOptions.Password = password;

            }



            try

            {

                // Load the presentation (decrypted if password is provided)

                using (Presentation presentation = new Presentation(inputPath, loadOptions))

                {

                    // Re‑apply encryption to preserve the original password

                    if (!string.IsNullOrEmpty(password))

                    {

                        presentation.ProtectionManager.Encrypt(password);

                    }



                    // Save the presentation in PPTX format, preserving the password

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }



                Console.WriteLine($"Presentation saved successfully to '{outputPath}'.");

            }

            catch (NotSupportedException)

            {

                // The requested save format is not supported

                // Format not supported

                Console.WriteLine("The requested save format is not supported.");

            }

            catch (InvalidPasswordException)

            {

                // Incorrect password supplied for a protected presentation

                Console.WriteLine("Invalid password for the input presentation.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine($"An error occurred: {ex.Message}");

            }

        }

    }

}


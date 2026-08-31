// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load presentation with custom font to PDF using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation with a custom default

// regular font and convert it to PDF using Aspose.Slides for .NET. The example

// also shows how to save the presentation back to PPTX after processing.

// This pattern can be used to automate PPTX to PDF conversion while ensuring

// proper font fallback handling in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Load, Presentation,

// Custom Font, DefaultRegularFont, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to PDF with custom font fallback.

// - Build C# utilities for PowerPoint presentation processing with font control.

// - Ensure consistent rendering of presentations when the original fonts are missing.

// - Validate and test presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pdf";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Create LoadOptions and set a custom default regular font

                LoadOptions loadOptions = new LoadOptions();

                loadOptions.DefaultRegularFont = "Arial";



                // Load the presentation with the specified load options

                using (Presentation presentation = new Presentation(inputPath, loadOptions))

                {

                    // Render the presentation to PDF and save the result

                    presentation.Save(outputPath, SaveFormat.Pdf);



                    // Save the presentation back to PPTX (optional, demonstrates saving)

                    presentation.Save("temp_save.pptx", SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: The provided file format is not supported by Aspose.Slides.

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


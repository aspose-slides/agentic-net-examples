// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Remove embedded font and verify size decrease using C#

//

// Description:

// Demonstrates how to remove an embedded font from a PowerPoint presentation

// and verify that the file size decreases using Aspose.Slides for .NET. The

// example loads a PPTX file, removes a specified embedded font, saves the

// modified presentation, and compares the file sizes before and after the

// operation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove Embedded Font, Verify Size

// Decrease, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate removal of unnecessary embedded fonts to reduce PPTX size.

// - Build C# utilities for PowerPoint file optimization.

// - Validate that font removal impacts file size as expected.

// - Integrate font management into .NET presentation workflows.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace RemoveEmbeddedFontExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Load the presentation

            Presentation presentation = null;

            try

            {

                presentation = new Presentation(inputPath);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or loading errors

                Console.WriteLine("Failed to load presentation: " + ex.Message);

                return;

            }



            // Get all embedded fonts

            IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();



            // Specify the font name to remove

            string fontNameToRemove = "Arial";



            // Find the font data object matching the specified name

            IFontData fontToRemove = null;

            foreach (IFontData fontData in embeddedFonts)

            {

                if (fontData.FontName.Equals(fontNameToRemove, StringComparison.OrdinalIgnoreCase))

                {

                    fontToRemove = fontData;

                    break;

                }

            }



            // Remove the embedded font if found

            if (fontToRemove != null)

            {

                presentation.FontsManager.RemoveEmbeddedFont(fontToRemove);

                Console.WriteLine("Removed embedded font: " + fontNameToRemove);

            }

            else

            {

                Console.WriteLine("Embedded font not found: " + fontNameToRemove);

            }



            // Save the modified presentation

            try

            {

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle save errors (e.g., unsupported format)

                Console.WriteLine("Failed to save presentation: " + ex.Message);

                presentation.Dispose();

                return;

            }



            // Dispose the presentation object

            presentation.Dispose();



            // Verify that the file size decreased

            FileInfo beforeInfo = new FileInfo(inputPath);

            FileInfo afterInfo = new FileInfo(outputPath);

            Console.WriteLine("Size before removal: " + beforeInfo.Length + " bytes");

            Console.WriteLine("Size after removal: " + afterInfo.Length + " bytes");

            if (afterInfo.Length < beforeInfo.Length)

            {

                Console.WriteLine("Presentation size decreased after removing the font.");

            }

            else

            {

                Console.WriteLine("Presentation size did not decrease; the font may not have been embedded.");

            }

        }

    }

}


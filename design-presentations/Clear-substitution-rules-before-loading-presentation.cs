// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Clear substitution rules before loading presentation using C#

//

// Description:

// Demonstrates how to clear all font substitution rules before loading a

// PowerPoint presentation using Aspose.Slides for .NET. The example loads an

// existing PPTX file, removes any custom font substitution rules, and saves

// the presentation, ensuring that default font handling is used.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, Font Substitution, Clear Rules, Presentation Processing

//

// Use Cases:

// - Remove custom font substitution settings before processing a presentation.

// - Ensure default font rendering when loading PPTX files.

// - Prepare presentations for environments without specific font mappings.

// - Automate PowerPoint file cleanup in .NET applications.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ClearFontSubstitution

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Clear all font substitution rules

                    presentation.FontsManager.FontSubstRuleList = new FontSubstRuleCollection();



                    // Save the modified presentation

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (PptxUnsupportedFormatException)

            {

                // Format not supported

                // (Comment: The provided file format is not supported by Aspose.Slides.)

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}


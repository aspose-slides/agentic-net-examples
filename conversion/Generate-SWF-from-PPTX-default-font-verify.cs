// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Generate SWF from PPTX with default font verification using C#

//

// Description:

// Demonstrates how to load a PPTX file, list any font substitutions performed

// by Aspose.Slides, and save the presentation as an SWF file using default font

// substitution settings. The example uses Aspose.Slides for .NET and can be

// executed as a standalone console application. It is useful for developers

// who need to verify font handling when converting PowerPoint presentations to

// SWF format.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Font Substitution, Default Font,

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Verify font substitution information before converting PPTX to SWF.

// - Automate conversion of PowerPoint presentations to SWF with default fonts.

// - Build .NET tools for presentation processing and validation.

// - Ensure consistent font rendering in SWF output across different environments.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace GenerateSwf

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input PPTX file path

            string inputPath = "input.pptx";

            // Output SWF file path

            string outputPath = "output.swf";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Display default font substitution information

                    foreach (FontSubstitutionInfo substitutionInfo in presentation.FontsManager.GetSubstitutions())

                    {

                        Console.WriteLine(string.Format("{0} -> {1}", substitutionInfo.OriginalFontName, substitutionInfo.SubstitutedFontName));

                    }



                    // Create SWF options (default font substitution)

                    SwfOptions swfOptions = new SwfOptions();

                    // Example: set a default regular font if desired

                    // swfOptions.DefaultRegularFont = "Arial";



                    // Save the presentation as SWF

                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                }

            }

            catch (PptxUnsupportedFormatException ex)

            {

                // Handle unsupported file format

                Console.WriteLine("Unsupported file format: " + ex.Message);

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


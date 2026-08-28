// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPT with fallback font to SWF using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, apply a fallback font

// for missing glyphs, and convert the file to SWF format using Aspose.Slides for

// .NET. The example includes basic validation of the input file and error

// handling for unsupported formats.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, SWF, fallback font, presentation conversion,

// file I/O, exception handling

//

// Use Cases:

// - Convert existing PPTX presentations to SWF for web preview with a fallback font.

// - Automate batch conversion of PowerPoint files in .NET applications.

// - Ensure consistent rendering when original fonts are unavailable.

// - Integrate presentation conversion into custom tooling or services.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ConvertPptToSwf

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

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

                    // Configure SWF options with a fallback font

                    SwfOptions swfOptions = new SwfOptions();

                    swfOptions.DefaultRegularFont = "Arial"; // Fallback font name



                    // Save the presentation as SWF using the correct SaveFormat enum

                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);



                    // Save the presentation before exiting (as required by lifecycle rules)

                    presentation.Save("saved.pptx", SaveFormat.Pptx);

                }

            }

            catch (PptUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The specified file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


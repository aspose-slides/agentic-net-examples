// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load external truetype fonts into PPTX using C#

//

// Description:

// Demonstrates how to load external truetype fonts from a network folder into

// a PPTX file using C# and Aspose.Slides for .NET. The example shows how to

// configure LoadOptions with custom font folders, load a presentation, and

// save it after processing. This pattern can be used to ensure that

// presentations render correctly when custom fonts are required.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, External, Truetype,

// Fonts, Presentation Processing, Office Automation

//

// Use Cases:

// - Load presentations that rely on custom or network‑shared truetype fonts.

// - Build .NET tools that preprocess PPTX files with specific font resources.

// - Automate font handling in PowerPoint workflows to avoid missing‑font issues.

// - Validate and transform presentations before distribution or publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontLoadingExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Paths (adjust as needed)

            string inputPath = @"C:\Presentations\input.pptx";

            string outputPath = @"C:\Presentations\output.pptx";

            string networkFontFolder = @"\\networkshare\fonts";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Configure load options to include network font folder

                LoadOptions loadOptions = new LoadOptions();

                loadOptions.DocumentLevelFontSources.FontFolders = new string[] { networkFontFolder };



                // Load presentation with the specified font sources

                using (Presentation presentation = new Presentation(inputPath, loadOptions))

                {

                    // Perform any presentation manipulation here if needed



                    // Save the presentation before exiting

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


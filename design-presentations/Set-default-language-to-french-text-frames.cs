// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set default language to french text frames using C#

//

// Description:

// Demonstrates how to set the default language to French for text frames when

// loading a presentation using Aspose.Slides for .NET. The example loads an

// existing PPTX, applies the French language setting via LoadOptions, and

// saves the modified presentation. This pattern can be used to automate

// language localization in PowerPoint files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Default Language, French,

// Text Frames, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate setting default language to French for text frames in presentations.

// - Build C# utilities for PowerPoint localization workflows.

// - Generate or transform PPTX files with specific language settings in .NET

//   applications.

// - Validate language configuration before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SetDefaultLanguage

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output_french.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Configure load options to set the default text language to French

            LoadOptions loadOptions = new LoadOptions();

            loadOptions.DefaultTextLanguage = "fr-FR";



            // Load the presentation with the specified load options

            using (Presentation presentation = new Presentation(inputPath, loadOptions))

            {

                // Save the presentation; handle unsupported format exceptions

                try

                {

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                }

                catch (NotSupportedException)

                {

                    // Format not supported – handle accordingly

                    Console.WriteLine("The requested save format is not supported.");

                }

            }



            // Ensure the presentation is saved before exiting

            Console.WriteLine("Processing completed.");

        }

    }

}


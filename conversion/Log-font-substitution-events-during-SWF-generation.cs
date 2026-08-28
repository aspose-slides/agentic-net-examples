// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log font substitution events during SWF generation using C#

//

// Description:

// Demonstrates how to log font substitution events while converting a PowerPoint

// presentation (PPTX) to SWF format using Aspose.Slides for .NET. The example loads

// a presentation, enumerates any font substitutions performed by the library,

// outputs the substitution details to the console, and then saves the presentation

// as an SWF file.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Font Substitution, Events,

// Conversion, Presentation Processing, Office Automation

//

// Use Cases:

// - Track and log font substitutions that occur during PPTX to SWF conversion.

// - Build .NET tools for automated PowerPoint conversion workflows.

// - Validate font availability and substitution behavior before publishing.

// - Integrate font substitution logging into larger presentation processing pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontSubstitutionLogger

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputSwfPath = "output.swf";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            Aspose.Slides.Presentation presentation = null;

            try

            {

                // Load the presentation

                presentation = new Aspose.Slides.Presentation(inputPath);

            }

            catch (Exception ex)

            {

                // Handle loading exceptions (e.g., unsupported format)

                Console.WriteLine("Failed to load presentation: " + ex.Message);

                return;

            }



            try

            {

                // Log font substitution information

                foreach (Aspose.Slides.FontSubstitutionInfo substitution in presentation.FontsManager.GetSubstitutions())

                {

                    Console.WriteLine("Font substitution: {0} -> {1}", substitution.OriginalFontName, substitution.SubstitutedFontName);

                }



                // Configure SWF options (default options)

                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();



                // Save the presentation as SWF

                presentation.Save(outputSwfPath, SaveFormat.Swf, swfOptions);

            }

            catch (Exception ex)

            {

                // Handle exceptions related to SWF generation or saving

                Console.WriteLine("Error during SWF generation: " + ex.Message);

            }

            finally

            {

                // Ensure the presentation is saved before exit (optional, saves original PPTX)

                try

                {

                    string tempSavePath = "temp_saved.pptx";

                    presentation.Save(tempSavePath, SaveFormat.Pptx);

                }

                catch

                {

                    // Ignore any errors during the final save

                }



                // Dispose the presentation object

                if (presentation != null)

                {

                    presentation.Dispose();

                }

            }

        }

    }

}


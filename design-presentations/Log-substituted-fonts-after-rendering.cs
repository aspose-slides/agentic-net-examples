// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log substituted fonts after rendering using C#

//

// Description:

// Demonstrates how to log substituted fonts after rendering a presentation using

// C# and Aspose.Slides for .NET. The example loads a PPTX file, enumerates any

// font substitutions performed by the FontsManager, outputs the original and

// substituted font names to the console, and saves the presentation.

// This pattern helps developers audit font substitution during automated

// processing of PowerPoint files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Font Substitution, Logging,

// Rendering, Presentation Processing, Office Automation

//

// Use Cases:

// - Audit font substitutions after rendering a presentation.

// - Build tools that validate font usage in PPTX files.

// - Automate reporting of missing or substituted fonts in .NET applications.

// - Ensure visual fidelity before publishing or converting presentations.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontSubstitutionAudit

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



            try

            {

                // Load the presentation

                Presentation pres = new Presentation(inputPath);



                // Retrieve and log font substitution information

                foreach (FontSubstitutionInfo fontSubstitution in pres.FontsManager.GetSubstitutions())

                {

                    Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);

                }



                // Save the presentation before exiting

                pres.Save(outputPath, SaveFormat.Pptx);



                // Dispose the presentation object

                pres.Dispose();

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // If the format is not supported, you may log a specific comment here

                // Format not supported.

            }

        }

    }

}


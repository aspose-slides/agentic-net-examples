// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Confirm getsubstitution empty list with all fonts using C#

//

// Description:

// Demonstrates how to confirm that GetSubstitutions returns an empty list when

// all fonts used in a presentation are available. The example loads a PPTX file,

// checks the font substitution collection, reports the result, and saves the

// presentation using Aspose.Slides for .NET.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Confirm, GetSubstitutions, Empty,

// List, Font Substitution, Presentation Processing, Office Automation

//

// Use Cases:

// - Verify that no font substitutions are needed when all fonts are present.

// - Automate validation of font availability in PowerPoint files.

// - Integrate font substitution checks into .NET presentation workflows.

// - Ensure consistent rendering of slides across environments.

// -----------------------------------------------------------------------------

using System;

using System.Collections.Generic;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontSubstitutionTest

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation path

            string inputPath = "AllFontsAvailable.pptx";

            // Output presentation path

            string outputPath = "AllFontsAvailable_out.pptx";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                Presentation pres = new Presentation(inputPath);



                // Retrieve font substitutions

                IEnumerable<FontSubstitutionInfo> substitutions = pres.FontsManager.GetSubstitutions();



                // Check if the collection is empty

                bool hasSubstitutions = false;

                foreach (FontSubstitutionInfo substitution in substitutions)

                {

                    hasSubstitutions = true;

                    break;

                }



                if (!hasSubstitutions)

                {

                    Console.WriteLine("Test passed: No font substitutions were returned.");

                }

                else

                {

                    Console.WriteLine("Test failed: Font substitutions were found.");

                }



                // Save presentation before exit

                pres.Save(outputPath, SaveFormat.Pptx);

                pres.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., loading errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


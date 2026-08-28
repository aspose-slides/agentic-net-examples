// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log font substitution timestamps during conversion using C#

//

// Description:

// Demonstrates how to log font substitution timestamps while converting a

// PowerPoint presentation to PDF using Aspose.Slides for .NET. The example

// loads a PPTX file, enumerates font substitution information provided by the

// FontsManager, writes timestamped entries to the console, and then saves the

// presentation as a PDF.

//

// Keywords:

// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, Font Substitution, Timestamps,

// Conversion, Presentation Processing, Office Automation

//

// Use Cases:

// - Track which fonts are substituted during PPTX to PDF conversion.

// - Create audit logs for font usage in automated document pipelines.

// - Build .NET tools that validate font availability before publishing.

// - Diagnose rendering issues caused by missing fonts in presentations.

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

            string outputPath = "output.pdf";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Load the presentation and log font substitutions

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Iterate over font substitution information

                foreach (FontSubstitutionInfo substitution in presentation.FontsManager.GetSubstitutions())

                {

                    string logEntry = string.Format("{0:O}: Font substitution - {1} -> {2}",

                                                    DateTime.Now,

                                                    substitution.OriginalFontName,

                                                    substitution.SubstitutedFontName);

                    Console.WriteLine(logEntry);

                }



                // Attempt to save the presentation in PDF format

                try

                {

                    presentation.Save(outputPath, SaveFormat.Pdf);

                }

                catch (NotSupportedException)

                {

                    // Comment: format not supported

                    Console.WriteLine("The specified save format is not supported.");

                }

            }

        }

    }

}


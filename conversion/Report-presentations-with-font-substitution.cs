// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Report presentations with font substitution using C#

//

// Description:

// Demonstrates how to report presentations with font substitution using C# and 

// Aspose.Slides for .NET. The example loads each presentation, enumerates any 

// font substitutions applied by the FontsManager, outputs the mapping to the 

// console, and saves the file unchanged. This pattern helps developers audit 

// font usage and substitution in PowerPoint files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Report, Presentations, Font, 

// Substitution, FontsManager, Presentation Processing, Office Automation

//

// Use Cases:

// - Identify and log font substitutions in existing PowerPoint presentations.

// - Automate audit of font compatibility across multiple PPTX files.

// - Integrate font substitution reporting into .NET tools or CI pipelines.

// - Ensure presentation fidelity before publishing or conversion.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // List of presentation files to analyze

        string[] presentationPaths = new string[] { "Presentation1.pptx", "Presentation2.pptx" };



        foreach (string path in presentationPaths)

        {

            // Check if the file exists

            if (!File.Exists(path))

            {

                Console.WriteLine("File not found: " + path);

                continue;

            }



            try

            {

                // Load the presentation

                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(path);



                bool hasSubstitution = false;



                // Iterate over font substitutions

                foreach (Aspose.Slides.FontSubstitutionInfo substitution in pres.FontsManager.GetSubstitutions())

                {

                    if (!hasSubstitution)

                    {

                        Console.WriteLine("Font substitutions in " + path + ":");

                        hasSubstitution = true;

                    }

                    Console.WriteLine(substitution.OriginalFontName + " -> " + substitution.SubstitutedFontName);

                }



                if (!hasSubstitution)

                {

                    Console.WriteLine("No font substitutions in " + path + ".");

                }



                // Save the presentation before exiting (no changes made)

                pres.Save(path, Aspose.Slides.Export.SaveFormat.Pptx);

                pres.Dispose();

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("Error processing file " + path + ": " + ex.Message);

            }

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log font substitutions per slide to CSV using C#

//

// Description:

// Demonstrates how to log font substitutions for each slide in a PowerPoint

// presentation to a CSV file using C# and Aspose.Slides for .NET. The example

// loads a PPTX file, enumerates font substitutions per slide, writes the

// results to a CSV, and saves an unchanged copy of the presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Font Substitutions, CSV, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Generate a CSV report of font substitutions per slide for auditing.

// - Automate validation of font usage in PowerPoint files.

// - Integrate font substitution logging into .NET PowerPoint processing tools.

// - Ensure consistent typography across presentations before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputCsv = "font_substitutions.csv";



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load presentation

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);



            // Create CSV file and write header

            using (StreamWriter writer = new StreamWriter(outputCsv, false))

            {

                writer.WriteLine("SlideIndex,OriginalFont,SubstitutedFont");



                // Iterate through each slide (1‑based index)

                for (int slideIndex = 1; slideIndex <= pres.Slides.Count; slideIndex++)

                {

                    int[] targetSlides = new int[] { slideIndex };

                    foreach (Aspose.Slides.FontSubstitutionInfo fontSubstitution in pres.FontsManager.GetSubstitutions(targetSlides))

                    {

                        writer.WriteLine(slideIndex + "," + fontSubstitution.OriginalFontName + "," + fontSubstitution.SubstitutedFontName);

                    }

                }

            }



            // Save presentation before exit (no modifications made)

            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            pres.Dispose();

        }

        catch (Exception ex)

        {

            // If the format is not supported, Aspose.Slides may throw an exception

            // Format not supported

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


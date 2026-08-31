// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Map multiple original fonts to a single replacement using C#

//

// Description:

// Demonstrates how to map several original fonts to one replacement font using

// C# and Aspose.Slides for .NET. The example loads a PPTX file, creates font

// substitution rules for each source font, applies them to the presentation,

// and saves the result. This pattern helps automate font consistency across

// PowerPoint files in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Multiple Original Fonts, Font

// Replacement, Font Substitution, Presentation Processing, Office Automation

//

// Use Cases:

// - Ensure consistent font usage by replacing multiple fonts with a single one.

// - Build C# tools for batch processing of PowerPoint presentations.

// - Integrate font substitution logic into .NET applications.

// - Prepare presentations for environments with limited font availability.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Original fonts to be replaced

                string[] sourceFonts = new string[] { "Arial", "Calibri", "Times New Roman" };

                // Single replacement font

                string replacementFont = "Verdana";



                // Create a collection of substitution rules

                IFontSubstRuleCollection substRules = new FontSubstRuleCollection();



                foreach (string src in sourceFonts)

                {

                    IFontData sourceFontData = new FontData(src);

                    IFontData destFontData = new FontData(replacementFont);

                    FontSubstRule rule = new FontSubstRule(sourceFontData, destFontData, FontSubstCondition.Always);

                    substRules.Add(rule);

                }



                // Apply the substitution rules to the presentation

                presentation.FontsManager.FontSubstRuleList = substRules;



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (PptxUnsupportedFormatException)

        {

            // Format not supported

            Console.WriteLine("The presentation format is not supported.");

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


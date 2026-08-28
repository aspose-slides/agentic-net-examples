// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Detect missing fonts during conversion and substitute using C#

//

// Description:

// Demonstrates how to detect missing fonts during conversion and substitute 

// them using Aspose.Slides for .NET. The example loads a presentation, defines 

// a substitution rule for an inaccessible source font, applies the rule via 

// the FontsManager, and saves the updated presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect, Missing, Fonts, 

// Substitution, Presentation Processing, Office Automation

//

// Use Cases:

// - Detect missing fonts in a PowerPoint file and replace them automatically.

// - Build .NET tools that ensure font consistency during PPTX conversion.

// - Automate font substitution in batch processing of presentations.

// - Prevent rendering issues caused by unavailable fonts in generated slides.

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

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            Presentation presentation = new Presentation(inputPath);



            // Define source (missing) and destination fonts

            IFontData sourceFont = new FontData("Calibri");

            IFontData destFont = new FontData("Arial");



            // Create a substitution rule that applies when the source font is inaccessible

            FontSubstRule substitutionRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);



            // Add the rule to a collection and assign it to the FontsManager

            FontSubstRuleCollection ruleCollection = new FontSubstRuleCollection();

            ruleCollection.Add(substitutionRule);

            presentation.FontsManager.FontSubstRuleList = ruleCollection;



            // Save the presentation

            presentation.Save(outputPath, SaveFormat.Pptx);



            // Clean up

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The presentation format is not supported.");

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


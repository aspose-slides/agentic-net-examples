// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply japanese fallback font mincho using C#

//

// Description:

// Demonstrates how to apply japanese fallback font mincho using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Japanese, Fallback, 

// Font, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate apply japanese fallback font mincho.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Paths for input and output presentations

        var inputPath = "input.pptx";

        var outputPath = "output.pptx";



        try

        {

            // Load existing presentation if it exists; otherwise create a new one

            var pres = File.Exists(inputPath) ? new Presentation(inputPath) : new Presentation();



            // Define a fallback rule for Japanese characters (Unicode range 0x3040–0x30FF) using "MS Mincho"

            var rule = new FontFallBackRule(0x3040, 0x30FF, "MS Mincho");



            // Create a collection, add the rule, and assign it to the presentation's FontsManager

            var rules = new FontFallBackRulesCollection();

            rules.Add(rule);

            pres.FontsManager.FontFallBackRulesCollection = rules;



            // Save the presentation

            pres.Save(outputPath, SaveFormat.Pptx);

            pres.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception)

        {

            // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)

        }

    }

}


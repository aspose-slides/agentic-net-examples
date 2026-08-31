// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Clear fallback rules and save PPTX using C#

//

// Description:

// Demonstrates how to clear all font fallback rules in a presentation and

// save the modified PPTX using Aspose.Slides for .NET. The example loads an

// existing PPTX file, resets the FontFallBackRulesCollection, and writes the

// result to a new file. This pattern is useful for preparing presentations

// for environments where custom font fallback is not required.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clear, Font Fallback, Rules, Save, Presentation Processing, Office Automation

//

// Use Cases:

// - Remove custom font fallback configurations from a PPTX.

// - Prepare presentations for distribution without fallback rules.

// - Automate PPTX cleanup in .NET applications.

// - Integrate font fallback management into PowerPoint processing pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        var inputPath = "input.pptx";

        var outputPath = "output.pptx";



        // Check if the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            var pres = new Presentation(inputPath);



            // Clear all font fallback rules

            pres.FontsManager.FontFallBackRulesCollection = new FontFallBackRulesCollection();



            // Save the presentation

            pres.Save(outputPath, SaveFormat.Pptx);



            // Dispose the presentation

            pres.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception)

        {

            // Handle other exceptions

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Replace placeholder text with dynamic values using C#

//

// Description:

// Demonstrates how to replace a placeholder string (e.g., "[Name]") with a

// dynamic value (e.g., "John Doe") in a PowerPoint presentation using

// Aspose.Slides for .NET. The example loads a PPTX file, performs a global

// find‑and‑replace across all slides (including master slides), and saves the

// result.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace Placeholder, Text

// Replacement, Presentation Automation, Office Automation

//

// Use Cases:

// - Automate personalization of PPTX templates by inserting user‑specific data.

// - Build .NET utilities that modify slide content before distribution.

// - Integrate dynamic text replacement into reporting or marketing workflows.

// - Validate and test slide text transformations in CI pipelines.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        // Placeholder text to find and its replacement

        string placeholderToFind = "[Name]";

        string replacementText = "John Doe";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                // Replace placeholder text across all slides (including master slides)

                Aspose.Slides.Util.SlideUtil.FindAndReplaceText(presentation, true, placeholderToFind, replacementText, null);



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


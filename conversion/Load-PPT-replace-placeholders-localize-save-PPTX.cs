// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load PPT replace placeholders localize save PPTX using C#

//

// Description:

// Demonstrates how to load a PPTX file, replace placeholder text on the first

// slide with localized content, and save the modified presentation using

// Aspose.Slides for .NET. The example includes file existence checking,

// placeholder detection, text replacement, and proper resource disposal.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Replace, Placeholders,

// Localize, Presentation Processing, Office Automation, Save

//

// Use Cases:

// - Automate localization of PowerPoint presentations by replacing placeholders.

// - Build .NET tools for batch processing and updating PPTX files.

// - Integrate presentation text updates into larger applications or workflows.

// - Validate and test placeholder handling before publishing presentations.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Replace placeholder text on the first slide

            Aspose.Slides.ISlide slide = presentation.Slides[0];

            foreach (Aspose.Slides.IShape shape in slide.Shapes)

            {

                if (shape.Placeholder != null)

                {

                    ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = "Localized Text";

                }

            }



            // Save the modified presentation as PPTX

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);



            // Dispose the presentation

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // Handle errors such as unsupported format or other processing issues

            Console.WriteLine("Error processing presentation: " + ex.Message);

        }

    }

}


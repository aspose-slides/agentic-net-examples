// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set PPTX notes background color using C#

//

// Description:

// Demonstrates how to set the background color of the notes master slide in a

// PPTX file using C# and Aspose.Slides for .NET. The example loads an existing

// presentation, ensures a notes master slide exists, applies a solid light blue

// background to the notes master, and saves the modified presentation. This

// pattern can be used to customize note slide appearance programmatically.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Notes Master, Background Color,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate setting a custom background color for notes pages in PPTX files.

// - Build .NET tools that standardize the appearance of PowerPoint notes.

// - Integrate notes styling into presentation generation workflows.

// - Ensure consistent branding across notes sections of presentations.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



class Program

{

    static void Main(string[] args)

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

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Get or create the master notes slide

                IMasterNotesSlide masterNotes = presentation.MasterNotesSlideManager.MasterNotesSlide;

                if (masterNotes == null)

                {

                    masterNotes = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();

                }



                // Apply a custom solid background color to the notes master

                masterNotes.Background.Type = BackgroundType.OwnBackground;

                masterNotes.Background.FillFormat.FillType = FillType.Solid;

                masterNotes.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Adjust master slide background transparency half using C#

//

// Description:

// Demonstrates how to adjust the master slide background transparency to 50%

// using C# and Aspose.Slides for .NET. The example loads an existing PPTX,

// modifies the first master slide's background to a semi‑transparent solid fill,

// and saves the result as a new PPTX file. This pattern can be used to

// automate PowerPoint presentation processing, validate visual changes, or

// integrate slide styling logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Adjust, Master Slide, Background,

// Transparency, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate setting master slide background transparency to half opacity.

// - Build C# utilities for PowerPoint presentation styling.

// - Generate or transform PPTX files with custom master slide designs.

// - Validate presentation appearance before distribution or publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



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

                // Access the first master slide

                IMasterSlide masterSlide = presentation.Masters[0];



                // Set the background to use its own fill

                masterSlide.Background.Type = BackgroundType.OwnBackground;



                // Use a solid fill with 50% transparency (alpha = 128)

                masterSlide.Background.FillFormat.FillType = FillType.Solid;

                masterSlide.Background.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 255, 255, 255);



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The specified format is not supported.");

        }

        catch (Exception ex)

        {

            // Handle other possible exceptions (e.g., network errors)

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


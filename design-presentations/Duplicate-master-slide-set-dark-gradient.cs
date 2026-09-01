// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Duplicate master slide set dark gradient using C#

//

// Description:

// Demonstrates how to duplicate a master slide and apply a dark gradient background

// using C# and Aspose.Slides for .NET. The example loads an existing PPTX file,

// clones the first master slide, modifies the cloned master’s background to a dark

// gradient, and saves the result as a new presentation. This pattern can be used

// to programmatically extend slide master collections and customize their appearance.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Duplicate, Master Slide, Dark Gradient,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate duplication of master slides with custom gradient backgrounds.

// - Build .NET tools for enhancing PowerPoint master slide designs.

// - Generate or modify PPTX files with specific visual themes in batch processes.

// - Validate and preview master slide changes before publishing presentations.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesDemo

{

    class Program

    {

        static void Main(string[] args)

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

                // Load the presentation

                Presentation pres = new Presentation(inputPath);



                // Get the first master slide

                IMasterSlide sourceMaster = pres.Masters[0];



                // Clone the master slide and insert at the end of the masters collection

                IMasterSlide clonedMaster = pres.Masters.InsertClone(pres.Masters.Count, sourceMaster);



                // Modify the cloned master background to a dark gradient

                clonedMaster.Background.Type = BackgroundType.OwnBackground;

                clonedMaster.Background.FillFormat.FillType = FillType.Gradient;

                clonedMaster.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;



                // Save the presentation

                pres.Save(outputPath, SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


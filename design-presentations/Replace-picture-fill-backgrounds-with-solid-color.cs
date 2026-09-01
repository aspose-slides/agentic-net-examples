// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Replace picture fill backgrounds with solid color using C#

//

// Description:

// Demonstrates how to replace picture fill backgrounds with a solid color using 

// C# and Aspose.Slides for .NET. The example loads a PPTX file, iterates through 

// each slide, checks for picture fill backgrounds, and replaces them with a 

// LightGray solid fill. The modified presentation is then saved as a new file.

// This pattern can be used to standardize slide backgrounds in automated 

// PowerPoint processing workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Picture Fill, Solid Fill, 

// Backgrounds, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of picture-filled slide backgrounds to solid colors.

// - Ensure consistent background styling across presentations.

// - Build C# tools for PowerPoint presentation cleanup or rebranding.

// - Integrate background normalization into .NET applications handling PPTX files.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;

using System.Drawing;



namespace SlideBackgroundProcessor

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

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



                // Iterate through each slide

                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    // Access the slide background

                    Aspose.Slides.IBackground background = presentation.Slides[i].Background;



                    // Ensure the background is set to own background to allow modifications

                    background.Type = Aspose.Slides.BackgroundType.OwnBackground;



                    // Check if the background uses a picture fill

                    if (background.FillFormat.FillType == Aspose.Slides.FillType.Picture)

                    {

                        // Replace picture fill with a solid color (LightGray)

                        background.FillFormat.FillType = Aspose.Slides.FillType.Solid;

                        background.FillFormat.SolidFillColor.Color = Color.LightGray;

                    }

                }



                // Save the modified presentation

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other processing errors

                Console.WriteLine("Error processing presentation: " + ex.Message);

            }

        }

    }

}


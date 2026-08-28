// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Pause animations after each step until click using C#

//

// Description:

// Demonstrates how to set each animation effect in a PowerPoint presentation

// to pause until the next mouse click using Aspose.Slides for .NET. The program

// loads an existing PPTX file, updates the AfterAnimationType of all effects

// to HideOnNextMouseClick, and saves the modified presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Pause Animations, AfterAnimationType, HideOnNextMouseClick, Presentation Processing

//

// Use Cases:

// - Modify existing presentations to require a click between animation steps.

// - Automate preparation of slide decks for interactive delivery.

// - Integrate animation pause settings into .NET based PowerPoint tooling.

// - Ensure consistent click‑to‑advance behavior across all slides.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Animation;

using Aspose.Slides.Export;



namespace PauseAnimationsExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Iterate through each slide and set each effect to pause until next mouse click

                foreach (ISlide slide in presentation.Slides)

                {

                    ISequence mainSequence = slide.Timeline.MainSequence;

                    foreach (IEffect effect in mainSequence)

                    {

                        effect.AfterAnimationType = AfterAnimationType.HideOnNextMouseClick;

                    }

                }



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

                presentation.Dispose();



                Console.WriteLine("Presentation saved successfully to: " + outputPath);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // Format not supported comment

                // Note: If the exception is due to an unsupported file format, it will be caught here.

            }

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Remove exit animations keep entrance effects using C#

//

// Description:

// Demonstrates how to remove exit animations while keeping entrance effects using C# 

// and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Exit, Animations, Keep, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate removal of exit animations while preserving entrance effects.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Animation;

using Aspose.Slides.Export;



namespace RemoveExitAnimations

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation pres = new Presentation(inputPath);



                // Iterate through each slide

                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)

                {

                    // Get the main animation sequence of the slide

                    ISequence mainSeq = pres.Slides[slideIndex].Timeline.MainSequence;



                    // Iterate through each effect in the sequence

                    for (int effectIndex = 0; effectIndex < mainSeq.Count; effectIndex++)

                    {

                        IEffect effect = mainSeq[effectIndex];



                        // If the effect is an exit animation, remove it.

                        // Here we consider an exit animation as one whose AfterAnimationType is HideAfterAnimation.

                        if (effect.AfterAnimationType == AfterAnimationType.HideAfterAnimation)

                        {

                            // Remove the effect from the sequence

                            mainSeq.Remove(effect);

                            // Adjust the index after removal

                            effectIndex--;

                        }

                    }

                }



                // Save the modified presentation

                pres.Save(outputPath, SaveFormat.Pptx);

                pres.Dispose();



                Console.WriteLine("Presentation saved to: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., web service errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


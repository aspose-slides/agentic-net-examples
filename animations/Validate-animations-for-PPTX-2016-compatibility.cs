// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate animations for PPTX 2016 compatibility using C#

//

// Description:

// Demonstrates how to validate animations for PPTX 2016 compatibility using C# 

// and Aspose.Slides for .NET. The example iterates through each slide's 

// animation timeline, enumerates the main sequence effects, and outputs their 

// types, providing a basis for further compatibility checks.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Animations, Pptx, 

// 2016, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate validation of slide animations for PPTX 2016 compatibility.

// - Build C# tools for PowerPoint presentation analysis.

// - Integrate animation checks into .NET applications or CI pipelines.

// - Generate reports on animation types before publishing presentations.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Animation;



class Program

{

    static void Main()

    {

        // Input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Iterate through all slides

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

                {

                    // Get the animation timeline for the current slide

                    IAnimationTimeLine timeline = presentation.Slides[slideIndex].Timeline;



                    // Retrieve the main sequence (collection of effects)

                    ISequence mainSequence = timeline.MainSequence;



                    // Validate each effect in the main sequence

                    for (int effectIndex = 0; effectIndex < mainSequence.Count; effectIndex++)

                    {

                        IEffect effect = mainSequence[effectIndex];



                        // Example validation logic:

                        // Here we simply output the effect type; replace with actual PPTX 2016 compatibility checks as needed.

                        Console.WriteLine("Slide " + (slideIndex + 1) + ", Effect " + (effectIndex + 1) + ": Type = " + effect.Type);

                    }

                }



                // Save the (potentially modified) presentation before exiting

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (PptxUnsupportedFormatException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


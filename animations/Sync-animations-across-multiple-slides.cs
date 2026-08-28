// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Sync animations across multiple slides using C#

//

// Description:

// Demonstrates how to synchronize animations across multiple slides in a PowerPoint

// presentation using C# and Aspose.Slides for .NET. The example sets the first

// animation effect on each slide to repeat until the end of the slide, configures

// subsequent slides to stop any previously playing sound, and shows how to hook

// into the animation generation events to obtain total animation duration.

// This pattern can be used to automate PPTX workflows that require coordinated

// animation timing and sound handling.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Sync, Animations, Multiple Slides,

// Timeline, Effects, Sound, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate synchronization of slide animations across a presentation.

// - Ensure continuous animation loops until slide transition.

// - Manage sound playback across slide boundaries.

// - Generate logs or metrics for animation durations.

// - Integrate animation control into .NET applications handling PPTX files.

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



        // Verify input file exists

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

                // Set each slide's first effect to repeat until the end of the slide

                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    ISequence sequence = presentation.Slides[i].Timeline.MainSequence;

                    if (sequence.Count > 0)

                    {

                        IEffect effect = sequence[0];

                        effect.Timing.RepeatUntilEndSlide = true;

                    }

                }



                // Ensure subsequent slide effects stop previous sound if present

                for (int i = 1; i < presentation.Slides.Count; i++)

                {

                    IEffect previousEffect = presentation.Slides[i - 1].Timeline.MainSequence[0];

                    IEffect currentEffect = presentation.Slides[i].Timeline.MainSequence[0];

                    if (previousEffect != null && previousEffect.Sound != null)

                    {

                        currentEffect.StopPreviousSound = true;

                    }

                }



                // Generate animation events (optional demonstration)

                using (PresentationAnimationsGenerator generator = new PresentationAnimationsGenerator(presentation))

                {

                    generator.NewAnimation += player =>

                    {

                        Console.WriteLine($"Animation total duration: {player.Duration} ms");

                    };

                    generator.Run(presentation.Slides);

                }



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other processing errors

            Console.WriteLine($"Error processing presentation: {ex.Message}");

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export animation timeline to CSV using C#

//

// Description:

// Demonstrates how to export the animation timeline of a PowerPoint presentation

// to a CSV file using C# and Aspose.Slides for .NET. The example loads a PPTX,

// iterates through each slide's animation sequence, extracts effect details such

// as type, subtype, trigger, and duration, writes them to a CSV, and saves the

// presentation. This pattern helps automate analysis of slide animations.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Animation, Timeline, CSV,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Analyze or audit animation effects across slides.

// - Generate reports of animation sequences for review or documentation.

// - Integrate animation data extraction into .NET tools or CI pipelines.

// - Convert animation metadata into CSV for further processing or visualization.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Animation;

using Aspose.Slides.Export;



namespace ExportAnimationTimeline

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputCsv = "animation_timeline.csv";

            string outputPptx = "output_saved.pptx";



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

                    // Create CSV file for exporting animation data

                    using (StreamWriter writer = new StreamWriter(outputCsv, false))

                    {

                        // CSV header

                        writer.WriteLine("SlideIndex,EffectIndex,EffectType,EffectSubtype,TriggerType,Duration");



                        // Iterate through slides

                        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

                        {

                            IAnimationTimeLine timeline = presentation.Slides[slideIndex].Timeline;

                            ISequence mainSequence = timeline.MainSequence;



                            // Iterate through effects in the main sequence

                            for (int effectIndex = 0; effectIndex < mainSequence.Count; effectIndex++)

                            {

                                IEffect effect = mainSequence[effectIndex];

                                EffectType effectType = effect.Type;

                                EffectSubtype effectSubtype = effect.Subtype;



                                // Default trigger type

                                EffectTriggerType triggerType = EffectTriggerType.AfterPrevious;

                                // Retrieve actual trigger type from timing if available

                                if (effect.Timing != null)

                                {

                                    triggerType = effect.Timing.TriggerType;

                                }



                                // Retrieve duration from timing if available

                                float duration = 0;

                                if (effect.Timing != null)

                                {

                                    duration = effect.Timing.Duration;

                                }



                                // Write effect data to CSV

                                writer.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}",

                                    slideIndex,

                                    effectIndex,

                                    effectType,

                                    effectSubtype,

                                    triggerType,

                                    duration));

                            }

                        }

                    }



                    // Save the presentation before exiting (required by rule)

                    presentation.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URLs or I/O errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


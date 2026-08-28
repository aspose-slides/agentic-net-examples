// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Detect unsupported animation effects for legacy PPTX using C#

//

// Description:

// Demonstrates how to detect animation effects that are not supported in older

// PowerPoint versions within a PPTX file using C# and Aspose.Slides for .NET.

// The example loads a presentation, scans each slide's main animation sequence

// for specific unsupported effects, reports their locations, and saves the

// presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect, Unsupported, Animation,

// Effects, Presentation Processing, Office Automation

//

// Use Cases:

// - Identify legacy‑incompatible animation effects in PPTX files.

// - Automate validation of presentations before distribution to older PowerPoint versions.

// - Integrate animation compatibility checks into .NET build or CI pipelines.

// - Generate reports of unsupported animations for content remediation.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;

using Aspose.Slides.Animation;



class Program

{

    static void Main()

    {

        // Define input and output file paths

        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");



        // Check if the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the presentation

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                // List of animation effects that are not supported in older PowerPoint versions

                Aspose.Slides.Animation.EffectType[] unsupportedEffects = new Aspose.Slides.Animation.EffectType[]

                {

                    Aspose.Slides.Animation.EffectType.FadedZoom,

                    Aspose.Slides.Animation.EffectType.PathUser,

                    Aspose.Slides.Animation.EffectType.PathFootball

                };



                // Iterate through all slides and their main sequence effects

                foreach (Aspose.Slides.ISlide slide in presentation.Slides)

                {

                    Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;

                    for (int i = 0; i < mainSequence.Count; i++)

                    {

                        Aspose.Slides.Animation.IEffect effect = mainSequence[i];

                        foreach (Aspose.Slides.Animation.EffectType unsupported in unsupportedEffects)

                        {

                            if (effect.Type == unsupported)

                            {

                                Console.WriteLine("Unsupported effect " + unsupported.ToString() + " found on slide " + slide.SlideNumber);

                            }

                        }

                    }

                }



                // Save the presentation before exiting

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (Exception ex)

        {

            // Handle exceptions (e.g., unsupported file format)

            // Comment: format not supported

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


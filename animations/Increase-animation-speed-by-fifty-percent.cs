// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Increase animation speed by fifty percent using C#

//

// Description:

// Demonstrates how to increase the speed of all slide animations by fifty

// percent using C# and Aspose.Slides for .NET. The example processes each

// presentation file in an input folder, modifies the timing of both main

// sequence and interactive sequence effects, and saves the updated files to an

// output folder.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Increase, Animation, Speed,

// Fifty Percent, Presentation Processing, Office Automation

//

// Use Cases:

// - Batch accelerate animation playback in multiple PowerPoint files.

// - Create tools that adjust animation timing for faster presentations.

// - Integrate animation speed adjustments into .NET automation pipelines.

// - Prepare PPTX files for time‑constrained presentations or demos.

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

        // Define input and output directories

        string inputDir = "InputPresentations";

        string outputDir = "OutputPresentations";



        // Verify input directory exists

        if (!Directory.Exists(inputDir))

        {

            Console.WriteLine("Input directory does not exist: " + inputDir);

            return;

        }



        // Ensure output directory exists

        Directory.CreateDirectory(outputDir);



        // Process each file in the input directory

        string[] files = Directory.GetFiles(inputDir);

        foreach (string filePath in files)

        {

            try

            {

                // Load presentation

                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath))

                {

                    // Iterate through slides

                    foreach (Aspose.Slides.ISlide slide in pres.Slides)

                    {

                        // Increase speed for main sequence effects

                        Aspose.Slides.Animation.ISequence mainSeq = slide.Timeline.MainSequence;

                        for (int i = 0; i < mainSeq.Count; i++)

                        {

                            Aspose.Slides.Animation.IEffect effect = mainSeq[i];

                            effect.Timing.Speed = effect.Timing.Speed * 1.5f;

                        }



                        // Increase speed for interactive sequence effects

                        foreach (Aspose.Slides.Animation.ISequence interactiveSeq in slide.Timeline.InteractiveSequences)

                        {

                            for (int i = 0; i < interactiveSeq.Count; i++)

                            {

                                Aspose.Slides.Animation.IEffect effect = interactiveSeq[i];

                                effect.Timing.Speed = effect.Timing.Speed * 1.5f;

                            }

                        }

                    }



                    // Save modified presentation

                    string fileName = Path.GetFileNameWithoutExtension(filePath);

                    string outputPath = Path.Combine(outputDir, fileName + "_fast.pptx");

                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("File format not supported: " + filePath);

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine("Error processing file '" + filePath + "': " + ex.Message);

            }

        }

    }

}


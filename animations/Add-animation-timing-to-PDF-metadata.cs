// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add animation timing to PDF metadata using C#

//

// Description:

// Demonstrates how to calculate total animation duration for each slide in a

// PowerPoint presentation, store the durations as custom document properties,

// and save the presentation as a PDF using Aspose.Slides for .NET. This example

// shows the required steps for extracting animation timing, updating metadata,

// and exporting to PDF in a standalone console application.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Animation, Timing,

// Metadata, Presentation Processing, Office Automation

//

// Use Cases:

// - Extract slide animation timings and embed them into PDF metadata.

// - Automate PowerPoint to PDF conversion while preserving custom properties.

// - Build .NET tools for presentation analysis and reporting.

// - Validate animation sequences before publishing presentations.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Animation;



namespace AddAnimationTimingToPdfMetadata

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.pdf";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine($"Input file not found: {inputPath}");

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Iterate through each slide to collect animation timing

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        // Get the animation timeline for the slide

                        IAnimationTimeLine timeline = presentation.Slides[i].Timeline;



                        // Main sequence contains the main effects

                        ISequence mainSequence = timeline.MainSequence;



                        double totalDuration = 0.0;



                        // Sum the duration of each effect's timing

                        foreach (IEffect effect in mainSequence)

                        {

                            ITiming timing = effect.Timing;

                            if (timing != null)

                            {

                                totalDuration += timing.Duration;

                            }

                        }



                        // Store the total duration as a custom property

                        presentation.DocumentProperties.SetCustomPropertyValue($"Slide{i + 1}Duration", totalDuration);

                    }



                    // Save the presentation as PDF with default options

                    PdfOptions pdfOptions = new PdfOptions();

                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);

                }

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                // Format not supported: comment for clarity

                Console.WriteLine($"Error: {ex.Message}");

            }

        }

    }

}


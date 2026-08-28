// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Log animation types and shape names using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, iterate through each slide,

// enumerate the main animation sequence, and log each effect's type together with

// the name of its target shape. The example also shows how to save the presentation

// after processing using Aspose.Slides for .NET. This pattern can be used to audit

// or analyze animations in PPTX files.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, Animation, EffectType, Shape, Logging,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Audit animation effects and associated shapes in existing presentations.

// - Build tools that generate reports on slide animations.

// - Validate animation sequences before publishing.

// - Integrate animation analysis into .NET applications.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Animation;



namespace AnimationLogger

{

    class Program

    {

        static void Main(string[] args)

        {

            // Path to the input presentation

            string inputPath = "input.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Presentation presentation = new Presentation(inputPath);



                // Iterate through all slides

                foreach (ISlide slide in presentation.Slides)

                {

                    // Get the main animation sequence of the slide

                    ISequence mainSequence = slide.Timeline.MainSequence;



                    // Iterate through each effect in the main sequence

                    foreach (IEffect effect in mainSequence)

                    {

                        // Retrieve the effect type

                        EffectType effectType = effect.Type;



                        // Retrieve the target shape (if any) and its name

                        IShape targetShape = effect.TargetShape;

                        string shapeName = targetShape != null ? targetShape.Name : "None";



                        // Log the effect type and associated shape name

                        Console.WriteLine($"Slide {slide.SlideNumber}: Effect Type = {effectType}, Shape = {shapeName}");

                    }

                }



                // Save the presentation before exiting

                string outputPath = "output.pptx";

                presentation.Save(outputPath, SaveFormat.Pptx);

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}


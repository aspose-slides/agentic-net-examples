// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add drop shadow to picture shapes using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, iterate through its

// slides and picture shapes, apply a preset drop shadow effect to each picture

// shape, and save the modified presentation using Aspose.Slides for .NET.

// This console application can be used to automate the addition of drop

// shadows to pictures in PPTX files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Drop Shadow, Picture Shapes,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automatically add drop shadows to all picture shapes in a presentation.

// - Integrate picture styling into .NET PowerPoint processing pipelines.

// - Prepare PPTX files with consistent visual effects before distribution.

// - Validate and transform presentations in batch operations.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ApplyDropShadowToPictures

{

    class Program

    {

        static void Main(string[] args)

        {

            // Expect input and output file paths as arguments

            if (args.Length < 2)

            {

                Console.WriteLine("Usage: ApplyDropShadowToPictures <input.pptx> <output.pptx>");

                return;

            }



            string inputPath = args[0];

            string outputPath = args[1];



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // Iterate through all slides

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

                {

                    ISlide slide = presentation.Slides[slideIndex];



                    // Iterate through all shapes on the slide

                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)

                    {

                        IPictureFrame pictureFrame = slide.Shapes[shapeIndex] as IPictureFrame;

                        if (pictureFrame != null)

                        {

                            // Apply preset drop shadow effect

                            pictureFrame.EffectFormat.EnablePresetShadowEffect();

                        }

                    }

                }



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

                // If the format is not supported, comment accordingly

                // Format not supported.

            }

        }

    }

}


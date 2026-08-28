// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add fade out animation to images using C#

//

// Description:

// Demonstrates how to add a fade‑out exit animation to picture frames (images) 

// in a PowerPoint presentation using C# and Aspose.Slides for .NET. The example 

// loads an existing PPTX file, iterates through its slides and shapes, applies a 

// fade‑out effect to each image, sets the animation duration, and saves the 

// modified presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Fade, Animation, Images, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate adding fade‑out animations to images in PPTX files.

// - Build .NET tools for PowerPoint presentation enhancement.

// - Generate or transform PPTX files with custom animation effects.

// - Validate and preview presentation workflows before publishing.

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

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        // Verify that the input file exists

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

                // Iterate through all slides

                foreach (ISlide slide in presentation.Slides)

                {

                    // Iterate through all shapes on the slide

                    foreach (IShape shape in slide.Shapes)

                    {

                        // Identify picture frames (images)

                        IPictureFrame picture = shape as IPictureFrame;

                        if (picture != null)

                        {

                            // Add a fade‑out exit animation to the image

                            IEffect effect = slide.Timeline.MainSequence.AddEffect(

                                picture,

                                EffectType.Fade,

                                EffectSubtype.None,

                                EffectTriggerType.AfterPrevious);



                            // Set the animation duration to 2 seconds (2000 ms)

                            effect.Timing.Duration = 2000;

                        }

                    }

                }



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., external URLs or I/O errors)

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


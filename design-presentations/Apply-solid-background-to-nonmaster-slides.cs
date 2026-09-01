// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply solid background to nonmaster slides using C#

//

// Description:

// Demonstrates how to apply a solid LightGray background to slides that inherit

// their background from the master slide. The example iterates through all

// slides in a newly created presentation, changes the background type to

// OwnBackground where necessary, sets the fill type to solid, and assigns a

// LightGray color using Aspose.Slides for .NET. The resulting presentation is

// saved as OutputPresentation.pptx.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, Apply Solid Background, Non-Master Slides,

// Presentation Processing, Office Automation, Background Fill

//

// Use Cases:

// - Automatically apply a uniform solid background to all non‑master slides.

// - Prepare presentations with consistent slide backgrounds in batch processes.

// - Integrate background styling into .NET applications that generate PPTX files.

// - Ensure slides have explicit backgrounds before publishing or further editing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



namespace ApplySolidBackground

{

    class Program

    {

        static void Main(string[] args)

        {

            // Create a new presentation

            using (Presentation presentation = new Presentation())

            {

                // Iterate through all slides

                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    ISlide slide = presentation.Slides[i];



                    // If the slide does not have its own background (inherits from master)

                    if (slide.Background.Type != BackgroundType.OwnBackground)

                    {

                        // Set the slide to use its own background

                        slide.Background.Type = BackgroundType.OwnBackground;



                        // Set fill type to solid

                        slide.Background.FillFormat.FillType = FillType.Solid;



                        // Apply a solid color (e.g., LightGray)

                        slide.Background.FillFormat.SolidFillColor.Color = Color.LightGray;

                    }

                }



                // Save the presentation

                try

                {

                    presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);

                }

                catch (Aspose.Slides.PptxUnsupportedFormatException ex)

                {

                    // Handle unsupported PPTX format

                    Console.WriteLine("Unsupported PPTX format: " + ex.Message);

                }

                catch (Aspose.Slides.PptUnsupportedFormatException ex)

                {

                    // Handle unsupported PPT format

                    Console.WriteLine("Unsupported PPT format: " + ex.Message);

                }

                catch (Exception ex)

                {

                    // General exception handling

                    Console.WriteLine("An error occurred: " + ex.Message);

                }

            }

        }

    }

}


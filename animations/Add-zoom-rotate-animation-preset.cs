// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add zoom rotate animation preset using C#

//

// Description:

// Demonstrates how to add a zoom rotate animation preset using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Zoom, Rotate, Animation, 

// Preset, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate add zoom rotate animation preset.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Animation;



namespace AsposeSlidesAnimationDemo

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define output file path

            string outputPath = "ZoomRotateAnimation_out.pptx";



            // Create a new presentation

            using (Presentation presentation = new Presentation())

            {

                // Get the first slide

                ISlide slide = presentation.Slides[0];



                // Add a rectangle shape to animate

                IAutoShape shape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

                shape.TextFrame.Text = "Zoom & Rotate";



                // Add a Zoom effect (Entrance class)

                IEffect zoomEffect = slide.Timeline.MainSequence.AddEffect(

                    shape,

                    EffectType.Zoom,

                    EffectSubtype.None,

                    EffectTriggerType.AfterPrevious);



                // Create a rotation behavior and attach it to the same effect

                BehaviorFactory behaviorFactory = new BehaviorFactory();

                IRotationEffect rotationBehavior = behaviorFactory.CreateRotationEffect();

                // Rotate 360 degrees

                rotationBehavior.To = 360f;

                // Add the rotation behavior to the effect's behavior collection

                zoomEffect.Behaviors.Add(rotationBehavior);



                // Save the presentation

                try

                {

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

                catch (Exception ex)

                {

                    // Handle unsupported format or other save errors

                    Console.WriteLine("Error saving presentation: " + ex.Message);

                }

            }



            // Verify that the file was created

            if (File.Exists(outputPath))

            {

                Console.WriteLine("Presentation saved successfully: " + Path.GetFullPath(outputPath));

            }

            else

            {

                Console.WriteLine("Failed to create the presentation file.");

            }

        }

    }

}


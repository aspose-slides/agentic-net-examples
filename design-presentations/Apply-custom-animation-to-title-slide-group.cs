// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply fade animation to shapes on a title slide using C#

//

// Description:

// Demonstrates how to add shapes to the first slide (commonly a title slide)

// and apply a fade animation sequence to them using Aspose.Slides for .NET.

// The example handles both loading an existing PPTX file and creating a new

// presentation when the input file is missing, then saves the result as a PPTX.

// This pattern can be used to automate slide animation creation in .NET

// console applications.

//

// Keywords:

// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Fade Animation, Timeline,

// MainSequence, Shape, Title Slide, Presentation Automation

//

// Use Cases:

// - Add fade-in effects to shapes on a title slide.

// - Generate a new presentation with animated title elements.

// - Enhance existing presentations by inserting animated graphics.

// - Automate PPTX creation and animation for reporting or marketing tools.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AnimationExample

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            try

            {

                if (File.Exists(inputPath))

                {

                    using (Presentation presentation = new Presentation(inputPath))

                    {

                        ISlide slide = presentation.Slides[0];



                        // Add shapes to the title slide

                        IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

                        IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 300, 50, 200, 100);



                        // Apply custom animation sequence

                        slide.Timeline.MainSequence.AddEffect(

                            shape1,

                            Aspose.Slides.Animation.EffectType.Fade,

                            Aspose.Slides.Animation.EffectSubtype.None,

                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);



                        slide.Timeline.MainSequence.AddEffect(

                            shape2,

                            Aspose.Slides.Animation.EffectType.Fade,

                            Aspose.Slides.Animation.EffectSubtype.None,

                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);



                        // Save presentation

                        presentation.Save(outputPath, SaveFormat.Pptx);

                    }

                }

                else

                {

                    using (Presentation presentation = new Presentation())

                    {

                        ISlide slide = presentation.Slides[0];



                        // Add shapes to the title slide

                        IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

                        IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 300, 50, 200, 100);



                        // Apply custom animation sequence

                        slide.Timeline.MainSequence.AddEffect(

                            shape1,

                            Aspose.Slides.Animation.EffectType.Fade,

                            Aspose.Slides.Animation.EffectSubtype.None,

                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);



                        slide.Timeline.MainSequence.AddEffect(

                            shape2,

                            Aspose.Slides.Animation.EffectType.Fade,

                            Aspose.Slides.Animation.EffectSubtype.None,

                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);



                        // Save presentation

                        presentation.Save(outputPath, SaveFormat.Pptx);

                    }

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}


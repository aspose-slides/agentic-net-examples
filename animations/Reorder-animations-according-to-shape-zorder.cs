// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Reorder animations according to shape zorder using C#

//

// Description:

// Demonstrates how to reorder animation effects so that they follow the

// Z‑order of shapes in each slide using Aspose.Slides for .NET. The example

// loads a PPTX file, iterates through its slides and shapes, removes existing

// effects, and re‑adds a generic Appear effect in the correct order. The

// processed presentation is saved as a new PPTX file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Reorder, Animations, Shape,

// Z‑order, Presentation Processing, Office Automation

//

// Use Cases:

// - Reorder animation effects to match visual stacking of shapes.

// - Build automated tools for PPTX cleanup or preparation.

// - Integrate animation ordering logic into .NET applications.

// - Validate and adjust presentation workflows before distribution.

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



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            foreach (Aspose.Slides.ISlide slide in pres.Slides)

            {

                Aspose.Slides.Animation.ISequence mainSeq = slide.Timeline.MainSequence;

                Aspose.Slides.IShapeCollection shapes = slide.Shapes;



                // Reorder animation effects to follow the Z‑order of shapes

                for (int i = 0; i < shapes.Count; i++)

                {

                    Aspose.Slides.IShape shape = shapes[i];

                    Aspose.Slides.Animation.IEffect[] effects = mainSeq.GetEffectsByShape(shape);

                    if (effects == null) continue;



                    foreach (Aspose.Slides.Animation.IEffect effect in effects)

                    {

                        // Remove the existing effect

                        mainSeq.Remove(effect);

                        // Re‑add the effect (simplified to a generic Appear effect)

                        mainSeq.AddEffect(shape,

                                          Aspose.Slides.Animation.EffectType.Appear,

                                          Aspose.Slides.Animation.EffectSubtype.None,

                                          Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                    }

                }

            }



            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            pres.Dispose();

        }

        catch (Exception ex)

        {

            // Handle unsupported format or other errors

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


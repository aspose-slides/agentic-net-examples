// -----------------------------------------------------------------------------
// Example: Remove Unanimated 3D Objects from PowerPoint Slides
//
// Description:
// This console application loads a PPTX file using Aspose.Slides for .NET,
// iterates through all slides, and removes any 3‑D shapes that do not have
// associated animation effects. The modified presentation is saved as a new
// PPTX file. It demonstrates handling of file existence, exception safety,
// and proper use of the Aspose.Slides API with fully qualified type names.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, remove 3D shapes, animation, slide processing
//
// Use Cases:
// - Clean up presentations by deleting unused 3‑D objects before publishing.
// - Optimize file size by removing unanimated 3‑D content.
// - Automate preparation of slide decks for platforms that do not support 3‑D.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file \"{0}\" does not exist.", inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error loading presentation: {0}", ex.Message);
                return;
            }

            try
            {
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;

                    // Iterate shapes in reverse order to allow safe removal
                    for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Identify 3D shapes (ThreeDFormat is not null)
                        Aspose.Slides.IThreeDFormat threeDFormat = shape.ThreeDFormat;
                        if (threeDFormat == null)
                        {
                            continue;
                        }

                        // Determine whether the shape participates in any animation effect
                        bool hasAnimation = false;
                        for (int effectIndex = 0; effectIndex < mainSequence.Count; effectIndex++)
                        {
                            Aspose.Slides.Animation.IEffect effect = (Aspose.Slides.Animation.IEffect)mainSequence[effectIndex];
                            if (effect.TargetShape != null && effect.TargetShape.Equals(shape))
                            {
                                hasAnimation = true;
                                break;
                            }
                        }

                        // Remove the shape if it is a 3D object without animation
                        if (!hasAnimation)
                        {
                            slide.Shapes.Remove(shape);
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to \"{0}\".", outputPath);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("An error occurred while processing the presentation: {0}", ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}

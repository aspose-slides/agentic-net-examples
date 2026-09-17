// -----------------------------------------------------------------------------
// Example: Remove Unanimated 3D Objects from PowerPoint Slides using Aspose.Slides
//
// Description:
// This console application loads a PPTX file, iterates through all slides, and
// removes any 3‑D shapes that do not have an associated animation effect.
// It uses Aspose.Slides for .NET to manipulate the presentation and saves the
// modified file as a new PPTX. The program checks for file existence and handles
// generic exceptions, including unsupported formats.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, remove 3D objects, animation, slide processing
//
// Use Cases:
// - Clean up legacy presentations by deleting unused 3‑D graphics.
// - Prepare slides for platforms that do not support 3‑D animations.
// - Reduce file size by eliminating unanimated 3‑D content.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;

namespace RemoveUnanimated3DObjects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Failed to load presentation. Exception: " + ex.Message);
                // The file format may be unsupported.
                return;
            }

            try
            {
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    List<Aspose.Slides.IShape> shapesToRemove = new List<Aspose.Slides.IShape>();

                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Identify 3D shapes via ThreeDFormat property.
                        if (shape.ThreeDFormat != null)
                        {
                            bool hasAnimation = false;
                            Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;

                            foreach (Aspose.Slides.Animation.IEffect effect in mainSequence)
                            {
                                if (effect.TargetShape != null && effect.TargetShape.Equals(shape))
                                {
                                    hasAnimation = true;
                                    break;
                                }
                            }

                            if (!hasAnimation)
                            {
                                shapesToRemove.Add(shape);
                            }
                        }
                    }

                    // Remove identified shapes.
                    foreach (Aspose.Slides.IShape shapeToRemove in shapesToRemove)
                    {
                        slide.Shapes.Remove(shapeToRemove);
                    }
                }

                // Save the modified presentation.
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("An error occurred while processing slides: " + ex.Message);
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

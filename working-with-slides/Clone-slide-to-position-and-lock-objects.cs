// -----------------------------------------------------------------------------
// Example: Clone slide to position and lock objects using C#
//
// Description:
// Demonstrates how to clone a slide to a specific position within the same
// presentation and lock all graphical objects on the cloned slide using C# and
// Aspose.Slides for .NET. The example loads an existing PPTX file, inserts a
// cloned slide at a given index, applies position, size, and aspect‑ratio locks
// to each shape, and saves the result as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Slide, Position, Lock,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of slides to a desired order while preserving layout.
// - Secure slide content by locking shape properties programmatically.
// - Build .NET tools for PowerPoint presentation manipulation and validation.
// - Integrate slide cloning and locking into larger document processing pipelines.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            string inputPath = "CloneWithInSamePresentation.pptx";
            string outputPath = "Aspose_CloneWithInSamePresentation_out.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    ISlideCollection slides = pres.Slides;
                    // Clone slide at index 1 to position 2 within the same presentation
                    ISlide clonedSlide = slides.InsertClone(2, slides[1]);

                    // Lock all graphical objects on the cloned slide
                    foreach (IShape shape in clonedSlide.Shapes)
                    {
                        if (shape is IGraphicalObject gobj)
                        {
                            gobj.ShapeLock.PositionLocked = true;
                            gobj.ShapeLock.SizeLocked = true;
                            gobj.ShapeLock.AspectRatioLocked = true;
                        }
                        else if (shape is IAutoShape auto)
                        {
                            auto.AutoShapeLock.PositionLocked = true;
                            auto.AutoShapeLock.SizeLocked = true;
                            auto.AutoShapeLock.AspectRatioLocked = true;
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

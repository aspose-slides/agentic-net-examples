// -----------------------------------------------------------------------------
// Example: Replace inkshape with new objects and save using C#
//
// Description:
// Demonstrates how to replace Ink shapes with new rectangle placeholders and save the presentation using C# and Aspose.Slides for .NET. The example loads a PPTX file, iterates through slides and shapes, removes any Ink shape, inserts a rectangle of the same dimensions, and saves the modified file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ink shape, Replace shape, Rectangle placeholder, Save, Presentation processing
//
// Use Cases:
// - Automate replacement of Ink annotations with standard shapes in PPTX files.
// - Build C# utilities for cleaning or standardizing PowerPoint content.
// - Convert hand-drawn ink objects to editable shapes for further editing.
// - Integrate Ink shape handling into .NET presentation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceInkDemo
{
    class Program
    {
        static void Main(string[] args)
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
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        Aspose.Slides.Ink.Ink inkShape = shape as Aspose.Slides.Ink.Ink;

                        if (inkShape != null)
                        {
                            // Remove the existing ink shape
                            slide.Shapes.RemoveAt(shapeIndex);

                            // Add a new placeholder rectangle at the same position and size
                            Aspose.Slides.IShape newShape = slide.Shapes.AddAutoShape(
                                Aspose.Slides.ShapeType.Rectangle,
                                inkShape.X,
                                inkShape.Y,
                                inkShape.Width,
                                inkShape.Height);
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // If the file format is not supported, handle accordingly
                // format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

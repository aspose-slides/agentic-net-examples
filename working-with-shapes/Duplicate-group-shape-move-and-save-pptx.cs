// -----------------------------------------------------------------------------
// Example: Duplicate Group Shape, Reposition, and Save PPTX using C#
// 
// Description:
// This console program loads a PPTX file, duplicates the first group shape on the
// first slide, moves the cloned shape to a new location, and saves the result as
// a new PPTX file. If the input file does not exist, a sample presentation with a
// group shape is created automatically. The task demonstrates shape cloning and
// coordinate manipulation with Aspose.Slides for .NET.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Duplicate Group Shape, Move Shape
// 
// Use Cases:
// - Automate duplication and repositioning of grouped objects in presentations.
// - Build .NET utilities for batch editing of PowerPoint files.
// - Validate shape manipulation workflows during development.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            if (!File.Exists(inputPath))
            {
                // Create a sample presentation with a group shape
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                Aspose.Slides.IGroupShape sampleGroup = sampleSlide.Shapes.AddGroupShape();
                sampleGroup.X = 50f;
                sampleGroup.Y = 50f;
                sampleGroup.Width = 200f;
                sampleGroup.Height = 200f;
                sampleGroup.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 0f, 0f, 80f, 80f);
                sampleGroup.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100f, 0f, 80f, 80f);
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlide firstSlide = pres.Slides[0];
                Aspose.Slides.IShapeCollection shapes = firstSlide.Shapes;

                // Find the first group shape
                Aspose.Slides.IGroupShape sourceGroup = null;
                foreach (Aspose.Slides.IShape shape in shapes)
                {
                    sourceGroup = shape as Aspose.Slides.IGroupShape;
                    if (sourceGroup != null)
                    {
                        break;
                    }
                }

                if (sourceGroup == null)
                {
                    Console.WriteLine("No group shape found on the first slide.");
                    Environment.Exit(1);
                }

                // Clone the group shape
                Aspose.Slides.IShape clonedGroup = shapes.AddClone(sourceGroup);

                // Reposition the cloned group shape
                clonedGroup.X = sourceGroup.X + 100f;
                clonedGroup.Y = sourceGroup.Y + 50f;

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}

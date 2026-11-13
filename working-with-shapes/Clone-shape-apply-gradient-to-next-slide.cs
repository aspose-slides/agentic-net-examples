// -----------------------------------------------------------------------------
// Example: Clone Shape and Apply Linear Gradient Fill on Next Slide using C#
//
// Description:
// This console program loads an existing PPTX file (or creates a sample one if missing),
// clones the first shape from the first slide onto a newly added blank slide,
// and applies a linear gradient fill to the cloned shape. The modified presentation
// is saved as a new PPTX file. It demonstrates automated shape cloning and gradient
// styling with Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Shape, Gradient Fill
//
// Use Cases:
// - Automate cloning a shape and applying a gradient fill on a subsequent slide.
// - Build utilities for PowerPoint presentation manipulation in .NET.
// - Validate presentation transformations before publishing or integration.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace AsposeSlidesExample
{
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
                    // Create a sample presentation with a single rectangle shape
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ILayoutSlide blankLayout = samplePres.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
                    Aspose.Slides.ISlide firstSlide = samplePres.Slides.AddEmptySlide(blankLayout);
                    Aspose.Slides.IAutoShape rectShape = firstSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100f, 100f, 200f, 100f);
                    rectShape.TextFrame.Text = "Sample Shape";
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }

                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Source slide and shape (first shape on first slide)
                Aspose.Slides.ISlide srcSlide = pres.Slides[0];
                if (srcSlide.Shapes.Count == 0)
                {
                    Console.WriteLine("Source slide does not contain any shapes.");
                    pres.Dispose();
                    Environment.Exit(1);
                }
                Aspose.Slides.IShape srcShape = srcSlide.Shapes[0];

                // Add a new blank slide
                Aspose.Slides.ILayoutSlide blankLayout2 = pres.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
                Aspose.Slides.ISlide destSlide = pres.Slides.AddEmptySlide(blankLayout2);

                // Clone the shape onto the new slide at the same position
                Aspose.Slides.IShape clonedShape = destSlide.Shapes.AddClone(srcShape, srcShape.X, srcShape.Y);

                // Apply linear gradient fill to the cloned shape
                clonedShape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                clonedShape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
                clonedShape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
                clonedShape.FillFormat.GradientFormat.GradientStops.Add(0f, Color.Purple);
                clonedShape.FillFormat.GradientFormat.GradientStops.Add(1f, Color.Red);

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }

            Environment.Exit(0);
        }
    }
}

// -----------------------------------------------------------------------------
// Example: Clone shape apply gradient to next slide using C#
//
// Description:
// Demonstrates how to clone a shape from the first slide, add it to a newly
// created blank slide, and apply a linear gradient fill to the cloned shape
// using Aspose.Slides for .NET. The example loads an existing PPTX file,
// performs the shape cloning and formatting, and saves the result as a new
// PPTX file in a standalone console application. Developers can use this
// pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Shape, Gradient Fill,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning a shape and applying a gradient fill on a subsequent slide.
// - Build C# utilities for PowerPoint presentation manipulation.
// - Generate or transform PPTX files programmatically in .NET applications.
// - Validate presentation transformations before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
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
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Source slide and shape (first shape on first slide)
                ISlide srcSlide = pres.Slides[0];
                IShape srcShape = srcSlide.Shapes[0];

                // Add a new blank slide
                ILayoutSlide blankLayout = pres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
                ISlide destSlide = pres.Slides.AddEmptySlide(blankLayout);

                // Clone the shape onto the new slide at the same position
                IShape clonedShape = destSlide.Shapes.AddClone(srcShape, srcShape.X, srcShape.Y);

                // Apply gradient fill to the cloned shape
                clonedShape.FillFormat.FillType = FillType.Gradient;
                clonedShape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
                clonedShape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;
                clonedShape.FillFormat.GradientFormat.GradientStops.Add(0, PresetColor.Purple);
                clonedShape.FillFormat.GradientFormat.GradientStops.Add(1, PresetColor.Red);

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

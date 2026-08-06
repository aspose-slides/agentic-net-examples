// -----------------------------------------------------------------------------
// Example: Clone smartart shape to other slide using C#
//
// Description:
// Demonstrates how to clone a SmartArt shape from one slide to another slide 
// using C# and Aspose.Slides for .NET. The example loads a source presentation,
// locates the first SmartArt shape, clones it onto a target slide while preserving 
// its position, and saves the result. This pattern can be used in console 
// applications for PowerPoint automation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, SmartArt, Shape, Slide, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of SmartArt shapes between slides.
// - Build C# tools for PowerPoint presentation manipulation.
// - Generate or modify PPTX files programmatically.
// - Validate and test SmartArt handling in .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace CloneSmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string sourcePath = "source.pptx";
            string outputPath = "output.pptx";

            // Verify source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file not found: " + sourcePath);
                return;
            }

            try
            {
                // Load the source presentation
                using (Presentation sourcePres = new Presentation(sourcePath))
                {
                    // Get the first slide (source slide)
                    ISlide sourceSlide = sourcePres.Slides[0];

                    // Find the first SmartArt shape on the source slide
                    ISmartArt sourceSmartArt = null;
                    for (int i = 0; i < sourceSlide.Shapes.Count; i++)
                    {
                        sourceSmartArt = sourceSlide.Shapes[i] as ISmartArt;
                        if (sourceSmartArt != null)
                            break;
                    }

                    if (sourceSmartArt == null)
                    {
                        Console.WriteLine("No SmartArt shape found on the source slide.");
                        return;
                    }

                    // Ensure there is a target slide to place the clone
                    ISlide targetSlide;
                    if (sourcePres.Slides.Count > 1)
                    {
                        targetSlide = sourcePres.Slides[1];
                    }
                    else
                    {
                        // Add a new blank slide using the first layout slide as a template
                        ILayoutSlide blankLayout = sourcePres.LayoutSlides.GetByType(SlideLayoutType.Blank);
                        targetSlide = sourcePres.Slides.AddEmptySlide(blankLayout);
                    }

                    // Clone the SmartArt shape onto the target slide, preserving its position
                    float cloneX = sourceSmartArt.X;
                    float cloneY = sourceSmartArt.Y;
                    IShape clonedShape = targetSlide.Shapes.AddClone(sourceSmartArt, cloneX, cloneY);

                    // Optionally cast back to ISmartArt if further SmartArt-specific processing is needed
                    ISmartArt clonedSmartArt = clonedShape as ISmartArt;

                    // Save the modified presentation
                    sourcePres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues, Aspose.Slides internal errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

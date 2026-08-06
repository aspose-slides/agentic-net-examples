// -----------------------------------------------------------------------------
// Example: Clone smartart shape apply theme compare export using C#
//
// Description:
// Demonstrates how to clone a SmartArt shape, apply an external theme, and
// export the modified presentation using C# and Aspose.Slides for .NET.
// The example shows the required presentation-processing steps for PowerPoint
// files and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, SmartArt, Shape, Apply Theme,
// Export, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning a SmartArt shape, applying a theme, and exporting the result.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtCloneWithTheme
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation and theme file paths
            System.String inputPath = "input.pptx";
            System.String themePath = "customTheme.thmx";
            System.String outputPath = "output_CloneWithTheme.pptx";

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found.");
                return;
            }
            if (!File.Exists(themePath))
            {
                Console.WriteLine("Theme file not found.");
                return;
            }

            // Load presentation
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Locate the first SmartArt shape on the first slide
            Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];
            Aspose.Slides.IShapeCollection sourceShapes = sourceSlide.Shapes;
            Aspose.Slides.SmartArt.ISmartArt smartArtShape = null;
            for (int i = 0; i < sourceShapes.Count; i++)
            {
                if (sourceShapes[i] is Aspose.Slides.SmartArt.ISmartArt)
                {
                    smartArtShape = (Aspose.Slides.SmartArt.ISmartArt)sourceShapes[i];
                    break;
                }
            }

            if (smartArtShape == null)
            {
                Console.WriteLine("No SmartArt shape found in the source slide.");
                presentation.Dispose();
                return;
            }

            // Create a blank slide to host the cloned SmartArt
            Aspose.Slides.ILayoutSlide blankLayout = presentation.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
            Aspose.Slides.ISlide destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);
            Aspose.Slides.IShapeCollection destinationShapes = destinationSlide.Shapes;

            // Clone the SmartArt shape to the new slide at a specific position
            destinationShapes.AddClone(smartArtShape, 100f, 100f);

            // Apply external theme to the master slide (affects dependent slides)
            try
            {
                Aspose.Slides.IMasterSlide themedMaster = presentation.Masters[0].ApplyExternalThemeToDependingSlides(themePath);
            }
            catch (Aspose.Slides.PptxReadException ex)
            {
                Console.WriteLine("Failed to apply external theme: " + ex.Message);
                // Continue without theme if needed
            }

            // Save the modified presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Clean up
            presentation.Dispose();
        }
    }
}

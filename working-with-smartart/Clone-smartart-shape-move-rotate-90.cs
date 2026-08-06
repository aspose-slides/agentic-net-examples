// -----------------------------------------------------------------------------
// Example: Clone smartart shape move rotate 90 using C#
//
// Description:
// Demonstrates how to create a presentation, add a SmartArt shape, clone the
// SmartArt to a new slide, move it to a new position, rotate it by 90 degrees,
// and save the result using Aspose.Slides for .NET. The example provides a
// straightforward workflow for manipulating SmartArt objects in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, SmartArt, Shape, Move,
// Rotate, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of SmartArt shapes with repositioning and rotation.
// - Build C# utilities for PowerPoint content transformation.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate SmartArt manipulation before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];

        // Add a SmartArt shape to the source slide
        Aspose.Slides.SmartArt.ISmartArt smartArt = sourceSlide.Shapes.AddSmartArt(50, 50, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Create a blank layout slide for the new slide
        Aspose.Slides.ILayoutSlide blankLayout = presentation.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

        // Add a new empty slide using the blank layout
        Aspose.Slides.ISlide destSlide = presentation.Slides.AddEmptySlide(blankLayout);

        // Clone the SmartArt shape to the new slide and position it
        Aspose.Slides.IShape clonedShape = destSlide.Shapes.AddClone(smartArt, 100, 100);

        // Apply a rotation of 90 degrees to the cloned SmartArt
        clonedShape.Rotation = 90;

        // Save the presentation
        presentation.Save("CloneSmartArt.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}

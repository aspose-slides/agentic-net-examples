// -----------------------------------------------------------------------------
// Example: Apply gradient fill to smartart node using C#
//
// Description:
// Demonstrates how to apply a linear gradient fill to a SmartArt node shape 
// using Aspose.Slides for .NET. The example creates a presentation, adds a 
// SmartArt diagram, accesses the first node, sets a gradient fill, and saves 
// the file as a PPTX. This pattern can be used to automate PowerPoint 
// presentation styling in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Gradient Fill, SmartArt, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically apply gradient fills to SmartArt elements.
// - Build .NET tools for customizing PowerPoint presentations.
// - Generate or modify PPTX files with styled SmartArt.
// - Automate visual consistency checks in presentation workflows.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
            50, 50, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Get the first node of the SmartArt
        Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[0];

        // Get the first shape associated with the node
        Aspose.Slides.SmartArt.ISmartArtShape shape = node.Shapes[0];

        // Apply gradient fill to the shape
        shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
        shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
        shape.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;
        shape.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Purple);
        shape.FillFormat.GradientFormat.GradientStops.Add(1, Aspose.Slides.PresetColor.Red);

        // Save the presentation
        try
        {
            presentation.Save("SmartArtGradient.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}

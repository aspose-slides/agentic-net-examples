// -----------------------------------------------------------------------------
// Example: Add smartart diagram customize layout colors using C#
//
// Description:
// Demonstrates how to add a SmartArt diagram, change its layout, and customize
// its color style using C# and Aspose.Slides for .NET. The example creates a
// new presentation, inserts a SmartArt shape, switches the layout from
// BasicBlockList to BasicProcess, updates the color scheme, and saves the
// result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Diagram, Layout,
// ColorStyle, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding SmartArt diagrams with specific layouts.
// - Customize SmartArt color styles programmatically.
// - Build C# tools for PowerPoint presentation generation or modification.
// - Integrate SmartArt customization into .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram with a basic layout
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Change the layout from BasicBlockList to BasicProcess for visual consistency
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            if (shape is Aspose.Slides.SmartArt.ISmartArt)
            {
                Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.ISmartArt)shape;
                if (smart.Layout == Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList)
                {
                    smart.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicProcess;
                }
            }
        }

        // Change the color scheme from ColoredFillAccent1 to ColorfulAccentColors
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            if (shape is Aspose.Slides.SmartArt.ISmartArt)
            {
                Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.ISmartArt)shape;
                if (smart.ColorStyle == Aspose.Slides.SmartArt.SmartArtColorType.ColoredFillAccent1)
                {
                    smart.ColorStyle = Aspose.Slides.SmartArt.SmartArtColorType.ColorfulAccentColors;
                }
            }
        }

        // Save the presentation
        string outputPath = "SmartArtDemo.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}

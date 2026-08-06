// -----------------------------------------------------------------------------
// Example: Change org chart type to vertical using C#
//
// Description:
// Demonstrates how to change an organization chart SmartArt layout to a vertical
// (left hanging) orientation using C# and Aspose.Slides for .NET. The example
// creates a presentation, adds a default horizontal organization chart, modifies
// its root node layout to vertical, and saves the result as a PPTX file.
// This pattern can be used to automate SmartArt transformations in PowerPoint
// files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Organization Chart,
// Layout, Vertical, Left Hanging, Presentation Processing, Office Automation
//
// Use Cases:
// - Convert horizontal organization charts to vertical layout programmatically.
// - Build C# utilities for SmartArt manipulation in PowerPoint presentations.
// - Integrate org chart layout adjustments into .NET applications or CI pipelines.
// - Automate preparation of PPTX files with specific SmartArt configurations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an organization chart SmartArt with the default horizontal layout
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

        // Change the layout of the root node to a vertical (left hanging) layout
        smartArt.Nodes[0].OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.LeftHanging;

        // Save the presentation
        presentation.Save("OrganizationChartLayoutShift.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}

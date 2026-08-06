// -----------------------------------------------------------------------------
// Example: Switch org chart orientation horizontal to vertical using C#
//
// Description:
// Demonstrates how to switch an organization chart SmartArt orientation from the
// default horizontal layout to a vertical left‑hanging layout using C# and
// Aspose.Slides for .NET. The example creates a new presentation, adds an
// Organization Chart SmartArt, modifies its root node layout, and saves the
// result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Switch, SmartArt, Organization Chart,
// Orientation, Horizontal, Vertical, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of horizontal organization charts to vertical layout.
// - Build C# utilities for PowerPoint SmartArt manipulation.
// - Generate or transform PPTX files with specific SmartArt orientations.
// - Validate SmartArt layout changes in automated presentation workflows.
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

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an Organization Chart SmartArt (horizontal layout by default)
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

        // Change the layout of the root node to a vertical left‑hanging layout
        smartArt.Nodes[0].OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.LeftHanging;

        // Save the presentation
        presentation.Save("OrganizationChartVertical.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}

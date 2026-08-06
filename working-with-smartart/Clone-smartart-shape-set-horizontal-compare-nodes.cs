// -----------------------------------------------------------------------------
// Example: Clone smartart shape set horizontal compare nodes using C#
//
// Description:
// Demonstrates how to clone a SmartArt shape, modify the cloned shape's root
// node layout to a standard horizontal arrangement, and compare the node
// layouts of the original and cloned SmartArt objects using C# and
// Aspose.Slides for .NET. The example creates a presentation, adds an
// Organization Chart SmartArt, clones it, changes the layout of the cloned
// SmartArt, outputs the layout values to the console, and saves the result as
// a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, SmartArt, Shape,
// Horizontal, Organization Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of SmartArt shapes with modified node layouts.
// - Build C# tools for PowerPoint presentation processing and layout comparison.
// - Generate or transform PPTX files in .NET applications with custom SmartArt.
// - Validate SmartArt layout changes before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "output.pptx";
        try
        {
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];

            // Add original SmartArt (Organization Chart)
            Aspose.Slides.SmartArt.ISmartArt originalSmartArt = slide.Shapes.AddSmartArt(
                50, 50, 400, 300,
                Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

            // Set original root node layout to Left Hanging
            originalSmartArt.Nodes[0].OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.LeftHanging;

            // Clone the SmartArt shape
            IShapeCollection shapes = slide.Shapes;
            IShape clonedShape = shapes.AddClone(originalSmartArt, 500, 50);
            Aspose.Slides.SmartArt.ISmartArt clonedSmartArt = (Aspose.Slides.SmartArt.ISmartArt)clonedShape;

            // Change cloned SmartArt node layout to Standard (horizontal)
            clonedSmartArt.Nodes[0].OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.Standard;

            // Compare node arrangements
            Console.WriteLine("Original node layout: " + originalSmartArt.Nodes[0].OrganizationChartLayout);
            Console.WriteLine("Cloned node layout: " + clonedSmartArt.Nodes[0].OrganizationChartLayout);

            // Save presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., format not supported)
        }
    }
}

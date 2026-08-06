// -----------------------------------------------------------------------------
// Example: Set org chart type horizontal render png using C#
//
// Description:
// Demonstrates how to set an organization chart SmartArt layout to horizontal,
// render the resulting slide as a PNG image, and save the presentation using
// Aspose.Slides for .NET. The example shows the required presentation-processing
// steps for PowerPoint files and produces the requested output in a standalone
// console application. Developers can use this pattern to automate PPTX workflows,
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, SmartArt, Organization Chart,
// Horizontal Layout, Render, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting an organization chart to a horizontal layout and rendering as PNG.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with specific SmartArt configurations in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace SetOrgChartTypeHorizontalRenderPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram of type OrganizationChart
                ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.OrganizationChart);

                // Set the SmartArt layout to Horizontal Organization Chart
                smartArt.Layout = SmartArtLayoutType.HorizontalOrganizationChart;

                // Render the slide to a PNG image
                IImage slideImage = slide.GetImage(1f, 1f);
                slideImage.Save("Slide.png", ImageFormat.Png);

                // Save the presentation
                presentation.Save("Presentation.pptx", SaveFormat.Pptx);
            }
        }
    }
}

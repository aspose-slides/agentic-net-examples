// -----------------------------------------------------------------------------
// Example: Set hidden slide background to semi transparent gradient using C#
//
// Description:
// Demonstrates how to set a hidden slide's background to a semi transparent
// gradient using C# and Aspose.Slides for .NET. The example creates a new
// presentation, hides the first slide, applies a gradient fill with 50%
// transparency to the slide background, and saves the result as a PPTX file.
// This pattern can be used to automate PowerPoint workflows, validate
// presentation styling, or integrate slide manipulation into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hidden, Slide, Background,
// Semi, Transparent, Gradient, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting hidden slide backgrounds to semi transparent gradients.
// - Build C# tools for PowerPoint presentation processing and styling.
// - Generate or transform PPTX files with custom background effects in .NET.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Hide the slide
                slide.Hidden = true;

                // Set background to gradient
                pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
                pres.Slides[0].Background.FillFormat.FillType = FillType.Gradient;
                pres.Slides[0].Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

                // Apply semi transparency to the gradient background
                pres.Slides[0].Background.FillFormat.Transparency = 0.5f;

                // Save the presentation
                pres.Save("HiddenGradientSlide.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

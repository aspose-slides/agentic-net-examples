// -----------------------------------------------------------------------------
// Example: Set slide size widescreen 16 9 proportionally using C#
//
// Description:
// Demonstrates how to set the slide size to widescreen 16:9 and scale existing
// content proportionally using C# and Aspose.Slides for .NET. The example creates
// a new presentation, applies the widescreen size with EnsureFit scaling, and
// saves the result as a PPTX file. This pattern can be used to automate slide
// size adjustments in PowerPoint automation scenarios.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide Size, Widescreen, 16:9,
// Proportional Scaling, Presentation Processing, Office Automation
//
// Use Cases:
// - Adjust slide dimensions to widescreen 16:9 while preserving content layout.
// - Build .NET tools that modify existing presentations for modern display formats.
// - Automate batch processing of PPTX files to standardize slide sizes.
// - Integrate slide size configuration into larger presentation generation workflows.
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
        using (Presentation presentation = new Presentation())
        {
            // Set slide size to widescreen 16:9 and scale existing content proportionally
            presentation.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.EnsureFit);

            // Save the presentation
            try
            {
                presentation.Save("WidescreenPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported
            }
        }
    }
}

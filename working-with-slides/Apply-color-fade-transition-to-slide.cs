// -----------------------------------------------------------------------------
// Example: Apply color fade transition to slide using C#
//
// Description:
// Demonstrates how to apply a color fade transition to a slide using C# and 
// Aspose.Slides for .NET. The example shows setting a slide background color, 
// configuring a fade transition with click and timed advance, and saving the 
// presentation. Developers can use this pattern to automate PPTX workflows, 
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Color, Fade, Transition, 
// Background, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying a color fade transition to a slide.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with custom slide backgrounds and transitions.
// - Validate presentation workflows before publishing or integration.
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

        // Set the background color of the first slide to a specified color (e.g., Red)
        presentation.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        presentation.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        presentation.Slides[0].Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;

        // Apply a fade transition to the first slide
        presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
        presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;
        presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds

        // Save the presentation (handle unsupported format exception)
        try
        {
            presentation.Save("CustomFadeTransition.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported or other saving error
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}

// -----------------------------------------------------------------------------
// Example: Set zoom to 150 percent verify view using C#
//
// Description:
// Demonstrates how to set the zoom level to 150 percent for both slide view
// and notes view using C# and Aspose.Slides for .NET. The example creates a
// new presentation, applies the zoom settings, and saves the result as a PPTX
// file. This pattern can be used to automate PowerPoint presentation processing
// tasks that require specific view scaling.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Zoom, Percent, Verify, View,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting zoom to 150 percent for slide and notes views.
// - Build C# tools for PowerPoint presentation processing with custom view settings.
// - Generate or transform PPTX files in .NET applications with specific zoom levels.
// - Validate presentation view configurations before publishing or integration.
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

        // Apply a zoom level of 150% to slide view and notes view
        presentation.ViewProperties.SlideViewProperties.Scale = 150;
        presentation.ViewProperties.NotesViewProperties.Scale = 150;

        // Define output file path
        string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ZoomedPresentation.pptx");

        try
        {
            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
        finally
        {
            // Ensure resources are released
            presentation.Dispose();
        }
    }
}

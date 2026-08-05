// -----------------------------------------------------------------------------
// Example: Set polyline line join round using C#
//
// Description:
// Demonstrates how to set the line join style to round for a polyline shape 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// adds a polyline shape to the first slide, applies the round join style, and 
// saves the result as a PPTX file. This pattern can be used to automate PPTX 
// workflows that require specific line join configurations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Polyline, Line, Join, Round, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting polyline line join round.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
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
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a polyline shape
        IAutoShape polyline = (IAutoShape)slide.Shapes.AddAutoShape(
            ShapeType.Polyline, 50, 150, 300, 100);

        // Set the line join style to round
        polyline.LineFormat.JoinStyle = LineJoinStyle.Round;

        // Save the presentation
        try
        {
            presentation.Save("PolyLineJoinRound.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle cases where the format is not supported or other save errors
        }
    }
}

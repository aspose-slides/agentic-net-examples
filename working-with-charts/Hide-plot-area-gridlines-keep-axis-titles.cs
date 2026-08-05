// -----------------------------------------------------------------------------
// Example: Hide plot area gridlines keep axis titles using C#
//
// Description:
// Demonstrates how to hide plot area gridlines while keeping axis titles using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Plot, Area, Gridlines, Axis Titles, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate hide plot area gridlines while preserving axis titles.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Ensure axis titles are visible
            chart.Axes.HorizontalAxis.HasTitle = true;
            chart.Axes.VerticalAxis.HasTitle = true;

            // Hide major gridlines by setting their fill type to NoFill
            chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
            chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

            // Hide minor gridlines by setting their fill type to NoFill
            chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
            chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

            // Save the presentation
            try
            {
                pres.Save("HideGridlines.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}

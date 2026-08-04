// -----------------------------------------------------------------------------
// Example: Hide axis line keep tick marks using C#
//
// Description:
// Demonstrates how to hide axis lines while keeping tick marks visible using
// C# and Aspose.Slides for .NET. The example creates a presentation, adds a
// clustered column chart, hides both horizontal and vertical axis lines without
// removing the tick marks, and saves the result as a PPTX file. This pattern
// helps automate PowerPoint chart formatting tasks in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Axis, Line, Keep, Tick Marks,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate hiding axis lines while preserving tick marks in charts.
// - Build C# utilities for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized chart appearance.
// - Validate chart formatting workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace HideAxisLineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Hide the horizontal axis line while keeping tick marks visible
                Aspose.Slides.Charts.IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                horizontalAxis.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                // Hide the vertical axis line while keeping tick marks visible
                Aspose.Slides.Charts.IAxis verticalAxis = chart.Axes.VerticalAxis;
                verticalAxis.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                // Save the presentation
                string outputPath = "HideAxisLine.pptx";
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, file I/O errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

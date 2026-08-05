// -----------------------------------------------------------------------------
// Example: Hide axis lines keep labels using C#
//
// Description:
// Demonstrates how to hide axis lines while keeping axis labels visible using C# and Aspose.Slides 
// for .NET. The example creates a new presentation, adds a clustered column chart, removes the
// horizontal and vertical axis lines without affecting the labels, and saves the result.
// This pattern can be used to customize chart appearance in automated PPTX workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Axis, Lines, Keep, Labels, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate hiding chart axis lines while preserving labels.
// - Build C# tools for customizing chart appearance in PowerPoint files.
// - Generate or transform PPTX files with specific chart styling in .NET applications.
// - Validate presentation visual consistency before publishing.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace HideAxisLines
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a chart to the first slide
                ISlide slide = presentation.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Hide horizontal axis line while keeping the axis labels visible
                IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
                // Ensure axis labels remain visible
                horizontalAxis.IsVisible = true;

                // Hide vertical axis line while keeping the axis labels visible
                IAxis verticalAxis = chart.Axes.VerticalAxis;
                verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
                verticalAxis.IsVisible = true;

                // Save the presentation
                presentation.Save("HideAxisLines.pptx", SaveFormat.Pptx);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                // Handle missing input files if any were used
                Console.WriteLine("Input file not found: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                // Handle unsupported file format
                // Format not supported
                Console.WriteLine("File format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling for external URLs or web services
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

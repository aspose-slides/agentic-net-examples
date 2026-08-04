// -----------------------------------------------------------------------------
// Example: Add 3D bubble chart to new slide using C#
//
// Description:
// Demonstrates how to add a 3‑D bubble chart to a new slide in an existing
// presentation using C# and Aspose.Slides for .NET. The example loads an input
// PPTX file, inserts an empty slide, creates a bubble chart with 3‑D bubbles,
// configures bubble size representation and scaling, and saves the result.
// This pattern can be used to automate chart creation and manipulation in
// PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, 3D Bubble Chart, Chart, Slide,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Add a 3‑D bubble chart to a presentation programmatically.
// - Build C# utilities for generating or enhancing PPTX charts.
// - Automate chart styling, such as bubble size representation and scaling.
// - Validate and test PowerPoint chart features in .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the existing presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Add a new empty slide
                ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                // Add a 3‑D bubble chart to the new slide
                IChart chart = newSlide.Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

                // Set bubble size representation to Width (demonstrates support‑of‑bubble‑size‑representation)
                chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

                // Set bubble size scale (demonstrates support‑for‑bubble‑chart‑scaling)
                chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150; // example scale value

                // Enable 3‑D effect for each bubble data point
                if (chart.ChartData.Series.Count > 0)
                {
                    IChartSeries series = chart.ChartData.Series[0];
                    foreach (IChartDataPoint point in series.DataPoints)
                    {
                        point.IsBubble3D = true;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

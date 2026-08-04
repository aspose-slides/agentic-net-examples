// -----------------------------------------------------------------------------
// Example: Update marker shape per series error bars using C#
//
// Description:
// Demonstrates how to update the marker shape for each series in a chart's
// error bars using C# and Aspose.Slides for .NET. The example loads an existing
// presentation (or creates a new one), iterates through all charts, assigns a
// distinct marker style to each series, and saves the modified presentation.
// This pattern can be used to customize chart appearance programmatically.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Update, Marker, Shape, Series,
// Error Bars, Chart Customization, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting unique marker shapes for series error bars in charts.
// - Build tools that modify chart visual styles in PowerPoint files.
// - Generate or transform PPTX presentations with customized chart markers.
// - Validate and standardize chart formatting before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Presentation presentation = null;

        // Load existing presentation if it exists, otherwise create a new one
        if (File.Exists(inputPath))
        {
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported or the file is corrupted.");
                return;
            }
        }
        else
        {
            presentation = new Presentation();
        }

        // Define a set of marker styles to assign uniquely per series
        MarkerStyleType[] markerStyles = new MarkerStyleType[]
        {
            MarkerStyleType.Circle,
            MarkerStyleType.Diamond,
            MarkerStyleType.Square,
            MarkerStyleType.Triangle,
            MarkerStyleType.X,
            MarkerStyleType.Plus,
            MarkerStyleType.Star,
            MarkerStyleType.Dash,
            MarkerStyleType.Dot,
            MarkerStyleType.None
        };

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                IShape shape = slide.Shapes[shapeIndex];
                IChart chart = shape as IChart;

                if (chart != null)
                {
                    IChartSeriesCollection seriesCollection = chart.ChartData.Series;

                    // Iterate through each series in the chart
                    for (int i = 0; i < seriesCollection.Count; i++)
                    {
                        IChartSeries series = seriesCollection[i];
                        IMarker marker = series.Marker;

                        // Assign a unique marker shape based on the series index
                        MarkerStyleType style = markerStyles[i % markerStyles.Length];
                        marker.Symbol = style;

                        // Existing error bar settings are preserved automatically
                    }
                }
            }
        }

        // Save the modified presentation
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            presentation.Dispose();
        }
    }
}

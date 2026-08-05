// -----------------------------------------------------------------------------
// Example: Assign unique marker shapes to series using C#
//
// Description:
// Demonstrates how to assign distinct marker shapes to each data series in a
// chart using C# and Aspose.Slides for .NET. The example loads an existing PPTX,
// locates the first chart, applies a set of marker symbols to the series, and
// saves the modified presentation. This pattern can be used to customize chart
// appearance programmatically.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Assign, Unique, Marker, Shapes, Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically customize chart series markers in PowerPoint files.
// - Build .NET tools that automate visual styling of charts.
// - Generate or modify PPTX presentations with specific chart aesthetics.
// - Validate and standardize chart formatting before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Get first slide
                ISlide slide = pres.Slides[0];

                // Find the first chart on the slide
                IChart chart = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is IChart)
                    {
                        chart = (IChart)shape;
                        break;
                    }
                }

                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Define a set of unique marker styles
                MarkerStyleType[] markerStyles = new MarkerStyleType[]
                {
                    MarkerStyleType.Circle,
                    MarkerStyleType.Square,
                    MarkerStyleType.Diamond,
                    MarkerStyleType.Triangle,
                    MarkerStyleType.Star,
                    MarkerStyleType.Plus,
                    MarkerStyleType.X,
                    MarkerStyleType.Dash,
                    MarkerStyleType.Dot
                };

                // Iterate through each series and assign a unique marker shape
                for (int i = 0; i < chart.ChartData.Series.Count; i++)
                {
                    IChartSeries series = chart.ChartData.Series[i];

                    // Assign marker symbol (cycle through the array if more series than styles)
                    series.Marker.Symbol = markerStyles[i % markerStyles.Length];

                    // Optionally set marker size
                    series.Marker.Size = 10;

                    // Existing error bar settings are preserved automatically; no changes made here
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the file format is not supported, Aspose.Slides will throw an exception.
            }
        }
    }
}

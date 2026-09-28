// -----------------------------------------------------------------------------
// Example: Set Data Label Offset from Axis in Aspose.Slides Chart
//
// Description:
// This console application creates a new PowerPoint presentation, adds a
// clustered column chart, sets the horizontal axis label offset to control the
// distance of data labels from the axis, and saves the result as a PPTX file.
// It demonstrates chart customization using Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, chart label offset, horizontal axis, data label distance
//
// Use Cases:
// - Automating chart formatting in generated presentations.
// - Validating visual output of PowerPoint reports in CI pipelines.
// - Integrating custom chart styling into .NET business applications.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesChartLabelOffset
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = Path.Combine(Environment.CurrentDirectory, "ChartLabelOffsetDemo.pptx");

            // Ensure the output directory exists
            string outputDirectory = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                float chartX = 50f;
                float chartY = 50f;
                float chartWidth = 600f;
                float chartHeight = 400f;
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    chartX,
                    chartY,
                    chartWidth,
                    chartHeight);

                // Set the horizontal axis label offset (distance from axis)
                // Value is in points; using 20 as an example
                chart.Axes.HorizontalAxis.LabelOffset = (ushort)20;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors (e.g., missing Aspose.Slides license)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

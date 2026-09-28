// -----------------------------------------------------------------------------
// Example: Set Chart Legend Position to Top-Left Using Aspose.Slides for .NET
//
// Description:
// This console application creates a new PowerPoint presentation, adds a
// clustered column chart, moves the chart legend to the top‑left corner of the
// chart area (coordinates 0,0), sets its size, and saves the file as a PPTX.
// It demonstrates how to customize chart legend positioning with Aspose.Slides.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, chart legend positioning, clustered column chart
//
// Use Cases:
// - Automating PPTX generation with custom chart legends.
// - Adjusting legend layout for branding or design requirements.
// - Processing existing presentations to reposition chart legends.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

namespace ChartLegendExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart at position (50,50) with size 500x400 points
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Position the legend at the top‑left corner of the chart area
                chart.Legend.X = 0f;
                chart.Legend.Y = 0f;
                chart.Legend.Width = 200f;
                chart.Legend.Height = 50f;

                string outputPath = "ChartLegendTopLeft.pptx";

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

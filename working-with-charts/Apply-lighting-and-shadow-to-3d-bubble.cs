// -----------------------------------------------------------------------------
// Example: Apply lighting and shadow to 3D bubble chart using C#
//
// Description:
// Demonstrates how to apply lighting and shadow to a 3D bubble chart using
// Aspose.Slides for .NET. The example shows the required presentation‑processing
// steps for PowerPoint files and produces the requested output in a standalone
// console application. Developers can use this pattern to automate PPTX workflows,
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Lighting, Shadow,
// 3D Bubble Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying lighting and shadow to 3D bubble charts.
// - Build C# tools for PowerPoint chart processing.
// - Generate or transform PPTX files with 3D bubble charts in .NET applications.
// - Validate chart rendering before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a 3‑D bubble chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

                // Configure 3‑D lighting
                chart.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
                chart.ThreeDFormat.Camera.SetRotation(20, 30, 40);
                chart.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
                chart.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
                chart.ThreeDFormat.Material = MaterialPresetType.Plastic;

                // Apply outer shadow to the chart shape
                chart.EffectFormat.EnableOuterShadowEffect();
                chart.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
                chart.EffectFormat.OuterShadowEffect.Direction = 45.0f;
                chart.EffectFormat.OuterShadowEffect.Distance = 3.0;
                chart.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(0, 0, 0);

                // Remove default series and categories
                int defaultWorksheetIndex = 0;
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                // Add data points (X, Y, BubbleSize)
                series.DataPoints.AddDataPointForBubbleSeries(1.0, 2.0, 30.0);
                series.DataPoints.AddDataPointForBubbleSeries(2.0, 3.0, 40.0);
                series.DataPoints.AddDataPointForBubbleSeries(3.0, 1.5, 20.0);

                // Enable 3‑D effect for each bubble
                for (int i = 0; i < series.DataPoints.Count; i++)
                {
                    Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints[i];
                    point.IsBubble3D = true;
                }

                // Save the presentation
                string outPath = "3DBubbleChart.pptx";
                pres.Save(outPath, SaveFormat.Pptx);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                // Input file not found
                Console.WriteLine("File not found: " + ex.Message);
            }
            // Catch format not supported exceptions (if any)
            // comment: format not supported
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

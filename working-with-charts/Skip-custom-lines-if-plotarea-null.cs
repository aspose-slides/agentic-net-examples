// -----------------------------------------------------------------------------
// Example: Skip custom lines if plotarea null using C#
//
// Description:
// Demonstrates how to add custom error bars to a bubble chart only when the
// chart PlotArea is present, otherwise skipping the operation, using C# and
// Aspose.Slides for .NET. The example shows the required presentation-processing
// steps for PowerPoint files and produces a PPTX file with custom error bars
// when applicable.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Skip, Custom, Error Bars, PlotArea,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding custom error bars to charts while handling missing PlotArea.
// - Build C# tools for PowerPoint chart manipulation.
// - Generate or transform PPTX files with conditional chart enhancements.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble, 0f, 0f, 500f, 400f, true);

            // Ensure PlotArea exists before adding custom error bars
            if (chart.PlotArea != null)
            {
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
                Aspose.Slides.Charts.IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
                Aspose.Slides.Charts.IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

                errBarX.IsVisible = true;
                errBarY.IsVisible = true;
                errBarX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;
                errBarY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;

                Aspose.Slides.Charts.IChartDataPointCollection points = series.DataPoints;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

                for (int i = 0; i < points.Count; i++)
                {
                    points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
                    points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
                    points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
                    points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
                }
            }
            else
            {
                // PlotArea is null, skipping custom error bars
                Console.WriteLine("Chart PlotArea is null. Skipping custom error bars.");
            }

            string outputPath = "CustomErrorBars.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

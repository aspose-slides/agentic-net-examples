using System;
using System.IO;
using Aspose.Slides.Export;

namespace CustomErrorBarsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a bubble chart to the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f, true);

            // Get the first series of the chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Enable custom error bars for X and Y directions
            Aspose.Slides.Charts.IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
            Aspose.Slides.Charts.IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
            errorBarsX.IsVisible = true;
            errorBarsY.IsVisible = true;
            errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;
            errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Custom;

            // Set data source type for custom error values to literal doubles
            Aspose.Slides.Charts.IChartDataPointCollection points = series.DataPoints;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

            // Assign custom error values for each data point
            for (int i = 0; i < points.Count; i++)
            {
                points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
                points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
                points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
                points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
            }

            // Save the presentation
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomErrorBars.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
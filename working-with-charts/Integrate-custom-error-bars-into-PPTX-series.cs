using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace CustomErrorBarsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath;
            string outputPath;

            if (args.Length >= 2)
            {
                inputPath = args[0];
                outputPath = args[1];
            }
            else
            {
                Console.WriteLine("Usage: CustomErrorBarsExample <input.pptx> <output.pptx>");
                return;
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load existing presentation
            Presentation presentation = new Presentation(inputPath);

            // Ensure there is at least one slide
            ISlide slide = presentation.Slides.Count > 0 ? presentation.Slides[0] : presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Add a bubble chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f, true);

            // Get the first series
            IChartSeries series = chart.ChartData.Series[0];

            // Configure X error bars
            IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
            errorBarsX.IsVisible = true;
            errorBarsX.ValueType = ErrorBarValueType.Custom;
            errorBarsX.Type = ErrorBarType.Plus;
            errorBarsX.HasEndCap = true;

            // Configure Y error bars
            IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
            errorBarsY.IsVisible = true;
            errorBarsY.ValueType = ErrorBarValueType.Custom;
            errorBarsY.Type = ErrorBarType.Plus;
            errorBarsY.HasEndCap = true;

            // Set data source types for custom error values
            IChartDataPointCollection points = series.DataPoints;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
            points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

            // Assign custom error values for each data point
            for (int i = 0; i < points.Count; i++)
            {
                points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 0.5;
                points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 0.5;
                points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 0.3;
                points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 0.3;
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}
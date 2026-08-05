// -----------------------------------------------------------------------------
// Example: Export error bars configuration to json using C#
//
// Description:
// Demonstrates how to extract error bar settings from charts in a PowerPoint
// presentation and serialize them to a JSON file using C# and Aspose.Slides for
// .NET. The example loads a PPTX, iterates through all slides and chart shapes,
// captures X and Y error bar properties (including custom values), and writes
// the collected configuration to a JSON document. This pattern can be used to
// analyze, audit, or migrate chart error bar settings in automated workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Error Bars, Chart,
// JSON, Serialization, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of chart error bar configurations for reporting.
// - Build tools that audit or migrate PowerPoint chart settings.
// - Integrate chart analysis into .NET applications.
// - Validate presentation data before publishing or further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ErrorBarExtractor
{
    // Classes for JSON serialization
    public class CustomValueInfo
    {
        public int DataPointIndex { get; set; }
        public double? XMinus { get; set; }
        public double? XPlus { get; set; }
        public double? YMinus { get; set; }
        public double? YPlus { get; set; }
    }

    public class ErrorBarInfo
    {
        public bool IsVisible { get; set; }
        public string Type { get; set; }
        public float Value { get; set; }
        public string ValueType { get; set; }
        public bool HasEndCap { get; set; }
        public List<CustomValueInfo> CustomValues { get; set; }
    }

    public class SeriesInfo
    {
        public int SeriesIndex { get; set; }
        public ErrorBarInfo ErrorBarX { get; set; }
        public ErrorBarInfo ErrorBarY { get; set; }
    }

    public class ChartInfo
    {
        public int SlideIndex { get; set; }
        public int ChartIndex { get; set; }
        public List<SeriesInfo> Series { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string jsonOutputPath = "errorbars.json";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Format not supported or other loading issue
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            List<ChartInfo> chartsInfo = new List<ChartInfo>();

            for (int slideIdx = 0; slideIdx < pres.Slides.Count; slideIdx++)
            {
                ISlide slide = pres.Slides[slideIdx];
                int chartIdx = 0;
                foreach (IShape shape in slide.Shapes)
                {
                    IChart chart = shape as IChart;
                    if (chart == null)
                    {
                        continue;
                    }

                    ChartInfo chartInfo = new ChartInfo
                    {
                        SlideIndex = slideIdx,
                        ChartIndex = chartIdx,
                        Series = new List<SeriesInfo>()
                    };

                    for (int seriesIdx = 0; seriesIdx < chart.ChartData.Series.Count; seriesIdx++)
                    {
                        IChartSeries series = chart.ChartData.Series[seriesIdx];
                        SeriesInfo seriesInfo = new SeriesInfo
                        {
                            SeriesIndex = seriesIdx
                        };

                        // X error bars
                        IErrorBarsFormat errBarsX = series.ErrorBarsXFormat;
                        if (errBarsX != null)
                        {
                            ErrorBarInfo errInfoX = new ErrorBarInfo
                            {
                                IsVisible = errBarsX.IsVisible,
                                Type = errBarsX.Type.ToString(),
                                Value = errBarsX.Value,
                                ValueType = errBarsX.ValueType.ToString(),
                                HasEndCap = errBarsX.HasEndCap
                            };
                            if (errBarsX.ValueType == ErrorBarValueType.Custom)
                            {
                                errInfoX.CustomValues = new List<CustomValueInfo>();
                                IChartDataPointCollection points = series.DataPoints;
                                for (int ptIdx = 0; ptIdx < points.Count; ptIdx++)
                                {
                                    IChartDataPoint point = points[ptIdx];
                                    IErrorBarsCustomValues custom = point.ErrorBarsCustomValues;
                                    if (custom != null)
                                    {
                                        CustomValueInfo cv = new CustomValueInfo
                                        {
                                            DataPointIndex = ptIdx,
                                            XMinus = custom.XMinus?.AsLiteralDouble,
                                            XPlus = custom.XPlus?.AsLiteralDouble,
                                            YMinus = custom.YMinus?.AsLiteralDouble,
                                            YPlus = custom.YPlus?.AsLiteralDouble
                                        };
                                        errInfoX.CustomValues.Add(cv);
                                    }
                                }
                            }
                            seriesInfo.ErrorBarX = errInfoX;
                        }

                        // Y error bars
                        IErrorBarsFormat errBarsY = series.ErrorBarsYFormat;
                        if (errBarsY != null)
                        {
                            ErrorBarInfo errInfoY = new ErrorBarInfo
                            {
                                IsVisible = errBarsY.IsVisible,
                                Type = errBarsY.Type.ToString(),
                                Value = errBarsY.Value,
                                ValueType = errBarsY.ValueType.ToString(),
                                HasEndCap = errBarsY.HasEndCap
                            };
                            if (errBarsY.ValueType == ErrorBarValueType.Custom)
                            {
                                errInfoY.CustomValues = new List<CustomValueInfo>();
                                IChartDataPointCollection points = series.DataPoints;
                                for (int ptIdx = 0; ptIdx < points.Count; ptIdx++)
                                {
                                    IChartDataPoint point = points[ptIdx];
                                    IErrorBarsCustomValues custom = point.ErrorBarsCustomValues;
                                    if (custom != null)
                                    {
                                        CustomValueInfo cv = new CustomValueInfo
                                        {
                                            DataPointIndex = ptIdx,
                                            XMinus = custom.XMinus?.AsLiteralDouble,
                                            XPlus = custom.XPlus?.AsLiteralDouble,
                                            YMinus = custom.YMinus?.AsLiteralDouble,
                                            YPlus = custom.YPlus?.AsLiteralDouble
                                        };
                                        errInfoY.CustomValues.Add(cv);
                                    }
                                }
                            }
                            seriesInfo.ErrorBarY = errInfoY;
                        }

                        chartInfo.Series.Add(seriesInfo);
                    }

                    chartsInfo.Add(chartInfo);
                    chartIdx++;
                }
            }

            // Serialize to JSON
            string json = JsonSerializer.Serialize(chartsInfo, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonOutputPath, json);
            Console.WriteLine("Error bar configuration saved to " + jsonOutputPath);

            // Save presentation before exit (no changes made)
            try
            {
                pres.Save(inputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save exception
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path (first argument or default)
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        // Check if the file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation pres = null;
        try
        {
            pres = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Collect error bar configurations
        List<object> chartsInfo = new List<object>();

        for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
        {
            ISlide slide = pres.Slides[slideIndex];
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                IChart chart = slide.Shapes[shapeIndex] as IChart;
                if (chart == null)
                {
                    continue;
                }

                List<object> seriesInfo = new List<object>();
                for (int seriesIndex = 0; seriesIndex < chart.ChartData.Series.Count; seriesIndex++)
                {
                    IChartSeries series = chart.ChartData.Series[seriesIndex];
                    IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
                    IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;

                    object xInfo = null;
                    if (errorBarsX != null)
                    {
                        xInfo = new
                        {
                            IsVisible = errorBarsX.IsVisible,
                            Type = errorBarsX.Type.ToString(),
                            Value = errorBarsX.Value,
                            ValueType = errorBarsX.ValueType.ToString(),
                            HasEndCap = errorBarsX.HasEndCap
                        };
                    }

                    object yInfo = null;
                    if (errorBarsY != null)
                    {
                        yInfo = new
                        {
                            IsVisible = errorBarsY.IsVisible,
                            Type = errorBarsY.Type.ToString(),
                            Value = errorBarsY.Value,
                            ValueType = errorBarsY.ValueType.ToString(),
                            HasEndCap = errorBarsY.HasEndCap
                        };
                    }

                    seriesInfo.Add(new
                    {
                        SeriesIndex = seriesIndex,
                        ErrorBarsX = xInfo,
                        ErrorBarsY = yInfo
                    });
                }

                chartsInfo.Add(new
                {
                    SlideIndex = slideIndex,
                    ChartIndex = shapeIndex,
                    ChartType = chart.Type.ToString(),
                    Series = seriesInfo
                });
            }
        }

        // Serialize to JSON
        string jsonOutput = JsonSerializer.Serialize(chartsInfo, new JsonSerializerOptions { WriteIndented = true });
        string jsonPath = "errorbars.json";
        try
        {
            File.WriteAllText(jsonPath, jsonOutput);
            Console.WriteLine("Error bar configuration saved to " + jsonPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to write JSON file: " + ex.Message);
        }

        // Save the presentation before exit
        try
        {
            pres.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }

        pres.Dispose();
    }
}
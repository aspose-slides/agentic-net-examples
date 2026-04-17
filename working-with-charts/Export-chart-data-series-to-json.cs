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
        string presentationPath = "input.pptx";
        string jsonOutputPath = "chartData.json";

        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))
            {
                List<object> chartsData = new List<object>();

                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                        if (chart != null)
                        {
                            List<object> seriesList = new List<object>();
                            foreach (Aspose.Slides.Charts.IChartSeries series in chart.ChartData.Series)
                            {
                                List<object> points = new List<object>();
                                foreach (Aspose.Slides.Charts.IChartDataPoint point in series.DataPoints)
                                {
                                    object value = null;
                                    if (point.Value != null && point.Value.Data != null)
                                    {
                                        value = point.Value.Data;
                                    }
                                    points.Add(new { Value = value });
                                }
                                seriesList.Add(new { SeriesName = series.Name, DataPoints = points });
                            }
                            chartsData.Add(new
                            {
                                SlideIndex = slide.SlideNumber,
                                ChartType = chart.Type.ToString(),
                                Series = seriesList
                            });
                        }
                    }
                }

                string json = System.Text.Json.JsonSerializer.Serialize(chartsData, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonOutputPath, json);

                // Save presentation before exit
                presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
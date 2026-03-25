using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.ISlide slide = pres.Slides[0];
                    Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)slide.Shapes[0];

                    // Enable data labels to show values from workbook cells
                    if (chart.ChartData.Series.Count > 0)
                    {
                        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
                        series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

                        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                        // Create cells with label text
                        Aspose.Slides.Charts.IChartDataCell cellA10 = workbook.GetCell(0, 9, 0, "Label A");
                        Aspose.Slides.Charts.IChartDataCell cellA11 = workbook.GetCell(0, 10, 0, "Label B");
                        Aspose.Slides.Charts.IChartDataCell cellA12 = workbook.GetCell(0, 11, 0, "Label C");

                        // Assign cells to the first three data labels
                        series.Labels[0].ValueFromCell = cellA10;
                        series.Labels[1].ValueFromCell = cellA11;
                        series.Labels[2].ValueFromCell = cellA12;
                    }

                    // Apply number format to all data points
                    foreach (Aspose.Slides.Charts.IChartSeries seriesItem in chart.ChartData.Series)
                    {
                        foreach (Aspose.Slides.Charts.IChartDataPoint dataPoint in seriesItem.DataPoints)
                        {
                            dataPoint.Value.AsCell.PresetNumberFormat = 10; // 0.00%
                        }
                    }

                    // Set solid fill color for the first series
                    if (chart.ChartData.Series.Count > 0)
                    {
                        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
                        series.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                        series.Format.Fill.SolidFillColor.Color = Color.Blue;
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing presentation: " + ex.Message);
            }
        }
    }
}
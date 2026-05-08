using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace DoughnutChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
                {
                    // Access the first slide
                    Aspose.Slides.ISlide slide = pres.Slides[0];

                    // Add a doughnut chart
                    Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                        Aspose.Slides.Charts.ChartType.Doughnut,
                        50f, 50f, 500f, 400f);

                    // Clear default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Get the chart data workbook
                    Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    int defaultWorksheetIndex = 0;

                    // Define categories and values
                    string[] categories = new string[] { "Category A", "Category B", "Category C" };
                    double[] values = new double[] { 30.0, 50.0, 20.0 };

                    // Add a single series for the doughnut chart
                    Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                        workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                        Aspose.Slides.Charts.ChartType.Doughnut);

                    // Populate categories and data points
                    for (int i = 0; i < categories.Length; i++)
                    {
                        chart.ChartData.Categories.Add(
                            workbook.GetCell(defaultWorksheetIndex, i + 1, 0, categories[i]));

                        series.DataPoints.AddDataPointForDoughnutSeries(values[i]);
                    }

                    // Show percentage values on the doughnut slices
                    series.Labels.DefaultDataLabelFormat.ShowPercentage = true;

                    // Calculate total sum of values
                    double total = 0;
                    foreach (double v in values)
                    {
                        total += v;
                    }

                    // Add a central label (auto shape) to display the total
                    Aspose.Slides.IAutoShape totalLabel = slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle,
                        chart.X + chart.Width / 2 - 50f,
                        chart.Y + chart.Height / 2 - 15f,
                        100f,
                        30f);

                    // Add text frame with the total value
                    Aspose.Slides.ITextFrame textFrame = totalLabel.AddTextFrame(total.ToString());
                    textFrame.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                    // Save the presentation
                    pres.Save("DoughnutChartWithTotal.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (System.Exception ex)
            {
                // Handle any unexpected errors (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
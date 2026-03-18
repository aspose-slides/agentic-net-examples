using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            using (Presentation pres = new Presentation("input.pptx"))
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Find the first chart on the slide
                IChart chart = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is IChart)
                    {
                        chart = (IChart)shape;
                        break;
                    }
                }

                if (chart != null)
                {
                    // Access the embedded workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    int defaultWorksheetIndex = 0;

                    // Clear existing series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add new categories
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                    // Add first series and its data points
                    IChartSeries series1 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 25));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 55));
                    series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 35));

                    // Add second series and its data points
                    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 40));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 20));
                    series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 70));
                }

                // Save the updated presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
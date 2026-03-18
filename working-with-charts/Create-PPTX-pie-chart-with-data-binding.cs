using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide's shape collection
            Aspose.Slides.IShapeCollection shapes = pres.Slides[0].Shapes;

            // Add a pie chart
            Aspose.Slides.Charts.IChart chart = shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie,
                50f, 50f, 400f, 400f);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the workbook for creating cells
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                chart.Type);

            // Enable varied colors for the series (instead of setting FillType)
            series.ParentSeriesGroup.IsColorVaried = true;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category C"));

            // Add data points for the pie series
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
            series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 20));

            // Show values on data labels
            Aspose.Slides.Charts.IDataLabel label0 = series.DataPoints[0].Label;
            label0.DataLabelFormat.ShowValue = true;
            Aspose.Slides.Charts.IDataLabel label1 = series.DataPoints[1].Label;
            label1.DataLabelFormat.ShowValue = true;
            Aspose.Slides.Charts.IDataLabel label2 = series.DataPoints[2].Label;
            label2.DataLabelFormat.ShowValue = true;

            // Save the presentation
            pres.Save("PieChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
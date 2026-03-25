using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to an optional input presentation
        string inputPath = "template.pptx";
        Aspose.Slides.Presentation pres;

        // Load existing presentation if it exists, otherwise create a new one
        if (File.Exists(inputPath))
        {
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            Console.WriteLine("Input file not found: " + inputPath);
            pres = new Aspose.Slides.Presentation();
        }

        using (pres)
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Enable the data table for the chart
            chart.HasDataTable = true;

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sales Summary");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            chart.ChartTitle.Height = 20f;

            // Get the chart data workbook to populate data
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add two series
            Aspose.Slides.Charts.IChartSeries series2019 = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "2019"), chart.Type);
            Aspose.Slides.Charts.IChartSeries series2020 = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 2, "2020"), chart.Type);

            // Add four categories (quarters)
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Q3"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "Q4"));

            // Populate data for 2019 series
            series2019.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 120));
            series2019.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 150));
            series2019.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 170));
            series2019.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 4, 1, 200));

            // Populate data for 2020 series
            series2020.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 130));
            series2020.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 160));
            series2020.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 180));
            series2020.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 4, 2, 210));

            // Save the presentation
            string outputPath = "ChartWithDataTable_out.pptx";
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine("Presentation saved to " + outputPath);
        }
    }
}
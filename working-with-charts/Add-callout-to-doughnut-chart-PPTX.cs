using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using Aspose.Slides;

namespace DoughnutCalloutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a doughnut chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 50f, 50f, 500f, 400f);

            // Get the chart's data workbook
            IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            int defaultWorksheetIndex = 0;

            // Add categories
            chart.ChartData.Categories.Add(workBook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workBook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workBook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add a series
            IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

            // Add data points for the doughnut series
            IChartDataPoint dataPoint1 = series.DataPoints.AddDataPointForDoughnutSeries(workBook.GetCell(defaultWorksheetIndex, 1, 1, 30));
            IChartDataPoint dataPoint2 = series.DataPoints.AddDataPointForDoughnutSeries(workBook.GetCell(defaultWorksheetIndex, 2, 1, 70));
            IChartDataPoint dataPoint3 = series.DataPoints.AddDataPointForDoughnutSeries(workBook.GetCell(defaultWorksheetIndex, 3, 1, 50));

            // Format the second data point (highlight with callout)
            dataPoint2.Format.Fill.FillType = FillType.Solid;
            dataPoint2.Format.Line.FillFormat.FillType = FillType.Solid;
            dataPoint2.Format.Line.Style = LineStyle.Single;
            dataPoint2.Format.Line.DashStyle = LineDashStyle.Solid;

            // Get the data label for the second data point
            IDataLabel lbl = dataPoint2.Label;

            // Enable callout for the data label
            lbl.DataLabelFormat.ShowLabelAsDataCallout = true;

            // Additional label formatting
            lbl.TextFormat.TextBlockFormat.AutofitType = TextAutofitType.Shape;
            lbl.DataLabelFormat.TextFormat.PortionFormat.FontBold = NullableBool.True;
            lbl.DataLabelFormat.TextFormat.PortionFormat.LatinFont = new FontData("Arial");
            lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;

            // Save the presentation
            pres.Save("DoughnutCallout.pptx", SaveFormat.Pptx);
        }
    }
}
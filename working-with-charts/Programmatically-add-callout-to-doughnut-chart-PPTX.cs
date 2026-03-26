using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        var inputPath = args.Length > 0 ? args[0] : "input.pptx";
        var outputPath = args.Length > 1 ? args[1] : "output.pptx";

        // Load existing presentation if it exists, otherwise create a new one
        var pres = File.Exists(inputPath) ? new Presentation(inputPath) : new Presentation();

        // Get the first slide
        var slide = pres.Slides[0];

        // Add a doughnut chart with sample data
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Doughnut, 50f, 50f, 500f, 400f, true);
        var workBook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add a series
        var series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add categories and data points with callout annotations
        for (int i = 0; i < 3; i++)
        {
            var categoryName = "Category " + (i + 1);
            chart.ChartData.Categories.Add(workBook.GetCell(0, i + 1, 0, categoryName));

            var value = 10 + i * 10;
            var dataPoint = series.DataPoints.AddDataPointForDoughnutSeries(workBook.GetCell(0, i + 1, 1, value));

            // Set fill and line formatting for the callout
            dataPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            dataPoint.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            dataPoint.Format.Line.Style = Aspose.Slides.LineStyle.Single;
            dataPoint.Format.Line.DashStyle = Aspose.Slides.LineDashStyle.Solid;

            // Configure the data label as a callout
            var lbl = dataPoint.Label;
            lbl.TextFormat.TextBlockFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;
            lbl.DataLabelFormat.ShowLabelAsDataCallout = true;
            lbl.DataLabelFormat.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
            lbl.DataLabelFormat.TextFormat.PortionFormat.LatinFont = new Aspose.Slides.FontData("Arial");
            lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        }

        // Save the presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
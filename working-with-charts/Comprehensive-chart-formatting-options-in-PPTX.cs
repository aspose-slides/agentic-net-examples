using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartFormattingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to an optional template presentation
            string templatePath = "template.pptx";
            Aspose.Slides.Presentation presentation = null;

            try
            {
                // Load template if it exists, otherwise create a new presentation
                if (File.Exists(templatePath))
                {
                    presentation = new Aspose.Slides.Presentation(templatePath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Input file not found: " + ex.FileName);
                return;
            }

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // -------------------------------------------------
            // 1. Pie chart with automatic slice colors
            // -------------------------------------------------
            Aspose.Slides.Charts.IChart pieChart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 300);
            pieChart.HasTitle = true;
            pieChart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");
            pieChart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            pieChart.ChartTitle.Height = 20;

            // Clear default data
            Aspose.Slides.Charts.IChartDataWorkbook pieWorkbook = pieChart.ChartData.ChartDataWorkbook;
            pieChart.ChartData.Series.Clear();
            pieChart.ChartData.Categories.Clear();

            // Add categories (product names)
            pieChart.ChartData.Categories.Add(pieWorkbook.GetCell(0, 1, 0, "Product A"));
            pieChart.ChartData.Categories.Add(pieWorkbook.GetCell(0, 2, 0, "Product B"));
            pieChart.ChartData.Categories.Add(pieWorkbook.GetCell(0, 3, 0, "Product C"));

            // Add a series with sales values
            Aspose.Slides.Charts.IChartSeries pieSeries = pieChart.ChartData.Series.Add(
                pieWorkbook.GetCell(0, 0, 1, "Sales"), pieChart.Type);
            pieSeries.DataPoints.AddDataPointForPieSeries(pieWorkbook.GetCell(0, 1, 1, 30));
            pieSeries.DataPoints.AddDataPointForPieSeries(pieWorkbook.GetCell(0, 2, 1, 45));
            pieSeries.DataPoints.AddDataPointForPieSeries(pieWorkbook.GetCell(0, 3, 1, 25));

            // Enable automatic varied colors for each slice
            pieSeries.ParentSeriesGroup.IsColorVaried = true;

            // Show data labels as callouts
            pieChart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
            pieChart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

            // -------------------------------------------------
            // 2. Clustered column chart with automatic series colors
            // -------------------------------------------------
            Aspose.Slides.Charts.IChart columnChart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn, 500, 50, 400, 300);
            columnChart.HasTitle = true;
            columnChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
            columnChart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            columnChart.ChartTitle.Height = 20;

            // Clear default data
            Aspose.Slides.Charts.IChartDataWorkbook columnWorkbook = columnChart.ChartData.ChartDataWorkbook;
            columnChart.ChartData.Series.Clear();
            columnChart.ChartData.Categories.Clear();

            // Add categories (quarters)
            columnChart.ChartData.Categories.Add(columnWorkbook.GetCell(0, 1, 0, "Q1"));
            columnChart.ChartData.Categories.Add(columnWorkbook.GetCell(0, 2, 0, "Q2"));
            columnChart.ChartData.Categories.Add(columnWorkbook.GetCell(0, 3, 0, "Q3"));
            columnChart.ChartData.Categories.Add(columnWorkbook.GetCell(0, 4, 0, "Q4"));

            // Add first series
            Aspose.Slides.Charts.IChartSeries columnSeries1 = columnChart.ChartData.Series.Add(
                columnWorkbook.GetCell(0, 0, 1, "Product A"), columnChart.Type);
            columnSeries1.DataPoints.AddDataPointForBarSeries(columnWorkbook.GetCell(0, 1, 1, 120));
            columnSeries1.DataPoints.AddDataPointForBarSeries(columnWorkbook.GetCell(0, 2, 1, 150));
            columnSeries1.DataPoints.AddDataPointForBarSeries(columnWorkbook.GetCell(0, 3, 1, 170));
            columnSeries1.DataPoints.AddDataPointForBarSeries(columnWorkbook.GetCell(0, 4, 1, 200));

            // Add second series
            Aspose.Slides.Charts.IChartSeries columnSeries2 = columnChart.ChartData.Series.Add(
                columnWorkbook.GetCell(0, 0, 2, "Product B"), columnChart.Type);
            columnSeries2.DataPoints.AddDataPointForBarSeries(columnWorkbook.GetCell(0, 1, 2, 80));
            columnSeries2.DataPoints.AddDataPointForBarSeries(columnWorkbook.GetCell(0, 2, 2, 110));
            columnSeries2.DataPoints.AddDataPointForBarSeries(columnWorkbook.GetCell(0, 3, 2, 130));
            columnSeries2.DataPoints.AddDataPointForBarSeries(columnWorkbook.GetCell(0, 4, 2, 160));

            // Use automatic series colors by setting FillType to NotDefined
            columnSeries1.Format.Fill.FillType = Aspose.Slides.FillType.NotDefined;
            columnSeries2.Format.Fill.FillType = Aspose.Slides.FillType.NotDefined;

            // Show values on data labels
            columnChart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            columnChart.ChartData.Series[1].Labels.DefaultDataLabelFormat.ShowValue = true;

            // Customize plot area background using a scheme color
            columnChart.PlotArea.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            columnChart.PlotArea.Format.Fill.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;

            // Add a border line to the plot area
            columnChart.PlotArea.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            columnChart.PlotArea.Format.Line.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent4;
            columnChart.PlotArea.Format.Line.Width = 2;

            // Axis titles
            columnChart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("Quarter");
            columnChart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Revenue (in $K)");
            columnChart.Axes.VerticalAxis.Title.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

            // -------------------------------------------------
            // Save the presentation
            // -------------------------------------------------
            presentation.Save("ChartFormattingDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // -----------------------------------------------------------------
        // 1. Chart with rounded corners and line formatting
        // -----------------------------------------------------------------
        Aspose.Slides.Charts.IChart roundedChart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);
        roundedChart.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        roundedChart.LineFormat.Style = Aspose.Slides.LineStyle.Single;
        roundedChart.HasRoundedCorners = true;

        // Change series colors
        Aspose.Slides.Charts.IChartSeries series0 = roundedChart.ChartData.Series[0];
        series0.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series0.Format.Fill.SolidFillColor.Color = System.Drawing.Color.FromArgb(255, 0, 0); // Red

        Aspose.Slides.Charts.IChartSeries series1 = roundedChart.ChartData.Series[1];
        series1.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        series1.Format.Fill.SolidFillColor.Color = System.Drawing.Color.FromArgb(0, 255, 0); // Green

        // -----------------------------------------------------------------
        // 2. Automatic series color (NotDefined)
        // -----------------------------------------------------------------
        Aspose.Slides.Charts.IChart autoChart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 500f, 50f, 400f, 300f);
        Aspose.Slides.Charts.IChartSeries autoSeries = autoChart.ChartData.Series[0];
        autoSeries.Format.Fill.FillType = Aspose.Slides.FillType.NotDefined; // Automatic

        // -----------------------------------------------------------------
        // 3. Pie of Pie chart with second plot options
        // -----------------------------------------------------------------
        Aspose.Slides.Charts.IChart pieOfPieChart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.PieOfPie, 50f, 400f, 400f, 300f);
        pieOfPieChart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        pieOfPieChart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 150;
        pieOfPieChart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
        pieOfPieChart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 30.0;

        // -----------------------------------------------------------------
        // 4. Sunburst chart with colored data points and labels
        // -----------------------------------------------------------------
        Aspose.Slides.Charts.IChart sunburstChart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Sunburst, 500f, 400f, 400f, 300f);
        Aspose.Slides.Charts.IChartDataPointCollection sunburstPoints = sunburstChart.ChartData.Series[0].DataPoints;

        // Show value for a specific level
        sunburstPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;

        // Color a branch label
        Aspose.Slides.Charts.IDataLabel branchLabel = sunburstPoints[0].DataPointLevels[2].Label;
        branchLabel.DataLabelFormat.ShowCategoryName = true;
        branchLabel.DataLabelFormat.ShowSeriesName = true;
        branchLabel.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        branchLabel.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;

        // Color a data point
        Aspose.Slides.Charts.IFormat steam4Format = sunburstPoints[9].Format;
        steam4Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        steam4Format.Fill.SolidFillColor.Color = System.Drawing.Color.FromArgb(255, 128, 0, 128); // ARGB

        // -----------------------------------------------------------------
        // 5. Bubble chart with width representation
        // -----------------------------------------------------------------
        Aspose.Slides.Charts.IChart bubbleChart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 750f, 400f, 300f);
        bubbleChart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

        // -----------------------------------------------------------------
        // 6. Change color of a specific category (data point)
        // -----------------------------------------------------------------
        Aspose.Slides.Charts.IChart columnChart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 500f, 750f, 400f, 300f);
        Aspose.Slides.Charts.IChartDataPoint point = columnChart.ChartData.Series[0].DataPoints[0];
        point.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        point.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Blue;

        // -----------------------------------------------------------------
        // 7. Leader line color for a pie chart
        // -----------------------------------------------------------------
        Aspose.Slides.Charts.IChart leaderChart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 950f, 50f, 400f, 300f);
        if (leaderChart != null && leaderChart.ChartData.Series.Count > 0)
        {
            Aspose.Slides.Charts.IChartSeries leaderSeries = leaderChart.ChartData.Series[0];
            if (leaderSeries.Labels.Count > 0)
            {
                Aspose.Slides.Charts.IDataLabelCollection leaderLabels = leaderSeries.Labels;
                leaderLabels.LeaderLinesFormat.Line.FillFormat.SolidFillColor.Color =
                    System.Drawing.Color.FromArgb(255, 0, 0, 255); // Blue
            }
        }

        // -----------------------------------------------------------------
        // Save the presentation
        // -----------------------------------------------------------------
        string outputPath = "ChartFormattingDemo.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
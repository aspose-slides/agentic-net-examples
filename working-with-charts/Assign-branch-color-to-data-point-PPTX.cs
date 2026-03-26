using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "BranchColorChart.pptx";

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a Sunburst chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 50f, 50f, 500f, 400f);

        // Get the data points collection of the first series
        IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

        // Set a specific branch color for the first data point's first level label
        IDataLabel branchLabel = dataPoints[0].DataPointLevels[0].Label;
        branchLabel.DataLabelFormat.ShowCategoryName = true;
        branchLabel.DataLabelFormat.ShowSeriesName = true;
        branchLabel.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
        branchLabel.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.FromArgb(255, 0, 128, 0); // Dark green

        // Optionally set fill color for another data point (e.g., index 3)
        IFormat pointFormat = dataPoints[3].Format;
        pointFormat.Fill.FillType = FillType.Solid;
        pointFormat.Fill.SolidFillColor.Color = System.Drawing.Color.FromArgb(255, 255, 165, 0); // Orange

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "ColumnChartSwitchRowsColumns.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 600f, 400f);

        // Switch rows and columns in the chart data
        chart.ChartData.SwitchRowColumn();

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
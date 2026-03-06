using System;

class Program
{
    static void Main(string[] args)
    {
        // Output file paths
        string presentationPath = "ExportedChart.pptx";
        string chartImagePath = "ChartImage.png";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);

        // Enable data labels to show values for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Export the chart as an image (PNG)
        Aspose.Slides.IImage chartImage = chart.GetImage();
        chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);

        // Save the presentation containing the chart
        presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
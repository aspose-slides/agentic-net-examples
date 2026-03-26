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

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Enable display of data point values
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Set a number format for the displayed values
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0.00%";

        // Save the presentation
        presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
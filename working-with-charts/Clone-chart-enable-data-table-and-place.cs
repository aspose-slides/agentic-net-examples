using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart originalChart = firstSlide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Enable the data table for the chart
        originalChart.HasDataTable = true;

        // Clone the slide containing the chart and insert it at index 1 (second slide)
        Aspose.Slides.ISlide clonedSlide = presentation.Slides.InsertClone(1, firstSlide);

        // Save the presentation
        string outputPath = "ClonedChartPresentation.pptx";
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // If the file format is not supported, handle accordingly
            // format not supported
        }
    }
}
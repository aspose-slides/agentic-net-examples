using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "InputPresentation.pptx";
        string outputPath = "OutputPresentation.pptx";

        // Load existing presentation if it exists; otherwise create a new one
        Aspose.Slides.Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            presentation = new Aspose.Slides.Presentation();
        }

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a stacked column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.StackedColumn,
            50, 50, 500, 400);

        // Enable display of values and percentages on data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

        // Set numeric format for percentages
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
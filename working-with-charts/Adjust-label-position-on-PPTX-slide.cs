using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load existing presentation if it exists, otherwise create a new one
        Presentation presentation;
        if (File.Exists(inputPath))
        {
            presentation = new Presentation(inputPath);
        }
        else
        {
            presentation = new Presentation();
        }

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);

        // Modify the position of the data label for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.InsideEnd;

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}
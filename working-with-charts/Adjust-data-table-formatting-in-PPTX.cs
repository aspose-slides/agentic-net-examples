using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        // Load the existing presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a new pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 400f, 300f);

        // Change the chart data range (example range)
        chart.ChartData.SetRange("Sheet1!$A$1:$B$5");

        // Adjust the layout of the chart's plot area
        chart.PlotArea.AsILayoutable.X = 10f;
        chart.PlotArea.AsILayoutable.Y = 10f;
        chart.PlotArea.AsILayoutable.Width = 380f;
        chart.PlotArea.AsILayoutable.Height = 280f;
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;

        // Customize data labels for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = true;
        chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = " - ";

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
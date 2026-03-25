using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (args.Length > 0)
        {
            inputPath = args[0];
        }
        if (args.Length > 1)
        {
            outputPath = args[1];
        }

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Try to get an existing chart; if none, add a new Pie chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
        if (chart == null)
        {
            chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 400f, 300f);
        }

        // Adjust chart plot area layout
        chart.PlotArea.AsILayoutable.X = 10f;
        chart.PlotArea.AsILayoutable.Y = 10f;
        chart.PlotArea.AsILayoutable.Width = 380f;
        chart.PlotArea.AsILayoutable.Height = 280f;
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;

        // Show data table
        chart.HasDataTable = true;

        // Switch rows and columns in chart data
        chart.ChartData.SwitchRowColumn();

        // Customize data labels for the first series
        if (chart.ChartData.Series.Count > 0)
        {
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLeaderLines = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowCategoryName = true;
            chart.ChartData.Series[0].Labels[0].DataLabelFormat.Separator = " - ";
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
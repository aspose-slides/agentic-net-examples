using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);

            // Customize plot area dimensions (as fractions of the chart size)
            chart.PlotArea.AsILayoutable.X = 0.2f;
            chart.PlotArea.AsILayoutable.Y = 0.2f;
            chart.PlotArea.AsILayoutable.Width = 0.7f;
            chart.PlotArea.AsILayoutable.Height = 0.7f;

            // Set plot area background fill
            chart.PlotArea.Format.Fill.FillType = FillType.Solid;
            chart.PlotArea.Format.Fill.SolidFillColor.SchemeColor = SchemeColor.Accent1;

            // Example axis positioning: hide the vertical axis
            IAxis verticalAxis = chart.Axes.VerticalAxis;
            verticalAxis.IsVisible = false;

            // Save the modified presentation
            string outputPath = "output.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}
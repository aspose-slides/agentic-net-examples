using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation from the existing file
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Retrieve the first shape as a chart (adjust index if needed)
        Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;

        if (chart != null)
        {
            // Change the data range of the chart
            chart.ChartData.SetRange("Sheet1!$A$1:$B$5");

            // Set the horizontal axis to be positioned between categories
            chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

            // Show values in the default data label of the first series
            if (chart.ChartData.Series.Count > 0)
            {
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            }

            // Modify the first data point of the first series
            if (chart.ChartData.Series.Count > 0 && chart.ChartData.Series[0].DataPoints.Count > 0)
            {
                Aspose.Slides.Charts.IChartDataPoint point = chart.ChartData.Series[0].DataPoints[0];

                // Set a solid red fill for the data point
                point.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                point.Format.Fill.SolidFillColor.Color = Color.Red;

                // Show the category name in the data label of this point
                point.Label.DataLabelFormat.ShowCategoryName = true;
            }
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}
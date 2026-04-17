using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.html";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Access the first series
                IChartSeries series = chart.ChartData.Series[0];

                // Enable callout for data labels
                series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                // Set sample data for the first point
                IChartDataPoint point0 = series.DataPoints[0];
                point0.Value.Data = 50;

                // Style the callout fill
                point0.Format.Fill.FillType = FillType.Solid;
                point0.Format.Fill.SolidFillColor.Color = Color.Yellow;

                // Style the callout line
                point0.Format.Line.FillFormat.FillType = FillType.Solid;
                point0.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

                // Confirm that callouts are enabled
                bool calloutEnabled = series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout;
                Console.WriteLine("Callout enabled: " + calloutEnabled);

                // Save the presentation as HTML5
                Html5Options options = new Html5Options();
                options.EmbedImages = true;
                pres.Save(outputPath, SaveFormat.Html5, options);
            }
        }
        catch (NotSupportedException ex)
        {
            // Handle unsupported format
            Console.WriteLine("The requested format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
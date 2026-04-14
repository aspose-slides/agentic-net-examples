using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddFormattedCalloutToLineChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "LineChartWithCallout.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a line chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Line,
                    50f, 50f, 600f, 400f);

                // Access the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));

                // Populate series with data points
                series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 10));
                series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 30));
                series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, 20));

                // Enable callouts for all data labels in the series
                series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
                series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

                // Choose the second data point (index 1) to annotate
                Aspose.Slides.Charts.IChartDataPoint dataPoint = series.DataPoints[1];

                // Format the data point's fill and line (optional visual styling)
                dataPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                dataPoint.Format.Fill.SolidFillColor.Color = Color.LightBlue;
                dataPoint.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                dataPoint.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
                dataPoint.Format.Line.Style = Aspose.Slides.LineStyle.Single;
                dataPoint.Format.Line.DashStyle = Aspose.Slides.LineDashStyle.Solid;

                // Access the data label of the selected data point
                Aspose.Slides.Charts.IDataLabel dataLabel = dataPoint.Label;

                // Add custom text to the callout using AddTextFrameForOverriding
                Aspose.Slides.ITextFrame calloutTextFrame = dataLabel.AddTextFrameForOverriding("Peak Value");

                // Format the callout text (font, fill, etc.)
                calloutTextFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;
                dataLabel.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                dataLabel.TextFormat.PortionFormat.FontHeight = 14;
                dataLabel.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                dataLabel.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., file I/O errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
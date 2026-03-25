using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartFormattingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Aspose.Slides.Presentation presentation = null;
            try
            {
                if (args.Length > 0)
                {
                    string inputPath = args[0];
                    if (!File.Exists(inputPath))
                    {
                        throw new FileNotFoundException($"Input file not found: {inputPath}");
                    }
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();
                }

                // Access first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a PieOfPie chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.PieOfPie,
                    50f, 50f, 500f, 400f);

                // Show values for the first series
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

                // Configure second plot options
                chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 30; // UInt16
                chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
                chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 20.0; // Double

                // Set custom legend position and size
                chart.Legend.X = 550f;
                chart.Legend.Y = 50f;
                chart.Legend.Width = 150f;
                chart.Legend.Height = 200f;

                // Ensure series use automatic colors (NotDefined)
                chart.ChartData.Series[0].Format.Fill.FillType = Aspose.Slides.FillType.NotDefined;
                if (chart.ChartData.Series.Count > 1)
                {
                    chart.ChartData.Series[1].Format.Fill.FillType = Aspose.Slides.FillType.NotDefined;
                }

                // Save the presentation
                string outputPath = "FormattedChartPresentation.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
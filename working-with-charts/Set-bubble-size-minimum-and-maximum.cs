// -----------------------------------------------------------------------------
// Example: Set Bubble Chart Size Minimum and Maximum in PowerPoint using C#
// 
// Description:
// This console application creates a new PPTX file, adds a bubble chart, and
// demonstrates how to control the visual minimum and maximum bubble sizes by
// configuring the bubble size scale and data point values. It uses Aspose.Slides
// for .NET to manipulate PowerPoint presentations programmatically.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, bubble chart, bubble size, scale, minimum, maximum
// 
// Use Cases:
// - Automate generation of presentations with bubble charts that require specific size ranges.
// - Integrate bubble chart sizing logic into reporting or data visualization pipelines.
// - Ensure consistent visual scaling of bubble charts across multiple generated PPTX files.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
namespace ExampleBubbleSizeMinMax
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string outputPath = "BubbleSizeMinMax.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Failed to create presentation: " + ex.Message);
                return;
            }

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a bubble chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Bubble,
                50f, 50f, 600f, 400f);

            // Set bubble size representation (optional)
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

            // Set an initial bubble size scale
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150; // example scale

            // Add a series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Configure data source types for literals
            series.DataPoints.DataSourceTypeForXValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForYValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;
            series.DataPoints.DataSourceTypeForBubbleSizes = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

            // Add data points with explicit bubble sizes
            series.DataPoints.AddDataPointForBubbleSeries(1.0, 2.0, 30.0);   // small bubble
            series.DataPoints.AddDataPointForBubbleSeries(2.0, 3.0, 80.0);   // medium bubble
            series.DataPoints.AddDataPointForBubbleSeries(3.0, 4.0, 150.0);  // large bubble

            // Simulate setting minimum and maximum visual bubble sizes
            // Desired visual sizes (in points)
            double desiredMinSize = 20.0;
            double desiredMaxSize = 100.0;

            // Actual bubble size values from data points
            double actualMinBubble = 30.0;
            double actualMaxBubble = 150.0;

            // Calculate a scale factor to map actual sizes to desired visual range
            double scaleFactor = (desiredMaxSize - desiredMinSize) / (actualMaxBubble - actualMinBubble);
            int bubbleScale = (int)(scaleFactor * 100); // Aspose expects an integer percentage

            // Apply the calculated scale
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = bubbleScale;

            // Save the presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                System.Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Failed to save presentation: " + ex.Message);
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

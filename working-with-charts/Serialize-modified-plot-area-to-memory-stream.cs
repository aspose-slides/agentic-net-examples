using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a line chart to the first slide
            ISlide slide = presentation.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.Line, 50f, 50f, 450f, 300f);

            // Modify the plot area size (fraction of chart size)
            chart.PlotArea.Height = 0.8f; // 80% of chart height
            chart.PlotArea.Width = 0.9f;  // 90% of chart width

            // Calculate actual layout values
            chart.ValidateChartLayout();
            float actualWidthBefore = chart.PlotArea.ActualWidth;
            float actualHeightBefore = chart.PlotArea.ActualHeight;

            Console.WriteLine("Actual PlotArea size before serialization: Width = " + actualWidthBefore + ", Height = " + actualHeightBefore);

            // Serialize presentation to a memory stream
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                presentation.Save(memoryStream, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
                // Format not supported comment
                // format not supported
                return;
            }

            // Reset stream position for reading
            memoryStream.Position = 0;

            // Reload presentation from the memory stream
            Presentation loadedPresentation = null;
            try
            {
                loadedPresentation = new Presentation(memoryStream);
            }
            catch (Exception ex)
            {
                // Handle loading errors (e.g., corrupted stream)
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Access the chart in the loaded presentation
            IChart loadedChart = loadedPresentation.Slides[0].Shapes[0] as IChart;
            if (loadedChart != null)
            {
                loadedChart.ValidateChartLayout();
                float actualWidthAfter = loadedChart.PlotArea.ActualWidth;
                float actualHeightAfter = loadedChart.PlotArea.ActualHeight;

                Console.WriteLine("Actual PlotArea size after deserialization: Width = " + actualWidthAfter + ", Height = " + actualHeightAfter);
            }

            // Save the presentation to a file before exiting (optional)
            try
            {
                presentation.Save("ModifiedChart.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle file format not supported
                Console.WriteLine("Error saving to file: " + ex.Message);
                // format not supported
            }

            // Clean up resources
            presentation.Dispose();
            loadedPresentation?.Dispose();
            memoryStream.Dispose();
        }
    }
}
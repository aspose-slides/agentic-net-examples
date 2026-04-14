using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a stacked area chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.StackedArea,
                50f, 50f, 500f, 400f);

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Stacked Area Chart");

            // Enable data labels to show both value and category for each series
            int seriesCount = chart.ChartData.Series.Count;
            for (int i = 0; i < seriesCount; i++)
            {
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[i];
                series.Labels.DefaultDataLabelFormat.ShowValue = true;
                series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
            }

            // Save the presentation
            pres.Save("StackedAreaDataLabels.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // Handle missing file if any input files were used
            System.Console.WriteLine("File not found: " + ex.Message);
        }
        catch (System.NotSupportedException ex)
        {
            // format not supported
            System.Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (System.Exception ex)
        {
            // General exception handling
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
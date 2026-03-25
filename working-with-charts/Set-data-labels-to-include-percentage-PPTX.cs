using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a stacked column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.StackedColumn, 50f, 50f, 500f, 400f);

            // Configure data labels to show values and percentages
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

            // Set number format to display percentage sign
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";

            // Save the presentation
            presentation.Save("ChartWithPercentageLabels.pptx", SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine("Input file not found: " + ex.FileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
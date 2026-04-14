using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace HideAxisLines
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a chart to the first slide
                ISlide slide = presentation.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Hide horizontal axis line while keeping the axis labels visible
                IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
                // Ensure axis labels remain visible
                horizontalAxis.IsVisible = true;

                // Hide vertical axis line while keeping the axis labels visible
                IAxis verticalAxis = chart.Axes.VerticalAxis;
                verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
                verticalAxis.IsVisible = true;

                // Save the presentation
                presentation.Save("HideAxisLines.pptx", SaveFormat.Pptx);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                // Handle missing input files if any were used
                Console.WriteLine("Input file not found: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                // Handle unsupported file format
                // Format not supported
                Console.WriteLine("File format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling for external URLs or web services
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
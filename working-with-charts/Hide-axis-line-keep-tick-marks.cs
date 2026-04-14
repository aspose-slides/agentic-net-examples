using System;
using System.IO;
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
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Hide the horizontal axis line while keeping tick marks visible
                IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

                // Hide the vertical axis line while keeping tick marks visible
                IAxis verticalAxis = chart.Axes.VerticalAxis;
                verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

                // Save the presentation
                pres.Save("HideAxisLine.pptx", SaveFormat.Pptx);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.FileName);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        Presentation presentation = null;

        // Load existing presentation if it exists, otherwise create a new one
        if (File.Exists(inputPath))
        {
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported or the file is corrupted.");
                return;
            }
        }
        else
        {
            presentation = new Presentation();
        }

        // Define a set of marker styles to assign uniquely per series
        MarkerStyleType[] markerStyles = new MarkerStyleType[]
        {
            MarkerStyleType.Circle,
            MarkerStyleType.Diamond,
            MarkerStyleType.Square,
            MarkerStyleType.Triangle,
            MarkerStyleType.X,
            MarkerStyleType.Plus,
            MarkerStyleType.Star,
            MarkerStyleType.Dash,
            MarkerStyleType.Dot,
            MarkerStyleType.None
        };

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                IShape shape = slide.Shapes[shapeIndex];
                IChart chart = shape as IChart;

                if (chart != null)
                {
                    IChartSeriesCollection seriesCollection = chart.ChartData.Series;

                    // Iterate through each series in the chart
                    for (int i = 0; i < seriesCollection.Count; i++)
                    {
                        IChartSeries series = seriesCollection[i];
                        IMarker marker = series.Marker;

                        // Assign a unique marker shape based on the series index
                        MarkerStyleType style = markerStyles[i % markerStyles.Length];
                        marker.Symbol = style;

                        // Existing error bar settings are preserved automatically
                    }
                }
            }
        }

        // Save the modified presentation
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            presentation.Dispose();
        }
    }
}
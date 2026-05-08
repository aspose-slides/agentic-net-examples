using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string sourcePath = "source.pptx";
        string outputPath = "output.pptx";

        // Check if source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        try
        {
            // Load the source presentation
            using (Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(sourcePath))
            {
                // Get the first slide (assumed to contain the chart)
                Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[0];
                Aspose.Slides.Charts.IChart sourceChart = sourceSlide.Shapes[0] as Aspose.Slides.Charts.IChart;

                if (sourceChart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                    return;
                }

                // Clone the slide containing the chart to position 1
                Aspose.Slides.ISlideCollection slideCollection = sourcePres.Slides;
                Aspose.Slides.ISlide clonedSlide = slideCollection.InsertClone(1, sourceSlide);

                // Get the cloned chart (assumed to be the first shape)
                Aspose.Slides.Charts.IChart clonedChart = clonedSlide.Shapes[0] as Aspose.Slides.Charts.IChart;

                if (clonedChart != null && clonedChart.ChartData.Series.Count > 0)
                {
                    // Modify the first series of the cloned chart
                    clonedChart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
                }

                // Save the modified presentation
                sourcePres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
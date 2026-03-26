using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the first chart on the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;
        if (chart != null)
        {
            // Change the category axis to a date axis
            chart.Axes.HorizontalAxis.CategoryAxisType = Aspose.Slides.Charts.CategoryAxisType.Date;

            // Set major unit properties
            chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
            chart.Axes.HorizontalAxis.MajorUnit = 1.0;
            chart.Axes.HorizontalAxis.MajorUnitScale = Aspose.Slides.Charts.TimeUnitType.Months;
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
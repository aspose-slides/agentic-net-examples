using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a clustered column chart
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);

        // Define manual layout for the plot area
        chart.PlotArea.AsILayoutable.X = 0.2f;
        chart.PlotArea.AsILayoutable.Y = 0.2f;
        chart.PlotArea.AsILayoutable.Width = 0.7f;
        chart.PlotArea.AsILayoutable.Height = 0.7f;

        // Determine desired LayoutTargetType based on user input
        LayoutTargetType target = LayoutTargetType.Inner; // default
        if (args.Length > 0)
        {
            string pref = args[0].ToLowerInvariant();
            if (pref == "inner")
                target = LayoutTargetType.Inner;
            else if (pref == "outer")
                target = LayoutTargetType.Outer;
        }

        // Toggle the LayoutTargetType
        ToggleLayoutTargetType(chart, target);

        // Save the presentation
        try
        {
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        pres.Dispose();
    }

    static void ToggleLayoutTargetType(IChart chart, LayoutTargetType target)
    {
        // Set the LayoutTargetType property of the plot area
        chart.PlotArea.LayoutTargetType = target;
    }
}
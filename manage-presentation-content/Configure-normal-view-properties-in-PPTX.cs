using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "demo.pptx";
        string outputPath = "presentation_normal_view_state.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Manipulate normal view properties via INormalViewProperties
        pres.ViewProperties.NormalViewProperties.HorizontalBarState = Aspose.Slides.SplitterBarStateType.Restored;
        pres.ViewProperties.NormalViewProperties.VerticalBarState = Aspose.Slides.SplitterBarStateType.Maximized;
        pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
        pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
        pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}
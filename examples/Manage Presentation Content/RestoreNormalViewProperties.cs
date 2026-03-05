using System;
using System.IO;

namespace RestoreNormalViewPropertiesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.ppt");
            string outputPath = Path.Combine(dataDir, "output.ppt");

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Configure Normal View properties
            pres.ViewProperties.NormalViewProperties.HorizontalBarState = Aspose.Slides.SplitterBarStateType.Restored;
            pres.ViewProperties.NormalViewProperties.VerticalBarState = Aspose.Slides.SplitterBarStateType.Maximized;
            pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
            pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80f;
            pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

            // Save the presentation in PPT format
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

            // Release resources
            pres.Dispose();
        }
    }
}
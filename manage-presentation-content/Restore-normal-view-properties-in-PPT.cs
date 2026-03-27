using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationNormalViewDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            var inputPath = args.Length > 0 ? args[0] : "input.pptx";
            var outputPath = args.Length > 1 ? args[1] : "output_normal_view.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load presentation
            var pres = new Aspose.Slides.Presentation(inputPath);

            // Restore normal view properties
            pres.ViewProperties.NormalViewProperties.HorizontalBarState = Aspose.Slides.SplitterBarStateType.Restored;
            pres.ViewProperties.NormalViewProperties.VerticalBarState = Aspose.Slides.SplitterBarStateType.Maximized;
            pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
            pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80f;
            pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

            // Save presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            pres.Dispose();

            Console.WriteLine($"Presentation saved to: {outputPath}");
        }
    }
}
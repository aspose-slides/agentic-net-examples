using System;
using System.IO;
using Aspose.Slides.Export;

namespace RestoreNormalView
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Restore normal view properties
            presentation.ViewProperties.NormalViewProperties.HorizontalBarState = Aspose.Slides.SplitterBarStateType.Restored;
            presentation.ViewProperties.NormalViewProperties.VerticalBarState = Aspose.Slides.SplitterBarStateType.Maximized;
            presentation.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
            presentation.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80f;
            presentation.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

            // Save the updated presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}
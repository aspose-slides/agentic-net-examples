using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RestoreNormalViewProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                string inputPath = "input.pptx";
                // Path to the output presentation
                string outputPath = "output.pptx";

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Access normal view properties
                    INormalViewProperties normalView = presentation.ViewProperties.NormalViewProperties;

                    // Set splitter bar states
                    normalView.HorizontalBarState = SplitterBarStateType.Restored;
                    normalView.VerticalBarState = SplitterBarStateType.Maximized;

                    // Show outline icons
                    normalView.ShowOutlineIcons = true;

                    // Configure restored top region
                    normalView.RestoredTop.AutoAdjust = true;
                    normalView.RestoredTop.DimensionSize = 80f;

                    // Configure restored left region
                    normalView.RestoredLeft.AutoAdjust = true;
                    normalView.RestoredLeft.DimensionSize = 200f;

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace PresentationOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "overview.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the source presentation
            using (Presentation sourcePres = new Presentation(inputPath))
            {
                // Extract all text frames (including masters)
                ITextFrame[] textFrames = SlideUtil.GetAllTextFrames(sourcePres, true);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (ITextFrame tf in textFrames)
                {
                    if (tf != null && tf.Text != null)
                    {
                        sb.AppendLine(tf.Text);
                    }
                }

                // Create a new presentation for overview
                using (Presentation overviewPres = new Presentation())
                {
                    // Add a new slide using the layout of the first slide of source
                    ILayoutSlide layout = sourcePres.Slides[0].LayoutSlide;
                    ISlide overviewSlide = overviewPres.Slides.AddEmptySlide(layout);

                    // Add a textbox shape with the overview text
                    IAutoShape textBox = overviewSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 600, 400);
                    textBox.AddTextFrame(sb.ToString());

                    // Save the overview presentation
                    overviewPres.Save(outputPath, SaveFormat.Pptx);
                }
            }
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DisableAutofitExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (ISlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Process only AutoShape objects that contain a TextFrame
                            if (shape is IAutoShape)
                            {
                                IAutoShape autoShape = (IAutoShape)shape;
                                if (autoShape.TextFrame != null)
                                {
                                    // Disable automatic text fitting
                                    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
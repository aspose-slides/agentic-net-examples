using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Util;

namespace ReplaceSmartArtExample
{
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Check if the slide contains the target keyword in any text box
                        ITextFrame[] keywordFrames = SlideUtil.GetTextBoxesContainsText(slide, "Keyword", false);
                        if (keywordFrames.Length == 0)
                        {
                            continue; // No keyword on this slide, skip
                        }

                        // Iterate through shapes on the slide to find SmartArt with BasicProcess layout
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Cast the shape to SmartArt if possible
                            Aspose.Slides.SmartArt.SmartArt smartArt = shape as Aspose.Slides.SmartArt.SmartArt;
                            if (smartArt != null)
                            {
                                // Check for BasicProcess layout
                                if (smartArt.Layout == SmartArtLayoutType.BasicProcess)
                                {
                                    // Replace layout with BasicCycle
                                    smartArt.Layout = SmartArtLayoutType.BasicCycle;
                                    Console.WriteLine($"Replaced SmartArt layout on slide {slideIndex + 1}");
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported – handle accordingly
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace SmartArtLayoutReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
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

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is a SmartArt diagram
                            if (shape is SmartArt)
                            {
                                SmartArt smartArt = (SmartArt)shape;

                                // If the SmartArt layout is BasicCycle, replace it with BasicProcess
                                if (smartArt.Layout == SmartArtLayoutType.BasicCycle)
                                {
                                    smartArt.Layout = SmartArtLayoutType.BasicProcess;
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
                // Handle unsupported file format or other loading errors
                Console.WriteLine("An error occurred while processing the presentation: " + ex.Message);
                // Comment: format not supported
            }
        }
    }
}
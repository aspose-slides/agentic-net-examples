using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
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
                        IShapeCollection shapes = slide.Shapes;

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                        {
                            // Try to cast the shape to ISmartArt
                            ISmartArt smartArt = shapes[shapeIndex] as ISmartArt;
                            if (smartArt != null)
                            {
                                // Check if the SmartArt layout is BasicCycle
                                if (smartArt.Layout == SmartArtLayoutType.BasicCycle)
                                {
                                    // Change layout to PictureAccentBlocks
                                    smartArt.Layout = SmartArtLayoutType.PictureAccentBlocks;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // The file format is not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (PptUnsupportedFormatException)
            {
                // The file format is not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
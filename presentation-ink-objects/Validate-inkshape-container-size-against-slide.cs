using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace ValidateInkShapeSize
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths (can be replaced with args or other sources)
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
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Retrieve the slide size (read‑only ISlideSize)
                    Aspose.Slides.ISlideSize slideSize = presentation.SlideSize;
                    float slideWidth = slideSize.Size.Width;
                    float slideHeight = slideSize.Size.Height;

                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is an Ink object
                            Aspose.Slides.Ink.Ink inkShape = shape as Aspose.Slides.Ink.Ink;
                            if (inkShape != null)
                            {
                                // Validate container size against slide dimensions
                                bool widthMatches = Math.Abs(inkShape.Width - slideWidth) < 0.01f;
                                bool heightMatches = Math.Abs(inkShape.Height - slideHeight) < 0.01f;

                                if (!widthMatches || !heightMatches)
                                {
                                    // Adjust the Ink shape to match the slide size to avoid clipping
                                    inkShape.X = 0f;
                                    inkShape.Y = 0f;
                                    inkShape.Width = slideWidth;
                                    inkShape.Height = slideHeight;

                                    Console.WriteLine($"Adjusted Ink shape on slide {slide.SlideNumber} to match slide size.");
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException notSupportedEx)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported: " + notSupportedEx.Message);
            }
            catch (Exception ex)
            {
                // General exception handling (including possible web service or URL errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
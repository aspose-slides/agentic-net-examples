using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace ExportMathMLExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through shapes on the slide
                        for (int shapeIdx = 0; shapeIdx < slide.Shapes.Count; shapeIdx++)
                        {
                            IShape shape = slide.Shapes[shapeIdx];
                            IAutoShape autoShape = shape as IAutoShape;

                            // Check if shape contains a MathPortion
                            if (autoShape != null &&
                                autoShape.TextFrame != null &&
                                autoShape.TextFrame.Paragraphs.Count > 0 &&
                                autoShape.TextFrame.Paragraphs[0].Portions.Count > 0 &&
                                autoShape.TextFrame.Paragraphs[0].Portions[0] is MathPortion)
                            {
                                // Retrieve the MathParagraph
                                IMathParagraph mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                                // Define output MathML file path
                                string outputPath = $"slide_{slideIndex}_shape_{shapeIdx}.mml";

                                // Export MathParagraph to MathML
                                using (FileStream fs = File.Create(outputPath))
                                {
                                    mathParagraph.WriteAsMathMl(fs);
                                }

                                // Log details
                                Console.WriteLine($"Slide {slideIndex}, Shape '{shape.Name}', exported to {outputPath}");
                            }
                        }
                    }

                    // Save the (potentially modified) presentation
                    string outputPresentation = "output.pptx";
                    pres.Save(outputPresentation, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Format not supported.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
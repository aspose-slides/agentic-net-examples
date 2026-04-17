using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesSmartArtFontChange
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
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
                            if (shape is ISmartArt smartArt)
                            {
                                // Iterate through all nodes (including child nodes)
                                foreach (ISmartArtNode node in smartArt.AllNodes)
                                {
                                    // Ensure the node has a text frame
                                    if (node.TextFrame != null)
                                    {
                                        // Iterate through all paragraphs
                                        for (int paraIndex = 0; paraIndex < node.TextFrame.Paragraphs.Count; paraIndex++)
                                        {
                                            IParagraph paragraph = node.TextFrame.Paragraphs[paraIndex];

                                            // Iterate through all portions (runs) in the paragraph
                                            for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                                            {
                                                IPortion portion = paragraph.Portions[portionIndex];

                                                // Set the Latin font to Arial using FontData
                                                portion.PortionFormat.LatinFont = new FontData("Arial");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the updated presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
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
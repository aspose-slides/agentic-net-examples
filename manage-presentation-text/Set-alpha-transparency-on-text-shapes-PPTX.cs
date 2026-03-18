using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesAlphaTransparency
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to input and output files
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Process only AutoShapes that contain a TextFrame
                        if (shape is IAutoShape)
                        {
                            IAutoShape autoShape = (IAutoShape)shape;
                            if (autoShape.TextFrame != null)
                            {
                                // Iterate through paragraphs
                                for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                                {
                                    IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];

                                    // Iterate through portions (text runs)
                                    for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                                    {
                                        IPortion portion = paragraph.Portions[portionIndex];
                                        IPortionFormat portionFormat = portion.PortionFormat;
                                        IFillFormat fillFormat = portionFormat.FillFormat;

                                        // Set solid fill with desired alpha transparency (e.g., 128 out of 255)
                                        fillFormat.FillType = FillType.Solid;
                                        fillFormat.SolidFillColor.Color = Color.FromArgb(128, Color.Black);
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveHyperlinks
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                string sourcePath = "input.pptx";
                // Path to the output presentation
                string outputPath = "output.pptx";

                // Load the presentation
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Remove hyperlink from shape if it exists
                            // The HyperlinkClick property can be set to null to remove the hyperlink
                            // (If the property is read‑only in the used version, this line can be omitted)
                            shape.HyperlinkClick = null;
                            shape.HyperlinkMouseOver = null;
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
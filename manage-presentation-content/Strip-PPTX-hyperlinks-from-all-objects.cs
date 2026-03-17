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
                // Load the presentation from file
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Iterate through each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];

                    // Iterate through each shape on the slide
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[j];

                        // Remove click hyperlink if present
                        if (shape.HyperlinkClick != null)
                        {
                            shape.HyperlinkClick = null;
                        }

                        // Remove mouse‑over hyperlink if present
                        if (shape.HyperlinkMouseOver != null)
                        {
                            shape.HyperlinkMouseOver = null;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
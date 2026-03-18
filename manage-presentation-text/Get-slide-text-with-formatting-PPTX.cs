using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Index of the slide to extract (0‑based)
            int slideIndex = 0;

            if (slideIndex < 0 || slideIndex >= presentation.Slides.Count)
            {
                Console.WriteLine("Invalid slide index.");
            }
            else
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Process only AutoShape objects that contain a TextFrame
                    if (shape is Aspose.Slides.IAutoShape)
                    {
                        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                        if (autoShape.TextFrame != null)
                        {
                            // Iterate through paragraphs and portions to get text and formatting
                            foreach (Aspose.Slides.IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                            {
                                foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                                {
                                    string text = portion.Text;
                                    Aspose.Slides.IPortionFormatEffectiveData effectiveFormat = portion.PortionFormat.GetEffective();

                                    float fontHeight = effectiveFormat.FontHeight;
                                    string latinFont = effectiveFormat.LatinFont != null ? effectiveFormat.LatinFont.FontName : "N/A";

                                    Console.WriteLine($"Text: {text}");
                                    Console.WriteLine($"Font: {latinFont}, Size: {fontHeight}");
                                }
                            }
                        }
                    }
                }
            }

            // Save the (unchanged) presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
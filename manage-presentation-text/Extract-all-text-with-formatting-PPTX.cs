using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

            // Extract raw text preserving slide order
            Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                inputPath,
                Aspose.Slides.TextExtractionArrangingMode.Unarranged);

            for (int i = 0; i < presentationText.SlidesText.Length; i++)
            {
                Aspose.Slides.ISlideText slideText = presentationText.SlidesText[i];
                Console.WriteLine($"--- Slide {i + 1} ---");
                Console.WriteLine("Text: " + slideText.Text);
                Console.WriteLine("Master Text: " + slideText.MasterText);
                Console.WriteLine("Layout Text: " + slideText.LayoutText);
                Console.WriteLine("Notes Text: " + slideText.NotesText);
                Console.WriteLine("Comments Text: " + slideText.CommentsText);
            }

            // Load presentation to retrieve formatting metadata
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                    Console.WriteLine($"--- Formatting for Slide {slideIndex + 1} ---");

                    // Get all text frames (including masters) and filter by current slide
                    Aspose.Slides.ITextFrame[] allTextFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pres, true);
                    foreach (Aspose.Slides.ITextFrame tf in allTextFrames)
                    {
                        if (tf.Slide == slide)
                        {
                            foreach (Aspose.Slides.IParagraph paragraph in tf.Paragraphs)
                            {
                                foreach (Aspose.Slides.Portion portion in paragraph.Portions)
                                {
                                    Console.WriteLine($"Portion Text: {portion.Text}");
                                    Console.WriteLine($"Font: {portion.PortionFormat.LatinFont?.FontName}, Size: {portion.PortionFormat.FontHeight}");
                                    Console.WriteLine($"Bold: {portion.PortionFormat.FontBold}, Italic: {portion.PortionFormat.FontItalic}");
                                }
                            }
                        }
                    }
                }

                // Save presentation before exit (no modifications made)
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
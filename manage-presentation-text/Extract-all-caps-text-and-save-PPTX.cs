using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Presentation pres = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];

                    // Get all text boxes on the current slide
                    ITextFrame[] textFrames = SlideUtil.GetAllTextBoxes(slide);

                    foreach (ITextFrame textFrame in textFrames)
                    {
                        // Iterate through paragraphs
                        foreach (IParagraph paragraph in textFrame.Paragraphs)
                        {
                            // Iterate through portions (runs of text)
                            foreach (IPortion portion in paragraph.Portions)
                            {
                                // Check if the portion uses the All‑Caps effect
                                if (portion.PortionFormat.TextCapType == TextCapType.All)
                                {
                                    // Output the text; formatting is retained in the portion object
                                    Console.WriteLine(portion.Text);
                                }
                            }
                        }
                    }
                }

                // Save the (potentially modified) presentation before exiting
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Retrieve all text frames on the slide
                Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

                if (textFrames != null && textFrames.Length > 0)
                {
                    // Get the first text frame
                    Aspose.Slides.ITextFrame textFrame = textFrames[0];

                    // Retrieve the first paragraph from the text frame
                    Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

                    // Example usage: output paragraph count
                    Console.WriteLine("Paragraph count in first text frame: " + textFrame.Paragraphs.Count);
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
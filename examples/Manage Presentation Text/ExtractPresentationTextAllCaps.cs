using System;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

namespace PresentationTextExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation
            Presentation presentation = new Presentation("input.pptx");

            // Get all text frames from the presentation, including master slides
            ITextFrame[] textFrames = SlideUtil.GetAllTextFrames(presentation, true);

            // Iterate through each text frame
            foreach (ITextFrame textFrame in textFrames)
            {
                // Iterate through each paragraph in the text frame
                foreach (IParagraph paragraph in textFrame.Paragraphs)
                {
                    // Iterate through each portion in the paragraph
                    foreach (IPortion portion in paragraph.Portions)
                    {
                        // Check if the portion has All-Caps effect applied
                        if (portion.PortionFormat.TextCapType == TextCapType.All)
                        {
                            // Output the text of the portion
                            Console.WriteLine(portion.Text);
                        }
                    }
                }
            }

            // Save the presentation (even if unchanged) before exiting
            presentation.Save("output.pptx", SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}
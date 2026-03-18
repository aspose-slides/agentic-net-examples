using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace AlignTextBaseline
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load the presentation
                var presentation = new Presentation("input.pptx");

                // Get all text frames including those in master slides
                var textFrames = SlideUtil.GetAllTextFrames(presentation, true);

                // Iterate through each text frame
                foreach (var textFrame in textFrames)
                {
                    // Iterate through each paragraph in the text frame
                    foreach (var paragraph in textFrame.Paragraphs)
                    {
                        // Set vertical alignment to baseline for consistent positioning
                        paragraph.ParagraphFormat.FontAlignment = FontAlignment.Baseline;
                    }
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
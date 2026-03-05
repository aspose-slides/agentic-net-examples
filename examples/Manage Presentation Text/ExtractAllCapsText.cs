using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Util;

namespace ExtractAllCapsText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";
            // Path to the output presentation (saved before exit)
            string outputPath = "output.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Get all text frames from the presentation (including master slides)
                Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

                // List to hold extracted all-caps text
                List<string> allCapsTexts = new List<string>();

                // Iterate through each text frame
                foreach (Aspose.Slides.ITextFrame textFrame in textFrames)
                {
                    // Iterate through each paragraph in the text frame
                    foreach (Aspose.Slides.IParagraph paragraph in textFrame.Paragraphs)
                    {
                        // Iterate through each portion in the paragraph
                        foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                        {
                            // Check if the portion has All-Caps effect
                            if (portion.PortionFormat.TextCapType == Aspose.Slides.TextCapType.All)
                            {
                                // Add the text of the portion to the list
                                allCapsTexts.Add(portion.Text);
                            }
                        }
                    }
                }

                // Output the extracted all-caps text to console
                Console.WriteLine("Extracted All-Caps Text:");
                foreach (string text in allCapsTexts)
                {
                    Console.WriteLine(text);
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}
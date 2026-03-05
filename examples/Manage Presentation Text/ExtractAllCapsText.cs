using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

public class Program
{
    public static void Main()
    {
        // Path to the source presentation
        string inputPath = "input.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Retrieve all text frames (excluding master slides)
            Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, false);

            // List to store extracted text with All-Caps effect
            System.Collections.Generic.List<string> allCapsTexts = new System.Collections.Generic.List<string>();

            // Iterate through each text frame
            foreach (Aspose.Slides.ITextFrame textFrame in textFrames)
            {
                // Iterate through paragraphs within the text frame
                foreach (Aspose.Slides.IParagraph paragraph in textFrame.Paragraphs)
                {
                    // Iterate through portions within the paragraph
                    foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                    {
                        // Check if the portion has All-Caps effect
                        if (portion.PortionFormat.TextCapType == Aspose.Slides.TextCapType.All)
                        {
                            allCapsTexts.Add(portion.Text);
                        }
                    }
                }
            }

            // Output the extracted All-Caps text
            foreach (string txt in allCapsTexts)
            {
                Console.WriteLine(txt);
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
using System;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                string sourcePath = "input.pptx";
                // Path to save the presentation after processing
                string outputPath = "output.pptx";

                // Load the presentation
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    // Get all text frames, including those in master slides
                    ITextFrame[] textFrames = SlideUtil.GetAllTextFrames(presentation, true);

                    // Iterate through each text frame
                    foreach (ITextFrame textFrame in textFrames)
                    {
                        // Iterate through paragraphs in the text frame
                        foreach (IParagraph paragraph in textFrame.Paragraphs)
                        {
                            // Iterate through portions (runs) in the paragraph
                            foreach (IPortion portion in paragraph.Portions)
                            {
                                // Check if the portion has All-Caps capitalization
                                if (portion.PortionFormat.TextCapType == TextCapType.All)
                                {
                                    // Output the text of the portion
                                    Console.WriteLine(portion.Text);
                                }
                            }
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
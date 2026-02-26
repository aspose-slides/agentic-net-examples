using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

namespace ManagePresentationText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // List to hold all-caps text portions
            List<string> allCapsTexts = new List<string>();

            // Iterate through each slide
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                // Get all text frames on the slide
                Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

                // Iterate through each text frame
                foreach (Aspose.Slides.ITextFrame textFrame in textFrames)
                {
                    // Iterate through paragraphs
                    foreach (Aspose.Slides.IParagraph paragraph in textFrame.Paragraphs)
                    {
                        // Iterate through portions
                        foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                        {
                            // Check if the portion is all caps
                            if (portion.PortionFormat.TextCapType == Aspose.Slides.TextCapType.All)
                            {
                                allCapsTexts.Add(portion.Text);
                            }
                        }
                    }
                }
            }

            // Output the extracted all-caps text
            foreach (string text in allCapsTexts)
            {
                Console.WriteLine(text);
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}
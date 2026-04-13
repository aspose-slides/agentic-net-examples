using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace AsposeSlidesHyperlinkExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // List to store extracted hyperlink URLs
                    List<string> extractedLinks = new List<string>();

                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Get all text boxes (text frames) on the current slide
                        ITextFrame[] textFrames = SlideUtil.GetAllTextBoxes(slide);

                        // Iterate through each text frame
                        foreach (ITextFrame textFrame in textFrames)
                        {
                            // Iterate through paragraphs in the text frame
                            for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                            {
                                IParagraph paragraph = textFrame.Paragraphs[paraIndex];

                                // Iterate through portions in the paragraph
                                for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                                {
                                    IPortion portion = paragraph.Portions[portionIndex];

                                    // Access the hyperlink via PortionFormat.HyperlinkClick
                                    IHyperlink hyperlink = portion.PortionFormat.HyperlinkClick;

                                    if (hyperlink != null)
                                    {
                                        // Use ExternalUrlOriginal to get the original URL string
                                        string url = hyperlink.ExternalUrlOriginal;
                                        extractedLinks.Add(url);
                                        Console.WriteLine("Slide " + slideIndex + " - Hyperlink: " + url);
                                    }
                                }
                            }
                        }
                    }

                    // Save the presentation before exiting (as required)
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other loading errors
                // Comment: format not supported
                Console.WriteLine("An error occurred while processing the presentation: " + ex.Message);
            }
        }
    }
}
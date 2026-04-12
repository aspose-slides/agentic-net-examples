using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetRightToLeftArabic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output presentation path
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation with exception handling for unsupported formats
            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Define which slide indices to process (0‑based). Example: first three slides.
                    int[] slideIndices = new int[] { 0, 1, 2 };

                    foreach (int slideIndex in slideIndices)
                    {
                        // Ensure the slide index is within range
                        if (slideIndex < 0 || slideIndex >= presentation.Slides.Count)
                        {
                            continue;
                        }

                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Process only AutoShape objects that contain a TextFrame
                            IAutoShape autoShape = shape as IAutoShape;
                            if (autoShape == null || autoShape.TextFrame == null)
                            {
                                continue;
                            }

                            ITextFrame textFrame = autoShape.TextFrame;

                            // Iterate through all paragraphs in the TextFrame
                            for (int p = 0; p < textFrame.Paragraphs.Count; p++)
                            {
                                IParagraph paragraph = textFrame.Paragraphs[p];

                                // Set right‑to‑left direction for Arabic text.
                                // Here we set it for all paragraphs; in a real scenario you could check the language.
                                paragraph.ParagraphFormat.RightToLeft = Aspose.Slides.NullableBool.True;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., network errors if a URL was used)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
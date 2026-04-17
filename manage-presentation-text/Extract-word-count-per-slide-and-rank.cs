using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractWordCountPerSlide
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect the presentation file path as the first argument
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the path to a presentation file.");
                return;
            }

            string inputPath = args[0];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"File not found: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Extract raw text from the presentation using a valid extraction mode
                    IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                        inputPath,
                        Aspose.Slides.TextExtractionArrangingMode.Unarranged);

                    // Prepare a list to hold slide index and word count
                    List<Tuple<int, int>> slideWordCounts = new List<Tuple<int, int>>();

                    // Iterate over each slide's extracted text
                    ISlideText[] slidesText = presentationText.SlidesText;
                    for (int i = 0; i < slidesText.Length; i++)
                    {
                        ISlideText slideText = slidesText[i];
                        string text = slideText.Text ?? string.Empty;

                        // Count words by splitting on whitespace characters
                        string[] words = text.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        int wordCount = words.Length;

                        // Store slide number (1‑based) and its word count
                        slideWordCounts.Add(new Tuple<int, int>(i + 1, wordCount));
                    }

                    // Sort slides by word count descending
                    slideWordCounts.Sort((a, b) => b.Item2.CompareTo(a.Item2));

                    // Output ranking list
                    Console.WriteLine("Slide ranking by word count (descending):");
                    foreach (Tuple<int, int> entry in slideWordCounts)
                    {
                        Console.WriteLine($"Slide {entry.Item1}: {entry.Item2} words");
                    }

                    // Save the presentation before exiting (optional: save to a new file)
                    string outputPath = Path.Combine(
                        Path.GetDirectoryName(inputPath) ?? string.Empty,
                        Path.GetFileNameWithoutExtension(inputPath) + "_out.pptx");
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX files
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported for PPT files
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
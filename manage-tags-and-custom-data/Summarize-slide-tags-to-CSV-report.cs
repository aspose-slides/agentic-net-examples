using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SummarizeSlideTags
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string csvPath = "slide_tags_report.csv";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Prepare CSV writer
                    using (StreamWriter writer = new StreamWriter(csvPath, false))
                    {
                        // Write CSV header
                        writer.WriteLine("SlideIndex,TagName,TagValue");

                        // Iterate through slides
                        for (int i = 0; i < presentation.Slides.Count; i++)
                        {
                            ISlide slide = presentation.Slides[i];
                            ITagCollection tags = slide.CustomData.Tags;

                            // If the slide has tags, write them to CSV
                            if (tags.Count > 0)
                            {
                                string[] tagNames = tags.GetNamesOfTags();
                                for (int t = 0; t < tagNames.Length; t++)
                                {
                                    string name = tagNames[t];
                                    string value = tags.GetValueByIndex(t);
                                    // Escape commas in values
                                    string escapedValue = value?.Replace(",", "&#44;");
                                    writer.WriteLine($"{i + 1},{name},{escapedValue}");
                                }
                            }
                        }
                    }

                    // Save the presentation (no modifications, but required by lifecycle rule)
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }

                Console.WriteLine($"Tag summary written to {csvPath}");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
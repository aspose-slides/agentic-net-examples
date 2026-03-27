using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace BatchSmartArtExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output CSV file path
            string outputCsvPath = "SmartArtText.csv";

            // Create CSV writer
            using (StreamWriter csvWriter = new StreamWriter(outputCsvPath))
            {
                // Write CSV header
                csvWriter.WriteLine("File,SlideNumber,ShapeIndex,SmartArtText");

                // Process each presentation file passed as argument
                foreach (string inputFilePath in args)
                {
                    // Check if the file exists
                    if (!File.Exists(inputFilePath))
                    {
                        Console.WriteLine($"File not found: {inputFilePath}");
                        continue;
                    }

                    // Load the presentation
                    using (Presentation presentation = new Presentation(inputFilePath))
                    {
                        // Iterate through slides
                        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                        {
                            ISlide slide = presentation.Slides[slideIndex];

                            // Iterate through shapes on the slide
                            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                            {
                                IShape shape = slide.Shapes[shapeIndex];

                                // Check if the shape is a SmartArt shape
                                if (shape is ISmartArtShape)
                                {
                                    ISmartArtShape smartArtShape = (ISmartArtShape)shape;

                                    // Access the TextFrame of the SmartArt shape
                                    ITextFrame textFrame = smartArtShape.TextFrame;

                                    // Retrieve text (empty string if TextFrame is null)
                                    string smartArtText = textFrame != null ? textFrame.Text : string.Empty;

                                    // Escape double quotes for CSV
                                    string escapedText = smartArtText.Replace("\"", "\"\"");

                                    // Write record to CSV
                                    csvWriter.WriteLine($"{Path.GetFileName(inputFilePath)},{slideIndex + 1},{shapeIndex + 1},\"{escapedText}\"");
                                }
                            }
                        }

                        // Save the presentation before exiting (as required by lifecycle rules)
                        presentation.Save(inputFilePath, SaveFormat.Pptx);
                    }
                }
            }

            Console.WriteLine($"SmartArt text extraction completed. Results saved to {outputCsvPath}");
        }
    }
}
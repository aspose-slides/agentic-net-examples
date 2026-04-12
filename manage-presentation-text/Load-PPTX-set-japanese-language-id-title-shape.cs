using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
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
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Iterate through shapes to find the title placeholder
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape.Placeholder != null && shape is IAutoShape)
                        {
                            // Check if the placeholder is a centered title
                            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle)
                            {
                                IAutoShape titleShape = (IAutoShape)shape;

                                // Set LanguageId to Japanese for all portions in the title shape
                                foreach (IParagraph paragraph in titleShape.TextFrame.Paragraphs)
                                {
                                    foreach (IPortion portion in paragraph.Portions)
                                    {
                                        portion.PortionFormat.LanguageId = "ja-JP";
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the exception is due to unsupported format, the format is not supported.
            }
        }
    }
}
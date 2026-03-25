using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace StandardizeTextInPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Predefined placeholders and their replacements
            string placeholderCompany = "[CompanyName]";
            string replacementCompany = "Acme Corp";

            string placeholderYear = "[Year]";
            string replacementYear = DateTime.Now.Year.ToString();

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                ISlide slide = pres.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Process only AutoShape objects that contain a TextFrame
                    if (shape is IAutoShape)
                    {
                        IAutoShape autoShape = (IAutoShape)shape;
                        ITextFrame textFrame = autoShape.TextFrame;

                        if (textFrame == null)
                            continue;

                        // Iterate through all paragraphs
                        for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                        {
                            IParagraph paragraph = textFrame.Paragraphs[paraIndex];

                            // Iterate through all portions within the paragraph
                            for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                            {
                                IPortion portion = paragraph.Portions[portionIndex];
                                string originalText = portion.Text;

                                // Replace placeholders with predefined constants
                                if (originalText.Contains(placeholderCompany))
                                {
                                    portion.Text = originalText.Replace(placeholderCompany, replacementCompany);
                                }

                                if (originalText.Contains(placeholderYear))
                                {
                                    portion.Text = originalText.Replace(placeholderYear, replacementYear);
                                }
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            pres.Dispose();

            Console.WriteLine("Presentation saved successfully to " + outputPath);
        }
    }
}
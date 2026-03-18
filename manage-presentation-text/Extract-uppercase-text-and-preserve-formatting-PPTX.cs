using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "uppercase_output.pptx");

            // Load source presentation
            Presentation sourcePres = new Presentation(inputFile);
            // Create result presentation (starts with one empty slide)
            Presentation resultPres = new Presentation();
            // Remove the default empty slide
            resultPres.Slides.RemoveAt(0);

            // Iterate through each slide
            for (int slideIndex = 0; slideIndex < sourcePres.Slides.Count; slideIndex++)
            {
                ISlide srcSlide = sourcePres.Slides[slideIndex];
                // Clone the slide into the result presentation
                ISlide destSlide = resultPres.Slides.AddClone(srcSlide);

                // Process each shape on the cloned slide
                for (int shapeIndex = 0; shapeIndex < destSlide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = destSlide.Shapes[shapeIndex] as IShape;
                    IAutoShape autoShape = shape as IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        ITextFrame textFrame = autoShape.TextFrame;
                        // Iterate through paragraphs
                        for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                        {
                            IParagraph paragraph = textFrame.Paragraphs[paraIndex];
                            // Iterate portions backwards to allow removal
                            for (int portionIndex = paragraph.Portions.Count - 1; portionIndex >= 0; portionIndex--)
                            {
                                IPortion portion = paragraph.Portions[portionIndex];
                                string originalText = portion.Text;
                                StringBuilder sb = new StringBuilder();
                                // Keep only uppercase characters
                                for (int ch = 0; ch < originalText.Length; ch++)
                                {
                                    char c = originalText[ch];
                                    if (char.IsUpper(c))
                                    {
                                        sb.Append(c);
                                    }
                                }
                                string upperText = sb.ToString();
                                if (upperText.Length == 0)
                                {
                                    // Remove portion if it contains no uppercase text
                                    paragraph.Portions.RemoveAt(portionIndex);
                                }
                                else
                                {
                                    // Replace text while preserving formatting
                                    portion.Text = upperText;
                                }
                            }
                        }
                    }
                }
            }

            // Save the resulting presentation
            resultPres.Save(outputFile, SaveFormat.Pptx);
            sourcePres.Dispose();
            resultPres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
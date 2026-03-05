using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

namespace ExtractAllCapsText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Load the presentation (needed for saving later)
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Extract raw text from the presentation using the Unarranged mode
            Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                inputPath,
                Aspose.Slides.TextExtractionArrangingMode.Unarranged);

            // Iterate through each slide's text and output all‑caps words
            for (int i = 0; i < presentationText.SlidesText.Length; i++)
            {
                Aspose.Slides.ISlideText slideText = presentationText.SlidesText[i];
                string text = slideText.Text;

                // Split the slide text into individual words
                string[] words = text.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in words)
                {
                    // Determine if the word consists only of uppercase letters (ignore non‑letter characters)
                    bool isAllCaps = true;
                    foreach (char c in word)
                    {
                        if (char.IsLetter(c) && !char.IsUpper(c))
                        {
                            isAllCaps = false;
                            break;
                        }
                    }

                    if (isAllCaps && word.Length > 0)
                    {
                        Console.WriteLine(word);
                    }
                }
            }

            // Save the (unchanged) presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}
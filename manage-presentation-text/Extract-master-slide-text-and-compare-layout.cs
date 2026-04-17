using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputFileName = "input.pptx";
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Extract raw text from the presentation
            IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(inputPath, TextExtractionArrangingMode.Unarranged);

            // Compare master slide text with layout text for each slide
            for (int i = 0; i < presentationText.SlidesText.Length; i++)
            {
                ISlideText slideText = presentationText.SlidesText[i];
                string masterText = slideText.MasterText;
                string layoutText = slideText.LayoutText;

                if (!string.Equals(masterText, layoutText, StringComparison.Ordinal))
                {
                    Console.WriteLine($"Inconsistency found on slide index {i}: Master text differs from layout text.");
                }
            }

            // Save the presentation before exit
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
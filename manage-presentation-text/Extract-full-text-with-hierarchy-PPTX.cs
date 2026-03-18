using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesTextExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output file paths
                string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
                string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

                // Extract full text with hierarchy using Arranged mode
                Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                    inputFile,
                    Aspose.Slides.TextExtractionArrangingMode.Arranged);

                for (int i = 0; i < presentationText.SlidesText.Length; i++)
                {
                    Aspose.Slides.ISlideText slideText = presentationText.SlidesText[i];
                    Console.WriteLine("Slide {0}:", i + 1);
                    Console.WriteLine("  Text: " + slideText.Text);
                    Console.WriteLine("  Master Text: " + slideText.MasterText);
                    Console.WriteLine("  Layout Text: " + slideText.LayoutText);
                    Console.WriteLine("  Notes Text: " + slideText.NotesText);
                    Console.WriteLine("  Comments Text: " + slideText.CommentsText);
                    Console.WriteLine();
                }

                // Load the presentation and save it (preserve formatting)
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFile))
                {
                    pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
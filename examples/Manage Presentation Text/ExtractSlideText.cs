using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractSlideText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file name (place the file in the current directory)
            System.String inputFileName = "sample.pptx";
            System.String filePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), inputFileName);

            // Load the presentation (load rule)
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath);

            // Extract raw text from all slides (use TextExtractionArrangingMode.Unarranged)
            Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                filePath,
                Aspose.Slides.TextExtractionArrangingMode.Unarranged);

            // Iterate through slides and output their text
            for (System.Int32 i = 0; i < presentationText.SlidesText.Length; i++)
            {
                Aspose.Slides.ISlideText slideText = presentationText.SlidesText[i];
                System.Console.WriteLine("Slide " + i + ": " + slideText.Text);
            }

            // Save the presentation before exiting (save rule)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}
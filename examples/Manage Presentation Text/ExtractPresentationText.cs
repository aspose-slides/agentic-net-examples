using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input PPTX file
        string inputFileName = "sample.pptx";
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);

        // Extract raw text from the presentation using the Unarranged mode
        Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
            inputPath,
            Aspose.Slides.TextExtractionArrangingMode.Unarranged);

        // Iterate through each slide and output its text
        for (int i = 0; i < presentationText.SlidesText.Length; i++)
        {
            Aspose.Slides.ISlideText slideText = presentationText.SlidesText[i];
            Console.WriteLine("Slide {0} text:", i + 1);
            Console.WriteLine(slideText.Text);
        }

        // Load the presentation to satisfy the rule of saving before exit
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}
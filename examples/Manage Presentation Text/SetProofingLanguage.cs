using System;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Set the default proofing language for all text in the presentation
        pres.DefaultTextStyle.DefaultParagraphFormat.DefaultPortionFormat.LanguageId = "en-US";

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}
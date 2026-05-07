using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Enable font substitution for missing fonts
                Aspose.Slides.FontData sourceFont = new Aspose.Slides.FontData("MissingFont");
                Aspose.Slides.FontData destFont = new Aspose.Slides.FontData("Arial");
                Aspose.Slides.FontSubstRule substRule = new Aspose.Slides.FontSubstRule(sourceFont, destFont, Aspose.Slides.FontSubstCondition.WhenInaccessible);
                presentation.FontsManager.FontSubstRuleList.Add(substRule);

                // Set PDF options with image quality at 70%
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.JpegQuality = 70;

                // Save the presentation as PDF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The provided file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
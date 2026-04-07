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
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Create a font substitution rule that replaces Arial with Times New Roman only when the source font is inaccessible.
                IFontData sourceFont = new FontData("Arial");
                IFontData destFont = new FontData("Times New Roman");
                FontSubstRule rule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
                presentation.FontsManager.ReplaceFont(rule);

                // Configure PDF options. Setting DefaultRegularFont to "Cambria Math" ensures math equations are rendered with the correct font.
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.DefaultRegularFont = "Cambria Math";

                // Save the presentation as PDF.
                presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported.
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling.
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToPdf
{
    class Program
    {
        static void Main(string[] args)
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
                    // Enable font substitution: replace missing Times New Roman with Arial
                    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
                    IFontData sourceFont = new FontData("Times New Roman");
                    IFontData destFont = new FontData("Arial");
                    FontSubstRule substitutionRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
                    substitutionRules.Add(substitutionRule);
                    presentation.FontsManager.FontSubstRuleList = substitutionRules;

                    // Set PDF export options: image quality 70% and default font fallback
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.JpegQuality = 70;
                    pdfOptions.DefaultRegularFont = "Arial";

                    // Save as PDF
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, Aspose.Slides errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
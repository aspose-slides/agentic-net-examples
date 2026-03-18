using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation from file
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Assign proofing language (e.g., English - United States) to the default text style
                presentation.DefaultTextStyle.DefaultParagraphFormat.DefaultPortionFormat.LanguageId = "en-US";

                // Save the updated presentation back to PPTX format
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
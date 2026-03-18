using System;
using System.Text.RegularExpressions;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Regex regex = new Regex(@"\b[^\s]{10,}\b");
            presentation.HighlightRegex(regex, System.Drawing.Color.Blue, null);
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
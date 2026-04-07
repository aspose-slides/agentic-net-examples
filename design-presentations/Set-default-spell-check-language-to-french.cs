using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        var inputFileName = "input.pptx";
        var outputFileName = "output.pptx";
        var inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
        var outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load presentation with default text language set to French
            var loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultTextLanguage = "fr-FR";

            var pres = new Aspose.Slides.Presentation(inputPath, loadOptions);

            // Iterate through all slides and shapes to set language and enable spell check
            foreach (var slide in pres.Slides)
            {
                foreach (var shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.TextFrame != null)
                    {
                        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
                        {
                            foreach (var portion in paragraph.Portions)
                            {
                                portion.PortionFormat.LanguageId = "fr-FR";
                                portion.PortionFormat.SpellCheck = true;
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL issues)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
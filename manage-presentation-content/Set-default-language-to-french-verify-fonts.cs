using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Create load options and set default text language to French
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultTextLanguage = "fr-FR";

            // Load the presentation with the specified load options
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
                // Add a rectangle shape with French text to demonstrate the language setting
                Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 150, 50);
                shape.TextFrame.Text = "Bonjour le monde";

                // Verify that the language ID of the first portion matches the default language
                string languageId = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId;
                Console.WriteLine("Portion language ID: " + languageId);

                // List font substitutions to verify language‑specific fonts are loaded
                foreach (Aspose.Slides.FontSubstitutionInfo fontSubstitution in pres.FontsManager.GetSubstitutions())
                {
                    Console.WriteLine(fontSubstitution.OriginalFontName + " -> " + fontSubstitution.SubstitutedFontName);
                }

                // Save the modified presentation before exiting
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
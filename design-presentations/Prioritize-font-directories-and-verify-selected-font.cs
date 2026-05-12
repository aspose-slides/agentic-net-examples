using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output presentation paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Directories containing custom fonts (priority order)
        string[] fontFolders = new string[] { "fonts\\priority", "fonts\\fallback" };

        // Verify that the input presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load additional font folders before creating any presentation objects
            Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

            // (Optional) List all font folders recognized by the loader
            string[] allFontFolders = Aspose.Slides.FontsLoader.GetFontFolders();
            foreach (string folder in allFontFolders)
            {
                Console.WriteLine("Font folder: " + folder);
            }

            // Prepare load options to prioritize the specified font folders
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DocumentLevelFontSources.FontFolders = fontFolders;

            // Load the presentation with the custom font sources
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

            // Verify which font is selected for a specific text run (first portion of first shape)
            if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
            {
                Aspose.Slides.IShape shape = presentation.Slides[0].Shapes[0];
                if (shape is Aspose.Slides.IAutoShape)
                {
                    Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                    if (autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0)
                    {
                        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                        foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                        {
                            string selectedFont = portion.PortionFormat.LatinFont.FontName;
                            Console.WriteLine("Portion text: \"" + portion.Text + "\" uses font: " + selectedFont);
                        }
                    }
                }
            }

            // List any font substitutions that occurred during rendering
            foreach (Aspose.Slides.FontSubstitutionInfo substitution in presentation.FontsManager.GetSubstitutions())
            {
                Console.WriteLine(substitution.OriginalFontName + " -> " + substitution.SubstitutedFontName);
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            // Clear the custom font cache
            Aspose.Slides.FontsLoader.ClearCache();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Comment: format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
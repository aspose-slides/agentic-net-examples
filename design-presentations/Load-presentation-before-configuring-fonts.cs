using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputFile = "input.pptx";
        string outputFile = "output.pptx";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("File not found: " + inputFile);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputFile))
            {
                // Embed all fonts used in the presentation
                IFontData[] fonts = presentation.FontsManager.GetFonts();
                foreach (IFontData font in fonts)
                {
                    try
                    {
                        presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                    }
                    catch (Exception)
                    {
                        // Ignore if font cannot be embedded or is already embedded
                    }
                }

                // Save the modified presentation
                presentation.Save(outputFile, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O, network)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
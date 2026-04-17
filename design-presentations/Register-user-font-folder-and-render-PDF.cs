using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string presentationPath = "input.pptx";
        string outputPath = "output.pptx";
        string fontsFolder = @"C:\UserFonts";

        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found.");
            return;
        }

        if (!Directory.Exists(fontsFolder))
        {
            Console.WriteLine("Fonts folder not found.");
            return;
        }

        try
        {
            // Register external font folder before creating any presentation objects
            string[] fontFolders = new string[] { fontsFolder };
            Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presentationPath))
            {
                // Perform rendering or other operations here

                // Save the presentation before exiting
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            // Clear the font cache
            Aspose.Slides.FontsLoader.ClearCache();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
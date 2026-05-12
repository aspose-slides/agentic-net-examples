using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input presentation and log file
        string inputPath = "input.pptx";
        string logPath = "fonts_log.txt";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Retrieve all fonts used in the presentation
            Aspose.Slides.IFontData[] fonts = presentation.FontsManager.GetFonts();

            // Get the folders where fonts are located
            System.String[] fontFolders = Aspose.Slides.FontsLoader.GetFontFolders();

            // Write font information to the log file
            using (StreamWriter logWriter = new StreamWriter(logPath, false))
            {
                foreach (Aspose.Slides.IFontData font in fonts)
                {
                    string fontName = font.FontName;
                    string foundPath = "Not found";

                    // Search each folder for a matching font file
                    foreach (string folder in fontFolders)
                    {
                        if (Directory.Exists(folder))
                        {
                            string[] files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
                            foreach (string file in files)
                            {
                                string extension = Path.GetExtension(file).ToLowerInvariant();
                                if (extension == ".ttf" || extension == ".otf")
                                {
                                    // Simple heuristic: file name contains the font name (case‑insensitive)
                                    if (Path.GetFileNameWithoutExtension(file).IndexOf(fontName, StringComparison.OrdinalIgnoreCase) >= 0)
                                    {
                                        foundPath = file;
                                        break;
                                    }
                                }
                            }
                        }
                        if (foundPath != "Not found")
                        {
                            break;
                        }
                    }

                    logWriter.WriteLine($"{fontName} -> {foundPath}");
                }
            }

            // Save the presentation before exiting (no modifications made)
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // If the format is not supported, comment accordingly
            Console.WriteLine("An error occurred (possible unsupported format): " + ex.Message);
        }
    }
}
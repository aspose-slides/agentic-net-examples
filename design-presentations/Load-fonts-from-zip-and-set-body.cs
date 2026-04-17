using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFromZipExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input files
            string zipPath = "fonts.zip";
            string presentationPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input files exist
            if (!File.Exists(zipPath))
            {
                Console.WriteLine("Zip archive not found: " + zipPath);
                return;
            }
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            try
            {
                // Load font binaries from zip archive
                System.Collections.Generic.List<byte[]> fontBytesList = new System.Collections.Generic.List<byte[]>();
                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith(".ttf", StringComparison.OrdinalIgnoreCase) ||
                            entry.FullName.EndsWith(".otf", StringComparison.OrdinalIgnoreCase))
                        {
                            using (Stream stream = entry.Open())
                            using (MemoryStream ms = new MemoryStream())
                            {
                                stream.CopyTo(ms);
                                fontBytesList.Add(ms.ToArray());
                            }
                        }
                    }
                }

                // Prepare load options with memory fonts
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DocumentLevelFontSources.MemoryFonts = fontBytesList.ToArray();

                // Optionally set a default regular font (body font) if known
                // Here we assume the first font's family name is "CustomFont"
                loadOptions.DefaultRegularFont = "CustomFont";

                // Load presentation with the specified fonts
                Presentation presentation = new Presentation(presentationPath, loadOptions);

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
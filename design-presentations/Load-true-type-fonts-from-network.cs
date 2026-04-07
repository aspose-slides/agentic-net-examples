using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LoadTrueTypeFontsFromNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths (replace with actual paths)
            string networkFontFolder = @"\\network\share\fonts";
            string inputPresentationPath = @"C:\Presentations\input.pptx";
            string outputPresentationPath = @"C:\Presentations\output.pptx";

            // Verify network font folder exists
            if (!Directory.Exists(networkFontFolder))
            {
                Console.WriteLine("Network font folder does not exist: " + networkFontFolder);
                return;
            }

            // Verify input presentation exists
            if (!File.Exists(inputPresentationPath))
            {
                Console.WriteLine("Input presentation file does not exist: " + inputPresentationPath);
                return;
            }

            try
            {
                // Load all .ttf files from the network folder into memory
                List<byte[]> memoryFontDataList = new List<byte[]>();
                string[] fontFiles = Directory.GetFiles(networkFontFolder, "*.ttf");
                foreach (string fontFile in fontFiles)
                {
                    byte[] fontBytes = File.ReadAllBytes(fontFile);
                    memoryFontDataList.Add(fontBytes);
                }

                // Prepare load options with external font sources
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DocumentLevelFontSources.FontFolders = new string[] { networkFontFolder };
                loadOptions.DocumentLevelFontSources.MemoryFonts = memoryFontDataList.ToArray();

                // Load the presentation with the specified load options
                using (Presentation presentation = new Presentation(inputPresentationPath, loadOptions))
                {
                    // Save the presentation after fonts are applied
                    presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., network errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
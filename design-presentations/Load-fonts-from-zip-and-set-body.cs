using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFromZipExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths
            string zipPath = "fonts.zip";
            string outputPath = "PresentationWithCustomFont.pptx";

            // Check if zip file exists
            if (!File.Exists(zipPath))
            {
                Console.WriteLine("Font zip archive not found: " + zipPath);
                return;
            }

            // Load font files from zip into memory
            List<byte[]> fontDataList = new List<byte[]>();
            try
            {
                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith(".ttf", StringComparison.OrdinalIgnoreCase) ||
                            entry.FullName.EndsWith(".otf", StringComparison.OrdinalIgnoreCase))
                        {
                            using (Stream entryStream = entry.Open())
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    entryStream.CopyTo(ms);
                                    fontDataList.Add(ms.ToArray());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading zip archive: " + ex.Message);
                return;
            }

            if (fontDataList.Count == 0)
            {
                Console.WriteLine("No font files found in the zip archive.");
                return;
            }

            // Load fonts into Aspose.Slides font cache
            try
            {
                foreach (byte[] fontBytes in fontDataList)
                {
                    FontsLoader.LoadExternalFont(fontBytes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading fonts: " + ex.Message);
                return;
            }

            // Create a new presentation
            Presentation pres = null;
            try
            {
                pres = new Presentation();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating presentation: " + ex.Message);
                return;
            }

            // Add a slide and a rectangle shape with text
            ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            IAutoShape autoShape = (IAutoShape)slide.Shapes.AddAutoShape(
                ShapeType.Rectangle, 50, 50, 400, 100);
            autoShape.AddTextFrame("Sample text using custom font.");

            // Set the body font to the first loaded custom font (by name)
            // Assuming the font name is known; replace "CustomFontName" with actual name
            string customFontName = "CustomFontName";
            IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
            foreach (IPortion portion in paragraph.Portions)
            {
                portion.PortionFormat.LatinFont = new FontData(customFontName);
            }

            // Save the presentation
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (pres != null)
                {
                    pres.Dispose();
                }
                // Clear loaded fonts from cache
                FontsLoader.ClearCache();
            }

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}
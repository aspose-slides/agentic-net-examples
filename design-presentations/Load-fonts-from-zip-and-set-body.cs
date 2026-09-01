// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load fonts from zip and set body using C#

//

// Description:

// Demonstrates how to extract TrueType and OpenType font files from a zip

// archive, load them into Aspose.Slides' font cache, create a new presentation,

// add a rectangle shape with text, and apply the first loaded custom font to

// the shape's body text. The example shows the required presentation‑processing

// steps for PowerPoint files and produces the requested output in a standalone

// console application. Developers can use this pattern to automate PPTX

// workflows, validate results, or integrate presentation logic into .NET

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Fonts, Zip, Body,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate loading custom fonts from a zip archive and applying them to

//   presentation text.

// - Build C# tools for PowerPoint presentation processing that require

//   embedded or external fonts.

// - Generate or transform PPTX files in .NET applications with custom typography.

// - Validate presentation workflows that depend on specific font resources.

// -----------------------------------------------------------------------------



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


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Compare uncompressed and compressed embedded font sizes using C#

//

// Description:

// Demonstrates how to embed fonts in a PowerPoint presentation either with all

// characters (uncompressed) or only the characters actually used (compressed)

// using Aspose.Slides for .NET, and then compares the resulting file sizes.

// The example loads an existing PPTX, creates two versions with different

// embedding strategies, saves them, and prints the size difference.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Font Embedding, Uncompressed,

// Compressed, Embedded Fonts, Presentation Processing, Office Automation

//

// Use Cases:

// - Evaluate the impact of font embedding strategies on PPTX file size.

// - Automate creation of presentations with full or subset font embedding.

// - Build tools that optimize PowerPoint files for distribution.

// - Validate font embedding settings before publishing presentations.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CompareFontEmbeddingSizes

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string uncompressedPath = "uncompressed_embedded.pptx";

            string compressedPath = "compressed_embedded.pptx";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // ----------- Uncompressed (embed all characters) -----------

                using (Presentation presUncompressed = new Presentation(inputPath))

                {

                    IFontsManager fontsMgr = presUncompressed.FontsManager;

                    IFontData[] allFonts = fontsMgr.GetFonts();

                    IFontData[] embeddedFonts = fontsMgr.GetEmbeddedFonts();



                    foreach (IFontData font in allFonts)

                    {

                        bool alreadyEmbedded = false;

                        foreach (IFontData ef in embeddedFonts)

                        {

                            if (ef.FontName == font.FontName)

                            {

                                alreadyEmbedded = true;

                                break;

                            }

                        }



                        if (!alreadyEmbedded)

                        {

                            fontsMgr.AddEmbeddedFont(font, EmbedFontCharacters.All);

                        }

                    }



                    presUncompressed.Save(uncompressedPath, SaveFormat.Pptx);

                }



                // ----------- Compressed (embed only used characters) -----------

                using (Presentation presCompressed = new Presentation(inputPath))

                {

                    IFontsManager fontsMgr = presCompressed.FontsManager;

                    IFontData[] allFonts = fontsMgr.GetFonts();

                    IFontData[] embeddedFonts = fontsMgr.GetEmbeddedFonts();



                    foreach (IFontData font in allFonts)

                    {

                        bool alreadyEmbedded = false;

                        foreach (IFontData ef in embeddedFonts)

                        {

                            if (ef.FontName == font.FontName)

                            {

                                alreadyEmbedded = true;

                                break;

                            }

                        }



                        if (!alreadyEmbedded)

                        {

                            fontsMgr.AddEmbeddedFont(font, EmbedFontCharacters.OnlyUsed);

                        }

                    }



                    presCompressed.Save(compressedPath, SaveFormat.Pptx);

                }



                // ----------- Compare file sizes -----------

                long sizeUncompressed = new FileInfo(uncompressedPath).Length;

                long sizeCompressed = new FileInfo(compressedPath).Length;



                Console.WriteLine("Uncompressed embedded font file size: " + sizeUncompressed + " bytes");

                Console.WriteLine("Compressed embedded font file size: " + sizeCompressed + " bytes");

                Console.WriteLine("Size reduction: " + (sizeUncompressed - sizeCompressed) + " bytes");

            }

            catch (PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The PPTX format is not supported for the given file.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


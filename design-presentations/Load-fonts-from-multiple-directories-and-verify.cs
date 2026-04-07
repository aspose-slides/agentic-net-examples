using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LoadFontsAndVerify
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths configuration
            string presentationPath = "InputPresentation.pptx";
            string outputPath = "OutputPresentation.pptx";

            // Directories containing custom fonts (higher priority first)
            string[] fontDirectories = new string[]
            {
                @"C:\CustomFonts\Priority1",
                @"C:\CustomFonts\Priority2"
            };

            // Verify input presentation exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            // Load external font folders before creating the presentation
            try
            {
                Aspose.Slides.FontsLoader.LoadExternalFonts(fontDirectories);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading external fonts: " + ex.Message);
                // Continue without external fonts if loading fails
            }

            // LoadOptions to prioritize font folders (first folder has higher priority)
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.DocumentLevelFontSources.FontFolders = fontDirectories;

            // Load the presentation with the specified load options
            try
            {
                using (Presentation presentation = new Presentation(presentationPath, loadOptions))
                {
                    // Verify selected font for the first text run
                    if (presentation.Slides.Count > 0)
                    {
                        IShape shape = presentation.Slides[0].Shapes[0];
                        if (shape is IAutoShape)
                        {
                            IAutoShape autoShape = (IAutoShape)shape;
                            if (autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0)
                            {
                                IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                                if (paragraph.Portions.Count > 0)
                                {
                                    IPortion portion = paragraph.Portions[0];
                                    IFontData fontData = portion.PortionFormat.LatinFont;
                                    if (fontData != null)
                                    {
                                        Console.WriteLine("Selected font for first text run: " + fontData.FontName);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No font assigned to the first text run.");
                                    }
                                }
                            }
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
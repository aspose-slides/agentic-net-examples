using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontMemoryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string fontPath = "customfont.ttf";
            string outputPath = "output.pptx";

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file does not exist.");
                return;
            }
            if (!File.Exists(fontPath))
            {
                Console.WriteLine("Font file does not exist.");
                return;
            }

            try
            {
                // Load font bytes into memory
                byte[] fontData = File.ReadAllBytes(fontPath);
                // Register the memory font with Aspose.Slides
                FontsLoader.LoadExternalFont(fontData);

                // Determine font name (assumes file name without extension)
                string fontName = Path.GetFileNameWithoutExtension(fontPath);

                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate through all slides and assign the memory font as body font
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                            {
                                foreach (IPortion portion in paragraph.Portions)
                                {
                                    portion.PortionFormat.LatinFont = new FontData(fontName);
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
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
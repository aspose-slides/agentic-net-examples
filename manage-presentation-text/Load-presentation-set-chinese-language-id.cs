using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides and shapes
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                            {
                                // Iterate through paragraphs and portions
                                for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                                {
                                    IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];
                                    for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                                    {
                                        IPortion portion = paragraph.Portions[portionIndex];
                                        portion.PortionFormat.LanguageId = "zh-CN";
                                    }
                                }
                            }
                        }
                    }

                    // Verify by printing the LanguageId of the first portion found
                    bool languageVerified = false;
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count && !languageVerified; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count && !languageVerified; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            if (shape is IAutoShape autoShape && autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0 && autoShape.TextFrame.Paragraphs[0].Portions.Count > 0)
                            {
                                IPortion firstPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];
                                Console.WriteLine("First portion LanguageId: " + firstPortion.PortionFormat.LanguageId);
                                languageVerified = true;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported file format (PPTX): " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported file format (PPT): " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
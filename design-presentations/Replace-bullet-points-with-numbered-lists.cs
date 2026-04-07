using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ReplaceBulletPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int s = 0; s < pres.Slides.Count; s++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[s];
                        // Get all text boxes on the slide
                        ITextFrame[] textFrames = SlideUtil.GetAllTextBoxes(slide);
                        foreach (ITextFrame textFrame in textFrames)
                        {
                            // Process each paragraph in the text frame
                            for (int p = 0; p < textFrame.Paragraphs.Count; p++)
                            {
                                IParagraph paragraph = textFrame.Paragraphs[p];
                                // Set bullet type to numbered list
                                paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
                                // Start numbering from 1 for each paragraph (or you can customize based on indentation)
                                paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
                                // Apply default indentation shifts to keep original indentation levels
                                paragraph.ParagraphFormat.Bullet.ApplyDefaultParagraphIndentsShifts();
                            }
                        }
                    }

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    pres.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the format is not supported, comment: format not supported
            }
        }
    }
}
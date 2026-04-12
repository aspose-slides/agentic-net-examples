using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertBulletsToNumbered
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Process only text frames
                            if (shape is Aspose.Slides.ITextFrame textFrame)
                            {
                                // Iterate through all paragraphs in the text frame
                                for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                                {
                                    Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[paraIndex];
                                    Aspose.Slides.IBulletFormat bullet = paragraph.ParagraphFormat.Bullet;

                                    // Convert only if the paragraph currently uses a bullet (symbol) type
                                    if (bullet.Type == Aspose.Slides.BulletType.Symbol)
                                    {
                                        // Preserve existing indentation (Indent and MarginLeft are kept unchanged)

                                        // Change bullet type to numbered
                                        bullet.Type = Aspose.Slides.BulletType.Numbered;

                                        // Set the start number for the numbered list.
                                        // NumberedBulletStartWith expects a short (Int16), so cast explicitly.
                                        bullet.NumberedBulletStartWith = (short)1;

                                        // Apply default paragraph indent shifts to keep visual layout similar to original bullets
                                        bullet.ApplyDefaultParagraphIndentsShifts();
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
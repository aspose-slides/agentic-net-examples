using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Get all text frames including those on master slides
                    Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

                    foreach (Aspose.Slides.ITextFrame textFrame in textFrames)
                    {
                        foreach (Aspose.Slides.IParagraph paragraph in textFrame.Paragraphs)
                        {
                            foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                            {
                                // Apply bold and italic formatting
                                portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                                portion.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;
                            }
                        }
                    }

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
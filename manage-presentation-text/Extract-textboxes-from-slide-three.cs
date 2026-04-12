using System;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

namespace TextExtractionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "input.pptx");
            if (!System.IO.File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                if (pres.Slides.Count < 3)
                {
                    Console.WriteLine("Presentation does not contain slide three.");
                }
                else
                {
                    Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(pres.Slides[2]);
                    foreach (Aspose.Slides.ITextFrame textFrame in textFrames)
                    {
                        if (textFrame != null && !String.IsNullOrEmpty(textFrame.Text))
                        {
                            Console.WriteLine(textFrame.Text);
                        }
                    }
                }

                // Save the presentation before exiting
                string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.pptx");
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // If the file format is not supported, an exception will be thrown.
                Console.WriteLine("Error processing presentation: " + ex.Message);
            }
        }
    }
}
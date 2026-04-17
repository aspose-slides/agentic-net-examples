using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddAppendixSection
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
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
                    // Ensure there are at least 14 slides
                    if (presentation.Slides.Count < 14)
                    {
                        Console.WriteLine("Presentation must contain at least 14 slides.");
                        return;
                    }

                    // Add a new section named "Appendix" starting from slide 12 (index 11)
                    ISection appendixSection = presentation.Sections.AddSection("Appendix", presentation.Slides[11]);

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
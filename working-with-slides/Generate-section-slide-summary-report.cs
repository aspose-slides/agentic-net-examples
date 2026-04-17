using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GenerateSectionSlideSummaryReport
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

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
                return;
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Total slide count
            int totalSlides = presentation.DocumentProperties.Slides;

            // Sections count
            int sectionCount = presentation.Sections.Count;

            Console.WriteLine("Total Slides: " + totalSlides);
            Console.WriteLine("Number of Sections: " + sectionCount);

            for (int i = 0; i < sectionCount; i++)
            {
                Aspose.Slides.ISection section = presentation.Sections[i];
                Aspose.Slides.ISectionSlideCollection slidesInSection = section.GetSlidesListOfSection();
                int slideCountInSection = slidesInSection.Count;
                Console.WriteLine("Section " + (i + 1) + " (" + section.Name + "): " + slideCountInSection + " slides");
            }

            // Save presentation before exit
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
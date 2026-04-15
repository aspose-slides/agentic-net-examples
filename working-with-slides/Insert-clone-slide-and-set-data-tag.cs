using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataDir = "Data/";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Clone the first slide to position 2
                    Aspose.Slides.ISlideCollection slides = pres.Slides;
                    slides.InsertClone(2, pres.Slides[0]);

                    // Set a custom property to identify the cloned slide
                    Aspose.Slides.IDocumentProperties docProps = pres.DocumentProperties;
                    docProps.SetCustomPropertyValue("ClonedSlideIndex", 2);

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxEditException)
            {
                // Format not supported or layout cloning issue
                Console.WriteLine("The presentation format is not supported or layout cloning failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
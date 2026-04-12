using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractTextUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect a file path as the first argument
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the presentation file path as an argument.");
                return;
            }

            string filePath = args[0];

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            try
            {
                // Extract raw text using a valid TextExtractionArrangingMode value
                IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                    filePath,
                    Aspose.Slides.TextExtractionArrangingMode.Unarranged);

                // Prepare a list to hold slide texts
                List<Dictionary<string, string>> slidesData = new List<Dictionary<string, string>>();

                ISlideText[] slides = presentationText.SlidesText;
                for (int i = 0; i < slides.Length; i++)
                {
                    Dictionary<string, string> slideInfo = new Dictionary<string, string>();
                    slideInfo["SlideNumber"] = (i + 1).ToString();
                    slideInfo["Text"] = slides[i].Text ?? string.Empty;
                    slidesData.Add(slideInfo);
                }

                // Serialize the result to JSON
                string jsonResult = JsonSerializer.Serialize(slidesData, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(jsonResult);

                // Load the presentation and save it before exiting (as per lifecycle rule)
                using (Presentation pres = new Presentation(filePath))
                {
                    pres.Save(filePath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported for .pptx files
                Console.WriteLine("The provided file format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported for .ppt files
                Console.WriteLine("The provided file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
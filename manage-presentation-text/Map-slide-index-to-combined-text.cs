using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace AsposeSlidesTextExtraction
{
    class Program
    {
        static void Main()
        {
            string inputPath = "sample.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                Dictionary<int, string> slideTexts = GetSlideTexts(inputPath);

                foreach (KeyValuePair<int, string> kvp in slideTexts)
                {
                    Console.WriteLine("Slide " + kvp.Key + ":");
                    Console.WriteLine(kvp.Value);
                    Console.WriteLine("---------------------------");
                }

                // Save the presentation before exit (no modifications made)
                using (Presentation pres = new Presentation(inputPath))
                {
                    pres.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static Dictionary<int, string> GetSlideTexts(string filePath)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();

            // Load presentation
            using (Presentation presentation = new Presentation(filePath))
            {
                // Use PresentationFactory to extract raw text
                PresentationFactory factory = new PresentationFactory();
                IPresentationText presentationText = factory.GetPresentationText(filePath, TextExtractionArrangingMode.Arranged);

                ISlideText[] slides = presentationText.SlidesText;
                for (int i = 0; i < slides.Length; i++)
                {
                    ISlideText slideText = slides[i];
                    // Combine all relevant text parts
                    string combined = slideText.Text ?? string.Empty;
                    if (!string.IsNullOrEmpty(slideText.NotesText))
                    {
                        combined += "\nNotes: " + slideText.NotesText;
                    }
                    if (!string.IsNullOrEmpty(slideText.CommentsText))
                    {
                        combined += "\nComments: " + slideText.CommentsText;
                    }
                    result.Add(i, combined);
                }
            }

            return result;
        }
    }
}
using System;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation for saving later
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Extract comments text using PresentationFactory
                    IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                        inputPath,
                        TextExtractionArrangingMode.Unarranged);

                    ISlideText[] slidesText = presentationText.SlidesText;
                    System.Collections.Generic.List<string> commentsList = new System.Collections.Generic.List<string>();

                    for (int i = 0; i < slidesText.Length; i++)
                    {
                        string comment = slidesText[i].CommentsText;
                        commentsList.Add(comment);
                    }

                    string json = JsonSerializer.Serialize(commentsList, new JsonSerializerOptions { WriteIndented = true });
                    Console.WriteLine(json);

                    // Save presentation before exit
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (PptUnsupportedFormatException)
            {
                // format not supported
                Console.WriteLine("The file format is not supported.");
            }
        }
    }
}
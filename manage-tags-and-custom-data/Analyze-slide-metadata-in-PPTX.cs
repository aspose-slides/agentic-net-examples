using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "sample.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Slides count
                var slideCount = presentation.Slides.Count;
                Console.WriteLine("Total Slides: " + slideCount);

                // Images count
                var imageCount = presentation.Images.Count;
                Console.WriteLine("Total Images: " + imageCount);

                // Audio count
                var audioCount = presentation.Audios.Count;
                Console.WriteLine("Total Audios: " + audioCount);

                // Video count
                var videoCount = presentation.Videos.Count;
                Console.WriteLine("Total Videos: " + videoCount);

                // Custom XML parts
                var customXmlParts = presentation.AllCustomXmlParts;
                Console.WriteLine("Custom XML Parts: " + customXmlParts.Length);

                // Embedded fonts
                var embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
                Console.WriteLine("Embedded Fonts: " + embeddedFonts.Length);

                // Document properties
                var docProps = presentation.DocumentProperties;
                Console.WriteLine("Author: " + docProps.Author);
                Console.WriteLine("Title: " + docProps.Title);
                Console.WriteLine("Created: " + docProps.CreatedTime);

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
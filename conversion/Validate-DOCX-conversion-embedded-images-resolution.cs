using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.docx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);

            // Retrieve embedded images count
            int imageCount = presentation.Images.Count;
            Console.WriteLine("Number of embedded images: " + imageCount);

            // Iterate through images to check their resolution (placeholder for actual resolution check)
            for (int i = 0; i < imageCount; i++)
            {
                // Aspose.Slides does not expose direct resolution properties; this is a placeholder.
                Console.WriteLine("Image " + (i + 1) + ": resolution check placeholder.");
            }

            // Attempt to save as DOCX (unsupported format)
            try
            {
                // Aspose.Slides does not support saving to DOCX; using an unsupported SaveFormat will throw.
                presentation.Save(outputPath, SaveFormat.Pptx); // Placeholder: replace with DOCX when supported.
            }
            catch (NotSupportedException)
            {
                // Format not supported comment
                // DOCX format is not supported for saving presentations.
            }

            // Save presentation before exit as required
            presentation.Save("intermediate.pptx", SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Create a memory stream to hold the PPTX data (BLOB)
            MemoryStream blobStream = new MemoryStream();

            // Save the presentation to the stream in PPTX format
            presentation.Save(blobStream, Aspose.Slides.Export.SaveFormat.Pptx);

            // Reset stream position for further operations
            blobStream.Position = 0;

            // Example: write the BLOB stream to a file (optional)
            using (FileStream fileStream = new FileStream("output.pptx", FileMode.Create, FileAccess.Write))
            {
                blobStream.CopyTo(fileStream);
            }

            // Ensure the presentation is also saved to a file before exiting
            presentation.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
            blobStream.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
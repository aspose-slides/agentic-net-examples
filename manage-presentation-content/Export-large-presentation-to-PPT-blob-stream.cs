using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Export the presentation to a BLOB stream in PPT format
                    presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Ppt);
                    // Optionally write the BLOB to a file
                    File.WriteAllBytes("output.ppt", memoryStream.ToArray());
                }

                // Ensure the presentation is saved before exiting
                presentation.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
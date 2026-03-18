using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string[] sourceFiles = new string[] { "sample.ppt", "sample.odp", "sample.pptm" };
            foreach (string sourcePath in sourceFiles)
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
                {
                    string outputPath = System.IO.Path.ChangeExtension(sourcePath, ".pptx");
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
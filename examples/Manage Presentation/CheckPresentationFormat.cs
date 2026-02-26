using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the presentation file
        string filePath = "sample.pptx";

        // Get information about the presentation format
        Aspose.Slides.IPresentationInfo info = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(filePath);
        Console.WriteLine(info.LoadFormat);

        // Load the presentation and save it before exiting
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
        {
            presentation.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
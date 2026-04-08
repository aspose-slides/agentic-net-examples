using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine the directory containing presentations
        string folderPath;
        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
        {
            folderPath = args[0];
        }
        else
        {
            folderPath = "Presentations";
        }

        // Verify the directory exists
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine("Folder does not exist: " + folderPath);
            return;
        }

        // Get all files in the directory
        string[] files = Directory.GetFiles(folderPath);
        foreach (string filePath in files)
        {
            try
            {
                // Verify the file can be opened as a presentation
                Aspose.Slides.IPresentationInfo info = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(filePath);

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath);

                // Access document properties
                Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

                // Add or update custom property "SourceFile" with the original file name
                docProps.SetCustomPropertyValue("SourceFile", Path.GetFileName(filePath));

                // Save the presentation (overwrites the original file)
                presentation.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Release resources
                presentation.Dispose();

                Console.WriteLine("Processed: " + filePath);
            }
            catch (Exception ex)
            {
                // If the format is not supported, Aspose.Slides may throw an exception
                // Format not supported
                Console.WriteLine("Error processing file: " + filePath + " - " + ex.Message);
            }
        }
    }
}
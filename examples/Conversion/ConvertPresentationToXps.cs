using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // List of source files to convert (PPT and PPTX)
        string[] sourceFiles = new string[] { "sample.ppt", "sample.pptx" };

        foreach (string sourcePath in sourceFiles)
        {
            // Load the presentation from file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath);

            // Convert using default XPS options
            string defaultOutput = System.IO.Path.ChangeExtension(sourcePath, ".xps");
            presentation.Save(defaultOutput, Aspose.Slides.Export.SaveFormat.Xps);

            // Convert using custom XPS options
            Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();
            xpsOptions.SaveMetafilesAsPng = true; // Example custom setting
            string customOutput = System.IO.Path.GetFileNameWithoutExtension(sourcePath) + "_custom.xps";
            presentation.Save(customOutput, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);

            // Release resources
            presentation.Dispose();
        }
    }
}
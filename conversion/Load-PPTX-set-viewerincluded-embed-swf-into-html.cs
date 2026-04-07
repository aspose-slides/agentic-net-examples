using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string swfPath = "output.swf";
        string htmlPath = "output.html";

        // Verify that the input PPTX file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            try
            {
                // Configure SWF options with ViewerIncluded set to true
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                swfOptions.ViewerIncluded = true;

                // Save the presentation as SWF
                presentation.Save(swfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
            }
            finally
            {
                // Ensure the presentation is disposed
                presentation.Dispose();
            }

            // Generate simple HTML that embeds the SWF file
            string htmlContent = "<!DOCTYPE html>\n<html>\n<head>\n<title>SWF Embed</title>\n</head>\n<body>\n<object width=\"800\" height=\"600\" data=\"" + swfPath + "\">\n<embed src=\"" + swfPath + "\" width=\"800\" height=\"600\"></embed>\n</object>\n</body>\n</html>";
            File.WriteAllText(htmlPath, htmlContent);

            Console.WriteLine("SWF saved and HTML generated.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
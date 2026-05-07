using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputSwfPath = "output.swf";
        string outputHtmlPath = "player.html";

        // Check if the input presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure SWF options to disable the integrated viewer UI
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.ViewerIncluded = false;
            swfOptions.ShowTopPane = false;
            swfOptions.ShowBottomPane = false;
            swfOptions.ShowLeftPane = false;
            swfOptions.ShowFullScreen = false;
            swfOptions.ShowPageStepper = false;
            swfOptions.ShowSearch = false;
            swfOptions.ShowPageBorder = false;

            // Save the presentation as SWF
            presentation.Save(outputSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
            presentation.Dispose();

            // Generate a simple HTML5 page that embeds the SWF file
            string htmlContent = "<!DOCTYPE html>\n<html>\n<head>\n<title>SWF Player</title>\n</head>\n<body>\n<object width=\"800\" height=\"600\" data=\"" + outputSwfPath + "\" type=\"application/x-shockwave-flash\">\n<embed src=\"" + outputSwfPath + "\" width=\"800\" height=\"600\" type=\"application/x-shockwave-flash\"></embed>\n</object>\n</body>\n</html>";
            File.WriteAllText(outputHtmlPath, htmlContent);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
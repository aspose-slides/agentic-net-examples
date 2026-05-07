using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string swfPath = "output.swf";
        string htmlPath = "output.html";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);
            SwfOptions swfOptions = new SwfOptions();
            swfOptions.ViewerIncluded = true;
            presentation.Save(swfPath, SaveFormat.Swf, swfOptions);
            presentation.Dispose();

            string htmlContent = "<!DOCTYPE html>\n<html>\n<head>\n<title>SWF Presentation</title>\n</head>\n<body>\n<div id=\"swfContainer\">\n<object width=\"800\" height=\"600\" data=\"" + swfPath + "\" type=\"application/x-shockwave-flash\">\n<param name=\"movie\" value=\"" + swfPath + "\" />\n<param name=\"allowFullScreen\" value=\"true\" />\n<param name=\"allowScriptAccess\" value=\"always\" />\n</object>\n</div>\n</body>\n</html>";
            File.WriteAllText(htmlPath, htmlContent);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
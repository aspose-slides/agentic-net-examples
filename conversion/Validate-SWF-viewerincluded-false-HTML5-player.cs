using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input PPTX file path
        var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Define output SWF file path
        var outputSwf = Path.Combine(Directory.GetCurrentDirectory(), "output.swf");

        try
        {
            // Load presentation
            using (var presentation = new Presentation(inputPath))
            {
                // Configure SWF options with ViewerIncluded = false
                var swfOptions = new SwfOptions();
                swfOptions.ViewerIncluded = false;

                // Save presentation as SWF
                presentation.Save(outputSwf, SaveFormat.Swf, swfOptions);
            }

            // Generate simple HTML5 page to load the SWF file
            var htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "player.html");
            var htmlContent = $@"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>Custom SWF Player</title>
</head>
<body>
    <object type='application/x-shockwave-flash' data='{Path.GetFileName(outputSwf)}' width='800' height='600'>
        <param name='movie' value='{Path.GetFileName(outputSwf)}' />
        <param name='allowScriptAccess' value='always' />
        <param name='wmode' value='transparent' />
        Your browser does not support Flash.
    </object>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);
            Console.WriteLine("SWF saved and HTML player generated.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
using System;
using System.IO;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputSwfPath = "output.swf";
            string htmlPath = "player.html";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Configure SWF options with viewer disabled
                    Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                    swfOptions.ViewerIncluded = false;

                    // Save as SWF
                    presentation.Save(outputSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                }

                // Create a simple HTML5 page that embeds the generated SWF
                string htmlContent = "<!DOCTYPE html>\n" +
                                     "<html>\n" +
                                     "<head>\n" +
                                     "    <meta charset=\"UTF-8\">\n" +
                                     "    <title>SWF Viewer</title>\n" +
                                     "</head>\n" +
                                     "<body>\n" +
                                     "    <object type=\"application/x-shockwave-flash\" data=\"" + outputSwfPath + "\" width=\"800\" height=\"600\">\n" +
                                     "        <param name=\"movie\" value=\"" + outputSwfPath + "\" />\n" +
                                     "        <param name=\"allowScriptAccess\" value=\"always\" />\n" +
                                     "        <param name=\"wmode\" value=\"transparent\" />\n" +
                                     "    </object>\n" +
                                     "</body>\n" +
                                     "</html>";

                File.WriteAllText(htmlPath, htmlContent);

                Console.WriteLine("SWF saved to: " + outputSwfPath);
                Console.WriteLine("HTML player created at: " + htmlPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
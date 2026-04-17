using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToHtml5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure HTML5 export options
                    Html5Options options = new Html5Options
                    {
                        EmbedImages = true,
                        AnimateTransitions = true
                    };

                    // Save the presentation as HTML5
                    presentation.Save(outputPath, SaveFormat.Html5, options);
                }

                // Embed custom analytics script into the generated HTML
                string htmlContent = File.ReadAllText(outputPath);
                string analyticsScript = "<script>/* Custom analytics */ console.log('Slide viewed');</script>";

                // Insert the script before the closing </body> tag
                int bodyCloseIndex = htmlContent.LastIndexOf("</body>", StringComparison.OrdinalIgnoreCase);
                if (bodyCloseIndex >= 0)
                {
                    htmlContent = htmlContent.Insert(bodyCloseIndex, analyticsScript);
                }
                else
                {
                    // If </body> not found, append the script at the end
                    htmlContent += analyticsScript;
                }

                // Write the modified HTML back to the file
                File.WriteAllText(outputPath, htmlContent);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
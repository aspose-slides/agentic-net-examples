using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HtmlExportExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Input PowerPoint file
                string inputPath = "input.pptx";

                // Output HTML file
                string outputHtmlPath = "output.html";

                // Folder where external resources (CSS, images) will be saved
                string outputResourcesPath = "output_resources";

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure HTML5 export options
                    Html5Options htmlOptions = new Html5Options();
                    htmlOptions.EmbedImages = false; // Save images as external files
                    htmlOptions.OutputPath = outputResourcesPath; // Set resources folder

                    // Save the presentation as HTML5
                    presentation.Save(outputHtmlPath, SaveFormat.Html5, htmlOptions);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
// -----------------------------------------------------------------------------
// Example: Export PowerPoint Presentation to HTML5 with WebGL-enabled 3D Model Rendering
//
// Description:
// This console application loads a PPTX file, checks its existence, and exports
// it to HTML5 format using Aspose.Slides for .NET. The export is configured to
// embed images and rely on the default WebGL support for rendering 3D models,
// producing a self‑contained HTML5 output suitable for web viewing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML5 export, WebGL, 3D models
//
// Use Cases:
// - Convert corporate slide decks to interactive web pages with 3D content.
// - Publish training materials online while preserving 3D visualizations.
// - Integrate PowerPoint presentations into web applications without plugins.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesHtml5Export
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file '" + inputPath + "' does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure HTML5 export options
                Aspose.Slides.Export.Html5Options htmlOptions = new Aspose.Slides.Export.Html5Options();
                // Embed images directly into the HTML to create a single-file output
                htmlOptions.EmbedImages = true;
                // WebGL rendering for 3D models is enabled by default in Html5Options.
                // No explicit property is required; ensure the library version supports it.

                // Save the presentation as HTML5
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, htmlOptions);

                Console.WriteLine("Presentation successfully exported to HTML5 at '" + outputPath + "'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during export: " + ex.Message);
            }
        }
    }
}

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PowerPointToMarkdown
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.md";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure markdown save options
                Aspose.Slides.Export.MarkdownSaveOptions mdOptions = new Aspose.Slides.Export.MarkdownSaveOptions();
                mdOptions.ShowHiddenSlides = false;
                mdOptions.ShowSlideNumber = true;
                mdOptions.Flavor = Aspose.Slides.Export.Flavor.Github;
                mdOptions.ExportType = Aspose.Slides.Export.MarkdownExportType.TextOnly;
                mdOptions.NewLineType = Aspose.Slides.Export.NewLineType.Unix;
                mdOptions.SlideNumberFormat = "# Slide {0}";

                // Save the presentation as markdown
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Md, mdOptions);

                // Dispose the presentation object
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
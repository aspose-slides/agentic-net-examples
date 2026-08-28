// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert PPT to markdown preserving titles using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to a Markdown

// document while preserving slide titles, slide numbers, and hidden slides using

// Aspose.Slides for .NET. The example configures GitHub‑flavored Markdown,

// sequential export, and Unix line endings in a standalone console application.

// Developers can adapt this pattern to automate PPTX to Markdown workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Markdown, Convert, Preserve Titles,

// Slide Numbers, Hidden Slides, GitHub Flavor, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to Markdown with titles and slide numbers.

// - Build .NET tools for generating documentation from presentations.

// - Integrate PowerPoint content into static site generators or wikis.

// - Preserve hidden slides and ordering when exporting to Markdown.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Define input and output paths

        string inputFolder = "Input";

        string outputFolder = "Output";

        string presentationFile = "sample.pptx";

        string markdownFileName = "sample.md";



        string inputPath = Path.Combine(inputFolder, presentationFile);

        string outputPath = Path.Combine(outputFolder, markdownFileName);



        // Ensure output directory exists

        Directory.CreateDirectory(outputFolder);



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            Presentation presentation = new Presentation(inputPath);

            MarkdownSaveOptions mdOptions = new MarkdownSaveOptions

            {

                ShowHiddenSlides = true,

                ShowSlideNumber = true,

                Flavor = Flavor.Github,

                ExportType = MarkdownExportType.Sequential,

                NewLineType = NewLineType.Unix

            };



            presentation.Save(outputPath, SaveFormat.Md, mdOptions);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported for conversion.");

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., external URL issues)

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}


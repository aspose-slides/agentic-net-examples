// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert presentation to markdown with TOC using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation into individual markdown

// files for each slide and generate a Table of Contents markdown file that links

// to those slide files. The example uses Aspose.Slides for .NET to load the PPTX,

// export each slide as visual markdown, and create a TOC linking to the generated

// files. This pattern can be used in console applications to automate PPTX

// documentation workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, Presentation, Markdown,

// Table of Contents, Slide Export, Office Automation

//

// Use Cases:

// - Automate conversion of presentations to markdown with a navigable TOC.

// - Build tools that document slide content in markdown for version control.

// - Integrate slide-to-markdown conversion into .NET CI/CD pipelines.

// - Generate lightweight documentation from PowerPoint files.

//

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

        string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "output");

        Directory.CreateDirectory(outputFolder);



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);



            // Create Table of Contents markdown file

            string tocPath = Path.Combine(outputFolder, "TOC.md");

            using (StreamWriter tocWriter = new StreamWriter(tocPath))

            {

                tocWriter.WriteLine("# Table of Contents");

                for (int i = 0; i < pres.Slides.Count; i++)

                {

                    int slideNumber = i + 1;

                    string slideTitle = "Slide " + slideNumber;

                    string slideFileName = "Slide_" + slideNumber + ".md";

                    tocWriter.WriteLine(string.Format("- [{0}]({1})", slideTitle, slideFileName));

                }

            }



            // Convert each slide to individual markdown file with slide number heading

            for (int i = 0; i < pres.Slides.Count; i++)

            {

                int slideNumber = i + 1;

                string slideFilePath = Path.Combine(outputFolder, "Slide_" + slideNumber + ".md");

                Aspose.Slides.Export.MarkdownSaveOptions mdOptions = new Aspose.Slides.Export.MarkdownSaveOptions();

                mdOptions.ExportType = Aspose.Slides.Export.MarkdownExportType.Visual;

                mdOptions.ShowSlideNumber = true;

                mdOptions.SlideNumberFormat = "# Slide {0}";

                int[] slideIndices = new int[] { slideNumber };

                pres.Save(slideFilePath, slideIndices, Aspose.Slides.Export.SaveFormat.Md, mdOptions);

            }



            pres.Dispose();

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


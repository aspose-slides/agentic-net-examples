// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert presentation to markdown with SVG slides using C#

//

// Description:

// Demonstrates how to convert each slide of a PowerPoint presentation to an

// SVG image and generate a markdown file that references those images using

// Aspose.Slides for .NET. The example creates an output folder for SVG files,

// builds markdown headings for each slide, and saves the resulting markdown

// document. This pattern can be used to automate PPTX to markdown conversion

// workflows in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Convert, Presentation,

// Markdown, Slides, Office Automation

//

// Use Cases:

// - Automate conversion of PowerPoint slides to markdown with embedded SVG images.

// - Build C# tools for extracting visual content from PPTX files.

// - Generate documentation or web content from presentations.

// - Integrate slide-to-markdown conversion into CI/CD pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Text;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputMarkdownPath = "output.md";

        string outputFolder = "output_images";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                if (!Directory.Exists(outputFolder))

                {

                    Directory.CreateDirectory(outputFolder);

                }



                StringBuilder markdownBuilder = new StringBuilder();



                for (int i = 0; i < presentation.Slides.Count; i++)

                {

                    Aspose.Slides.ISlide slide = presentation.Slides[i];

                    string svgPath = Path.Combine(outputFolder, $"slide_{i + 1}.svg");



                    using (FileStream svgStream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))

                    {

                        slide.WriteAsSvg(svgStream);

                    }



                    markdownBuilder.AppendLine($"## Slide {i + 1}");

                    markdownBuilder.AppendLine();

                    markdownBuilder.AppendLine($"![Slide {i + 1}]({svgPath})");

                    markdownBuilder.AppendLine();

                }



                File.WriteAllText(outputMarkdownPath, markdownBuilder.ToString());



                // Save the presentation before exiting (no modifications made)

                presentation.Save("temp_output.pptx", SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., external URLs or web services)

            Console.WriteLine($"An error occurred: {ex.Message}");

        }

    }

}


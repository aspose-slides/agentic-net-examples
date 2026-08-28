// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPTX to markdown with header using C#

//

// Description:

// Demonstrates how to batch convert PPTX files to markdown with a YAML header

// using C# and Aspose.Slides for .NET. The example processes all PPTX files in

// an input folder, exports each slide to markdown with GitHub-flavored syntax,

// and prepends a metadata header containing the source file name. It creates

// an output folder for the generated markdown files. Developers can use this

// pattern to automate PPTX-to-markdown workflows, integrate presentation

// processing into .NET tools, or prepare documentation from PowerPoint assets.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Batch, Convert, Pptx, Markdown,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch conversion of PPTX presentations to markdown with source metadata.

// - Build C# utilities for PowerPoint content extraction and documentation generation.

// - Integrate PPTX processing into .NET applications or CI pipelines.

// - Validate and transform presentation files before publishing or further analysis.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchConvertToMarkdown

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine input folder (first argument or default "input" subfolder)

            string inputFolder;

            if (args.Length > 0)

            {

                inputFolder = args[0];

            }

            else

            {

                inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "input");

            }



            // Verify that the input directory exists

            if (!Directory.Exists(inputFolder))

            {

                Console.WriteLine("Input directory does not exist: " + inputFolder);

                return;

            }



            // Ensure the output directory exists

            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "output");

            Directory.CreateDirectory(outputFolder);



            // Get all PPTX files in the input directory

            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx", SearchOption.TopDirectoryOnly);

            foreach (string pptxPath in pptxFiles)

            {

                try

                {

                    // Load the presentation

                    using (Presentation presentation = new Presentation(pptxPath))

                    {

                        // Configure markdown export options

                        MarkdownSaveOptions options = new MarkdownSaveOptions

                        {

                            ShowHiddenSlides = true,

                            ShowSlideNumber = true,

                            Flavor = Flavor.Github,

                            ExportType = MarkdownExportType.Sequential,

                            NewLineType = NewLineType.Unix

                        };



                        // Determine output markdown file path

                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptxPath);

                        string markdownPath = Path.Combine(outputFolder, fileNameWithoutExt + ".md");



                        // Save presentation as markdown

                        presentation.Save(markdownPath, SaveFormat.Md, options);

                    }



                    // Prepend metadata header with source file name

                    string markdownFile = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(pptxPath) + ".md");

                    if (File.Exists(markdownFile))

                    {

                        string originalContent = File.ReadAllText(markdownFile);

                        string header = "---" + Environment.NewLine +

                                        "source: " + Path.GetFileName(pptxPath) + Environment.NewLine +

                                        "---" + Environment.NewLine + Environment.NewLine;

                        File.WriteAllText(markdownFile, header + originalContent);

                    }

                }

                catch (NotSupportedException)

                {

                    // Format not supported

                    Console.WriteLine("File format not supported for file: " + pptxPath);

                }

                catch (Exception ex)

                {

                    // General error handling

                    Console.WriteLine("Error processing file: " + pptxPath);

                    Console.WriteLine(ex.Message);

                }

            }

        }

    }

}


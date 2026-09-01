// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch export PPTX to PDF with titles using C#

//

// Description:

// Demonstrates how to batch convert PPTX files to PDF while generating a

// cover slide that lists each slide's title (or slide number if no title)

// using Aspose.Slides for .NET. The program scans an input folder, creates a

// combined presentation with a title slide, and saves the result as PDF in an

// output folder.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Batch, Export, Titles,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of multiple PPTX files to PDF with a summary slide.

// - Build .NET tools that add a title page to presentations before publishing.

// - Generate PDF reports from PowerPoint decks with an overview of slide titles.

// - Integrate slide‑title extraction into document workflows.

//

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchExportPptxToPdf

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine input directory

            string inputDirectory;

            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))

            {

                inputDirectory = args[0];

            }

            else

            {

                inputDirectory = "InputPptx";

            }



            // Verify input directory exists

            if (!Directory.Exists(inputDirectory))

            {

                Console.WriteLine("Input directory does not exist: " + inputDirectory);

                return;

            }



            // Determine output directory (same parent folder, subfolder "OutputPdf")

            string outputDirectory = Path.Combine(inputDirectory, "..", "OutputPdf");

            outputDirectory = Path.GetFullPath(outputDirectory);



            // Ensure output directory exists

            if (!Directory.Exists(outputDirectory))

            {

                Directory.CreateDirectory(outputDirectory);

            }



            // Get all PPTX files in the input directory

            string[] pptxFiles;

            try

            {

                pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx", SearchOption.TopDirectoryOnly);

            }

            catch (DirectoryNotFoundException)

            {

                Console.WriteLine("Could not find a part of the path: " + inputDirectory);

                return;

            }



            foreach (string pptxPath in pptxFiles)

            {

                // Verify the file exists (should be true from enumeration)

                if (!File.Exists(pptxPath))

                {

                    Console.WriteLine("File not found: " + pptxPath);

                    continue;

                }



                try

                {

                    // Load the source presentation

                    using (Presentation sourcePresentation = new Presentation(pptxPath))

                    {

                        // Create a new presentation for the cover + content

                        using (Presentation combinedPresentation = new Presentation())

                        {

                            // Prepare cover slide (use the first slide of the new presentation)

                            ISlide coverSlide = combinedPresentation.Slides[0];



                            // Add a rectangle shape to hold the titles list

                            IAutoShape titleBox = coverSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 600, 400);

                            titleBox.TextFrame.Text = BuildTitlesList(sourcePresentation);



                            // Append all slides from the source presentation after the cover slide

                            for (int i = 0; i < sourcePresentation.Slides.Count; i++)

                            {

                                ISlide sourceSlide = sourcePresentation.Slides[i];

                                combinedPresentation.Slides.InsertClone(combinedPresentation.Slides.Count, sourceSlide);

                            }



                            // Determine output PDF path

                            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptxPath);

                            string pdfOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");



                            // Save as PDF

                            combinedPresentation.Save(pdfOutputPath, SaveFormat.Pdf);

                        }

                    }



                    Console.WriteLine("Converted: " + pptxPath);

                }

                catch (PptxUnsupportedFormatException)

                {

                    // Format not supported – comment as required

                    Console.WriteLine("Format not supported for file: " + pptxPath);

                }

                catch (Exception ex)

                {

                    // General exception handling (e.g., I/O errors)

                    Console.WriteLine("Error processing file " + pptxPath + ": " + ex.Message);

                }

            }

        }



        // Builds a simple list of slide titles (or slide numbers if title not available)

        private static string BuildTitlesList(Presentation pres)

        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendLine("Slide Titles:");

            for (int i = 0; i < pres.Slides.Count; i++)

            {

                // Attempt to get a title placeholder; fallback to slide index

                string title = "Slide " + (i + 1);

                try

                {

                    foreach (IShape shape in pres.Slides[i].Shapes)

                    {

                        if (shape.Placeholder != null && shape.Placeholder.Type == PlaceholderType.Title)

                        {

                            IAutoShape autoShape = shape as IAutoShape;

                            if (autoShape != null && autoShape.TextFrame != null && !String.IsNullOrEmpty(autoShape.TextFrame.Text))

                            {

                                title = autoShape.TextFrame.Text;

                                break;

                            }

                        }

                    }

                }

                catch

                {

                    // Ignore any errors while extracting titles

                }

                sb.AppendLine(title);

            }

            return sb.ToString();

        }

    }

}


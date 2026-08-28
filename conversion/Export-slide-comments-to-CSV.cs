// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export slide comments to CSV using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation with Aspose.Slides for .NET,

// extract all slide comments, and write them to a CSV file. The example also

// saves a copy of the original presentation, showing a typical workflow for

// comment extraction in a standalone console application.

//

// Keywords:

// C#, Aspose.Slides for .NET, PowerPoint, PPTX, CSV, Export, Slide Comments, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Extract and archive slide comments from PPTX files.

// - Build C# utilities for PowerPoint comment analysis.

// - Integrate comment export into .NET automation pipelines.

// - Validate and review presentation feedback before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportSlideComments

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation path (can be passed as first argument)

            string inputPath = args.Length > 0 ? args[0] : "input.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Output CSV file path

            string csvPath = "comments.csv";



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Open CSV writer

                    using (StreamWriter writer = new StreamWriter(csvPath, false))

                    {

                        // Write CSV header

                        writer.WriteLine("SlideNumber,AuthorName,CreatedTime,CommentText");



                        // Iterate over all comment authors

                        foreach (ICommentAuthor author in presentation.CommentAuthors)

                        {

                            // Iterate over each comment of the author

                            foreach (IComment comment in author.Comments)

                            {

                                int slideNumber = comment.Slide.SlideNumber;

                                string authorName = comment.Author.Name;

                                string createdTime = comment.CreatedTime.ToString("o"); // ISO 8601 format

                                string commentText = comment.Text.Replace("\"", "\"\""); // Escape quotes



                                // Write CSV line (quote fields to handle commas)

                                writer.WriteLine($"{slideNumber},\"{authorName}\",\"{createdTime}\",\"{commentText}\"");

                            }

                        }

                    }



                    // Save the presentation (required before exit)

                    presentation.Save("output.pptx", SaveFormat.Pptx);

                }



                Console.WriteLine("Comments exported successfully to " + csvPath);

            }

            catch (PptxUnsupportedFormatException)

            {

                // Handle unsupported PPTX format

                Console.WriteLine("The presentation format is not supported (PPTX).");

            }

            catch (PptUnsupportedFormatException)

            {

                // Handle unsupported PPT format

                Console.WriteLine("The presentation format is not supported (PPT).");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


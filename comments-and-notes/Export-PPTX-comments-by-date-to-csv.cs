// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX comments by date to csv using C#

//

// Description:

// Demonstrates how to export PPTX comments filtered by a date range to a CSV

// file using C# and Aspose.Slides for .NET. The example loads a PowerPoint

// presentation, iterates through comment authors and their comments, selects

// comments whose creation time falls within the specified start and end dates,

// and writes the relevant details to a CSV file. The presentation is then

// saved back to its original location as required by repository rules.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Pptx, Comments, Date,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export of PPTX comments by date to CSV.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesCommentsExport

{

    class Program

    {

        static void Main(string[] args)

        {

            // Expected arguments: inputPptxPath outputCsvPath startDate endDate

            if (args.Length < 4)

            {

                Console.WriteLine("Usage: <inputPptxPath> <outputCsvPath> <startDate> <endDate>");

                return;

            }



            string inputPath = args[0];

            string outputCsvPath = args[1];

            string startDateStr = args[2];

            string endDateStr = args[3];



            if (!File.Exists(inputPath))

            {

                Console.WriteLine($"Input file does not exist: {inputPath}");

                return;

            }



            DateTime startDate;

            DateTime endDate;

            try

            {

                startDate = DateTime.Parse(startDateStr);

                endDate = DateTime.Parse(endDateStr);

            }

            catch (Exception)

            {

                Console.WriteLine("Invalid date format. Use a recognizable date string.");

                return;

            }



            try

            {

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    using (StreamWriter writer = new StreamWriter(outputCsvPath, false))

                    {

                        // Write CSV header

                        writer.WriteLine("SlideNumber,AuthorName,CommentText,CreatedTime");



                        foreach (Aspose.Slides.ICommentAuthor author in presentation.CommentAuthors)

                        {

                            // Iterate all comments of the author

                            foreach (Aspose.Slides.IComment comment in author.Comments)

                            {

                                DateTime created = comment.CreatedTime;

                                if (created >= startDate && created <= endDate)

                                {

                                    int slideNumber = comment.Slide.SlideNumber;

                                    string authorName = author.Name;

                                    string text = comment.Text.Replace("\"", "\"\"");

                                    string line = $"{slideNumber},\"{authorName}\",\"{text}\",{created:o}";

                                    writer.WriteLine(line);

                                }

                            }

                        }

                    }



                    // Save the presentation (required by rule)

                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                }



                Console.WriteLine($"Filtered comments exported to: {outputCsvPath}");

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine($"An error occurred: {ex.Message}");

            }

        }

    }

}


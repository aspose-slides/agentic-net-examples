// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create pivot table of comment counts using C#

//

// Description:

// Demonstrates how to extract comment counts per author and slide from a PowerPoint

// presentation using Aspose.Slides for .NET, and export the data to a CSV file that

// can be used as a source for a pivot table in Excel. The example loads a PPTX,

// aggregates comments, writes a summary CSV, and saves the presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Pivot, Table, Comment, Counts,

// Presentation Processing, Office Automation, CSV Export

//

// Use Cases:

// - Automate creation of comment count reports for PowerPoint presentations.

// - Build C# tools that generate data for Excel pivot tables from PPTX comments.

// - Integrate comment analysis into .NET applications handling PPTX files.

// - Validate and audit comment usage before publishing presentations.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Collections.Generic;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Path to the source presentation

        string presentationPath = "input.pptx";



        // Verify that the file exists

        if (!File.Exists(presentationPath))

        {

            Console.WriteLine("Presentation file not found: " + presentationPath);

            return;

        }



        try

        {

            // Load the presentation

            using (Presentation presentation = new Presentation(presentationPath))

            {

                // Dictionary: Author -> (SlideNumber -> CommentCount)

                Dictionary<string, Dictionary<int, int>> commentCounts = new Dictionary<string, Dictionary<int, int>>();



                // Iterate through all comment authors

                foreach (ICommentAuthor author in presentation.CommentAuthors)

                {

                    string authorName = author.Name;



                    if (!commentCounts.ContainsKey(authorName))

                        commentCounts[authorName] = new Dictionary<int, int>();



                    // Iterate through comments of the current author

                    foreach (Comment comment in author.Comments)

                    {

                        int slideNumber = comment.Slide.SlideNumber;



                        if (!commentCounts[authorName].ContainsKey(slideNumber))

                            commentCounts[authorName][slideNumber] = 0;



                        commentCounts[authorName][slideNumber]++;

                    }

                }



                // Export the summary as CSV (can be opened in Excel as a pivot source)

                string csvPath = "CommentSummary.csv";

                using (StreamWriter writer = new StreamWriter(csvPath))

                {

                    writer.WriteLine("Author,SlideNumber,CommentCount");

                    foreach (KeyValuePair<string, Dictionary<int, int>> authorEntry in commentCounts)

                    {

                        string author = authorEntry.Key;

                        foreach (KeyValuePair<int, int> slideEntry in authorEntry.Value)

                        {

                            writer.WriteLine(string.Format("{0},{1},{2}", author, slideEntry.Key, slideEntry.Value));

                        }

                    }

                }



                // Save the presentation before exiting (as required)

                presentation.Save("output.pptx", SaveFormat.Pptx);

            }

        }

        catch (Exception ex)

        {

            // Handle any unexpected errors (e.g., unsupported format)

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


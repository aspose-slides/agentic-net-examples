// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Compare PPTX comments between revisions using C#

//

// Description:

// Demonstrates how to compare comments in two PPTX revisions using C# and 

// Aspose.Slides for .NET. The example loads two presentations, extracts all 

// comments per slide and author, identifies comments unique to each revision, 

// outputs them to the console, and saves the presentations.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compare, Comments, Revisions, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Detect differences in comments between two versions of a presentation.

// - Automate review processes for PowerPoint files.

// - Build tools that track comment changes across revisions.

// - Integrate comment comparison into .NET applications.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Collections.Generic;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CompareComments

{

    class Program

    {

        static void Main(string[] args)

        {

            // Paths to the two presentation revisions

            string firstPath = "FirstRevision.pptx";

            string secondPath = "SecondRevision.pptx";



            // Verify that both files exist

            if (!File.Exists(firstPath))

            {

                Console.WriteLine("File not found: " + firstPath);

                return;

            }

            if (!File.Exists(secondPath))

            {

                Console.WriteLine("File not found: " + secondPath);

                return;

            }



            try

            {

                // Load the first presentation

                using (Presentation firstPres = new Presentation(firstPath))

                {

                    // Load the second presentation

                    using (Presentation secondPres = new Presentation(secondPath))

                    {

                        // Collect comments from the first presentation

                        List<string> firstComments = CollectComments(firstPres);

                        // Collect comments from the second presentation

                        List<string> secondComments = CollectComments(secondPres);



                        // Determine comments unique to each revision

                        HashSet<string> firstSet = new HashSet<string>(firstComments);

                        HashSet<string> secondSet = new HashSet<string>(secondComments);



                        Console.WriteLine("Comments only in first revision:");

                        foreach (string comment in firstSet)

                        {

                            if (!secondSet.Contains(comment))

                            {

                                Console.WriteLine(comment);

                            }

                        }



                        Console.WriteLine();

                        Console.WriteLine("Comments only in second revision:");

                        foreach (string comment in secondSet)

                        {

                            if (!firstSet.Contains(comment))

                            {

                                Console.WriteLine(comment);

                            }

                        }



                        // Save presentations before exit (as per requirement)

                        firstPres.Save("FirstRevision_Saved.pptx", SaveFormat.Pptx);

                        secondPres.Save("SecondRevision_Saved.pptx", SaveFormat.Pptx);

                    }

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException ex)

            {

                // Handle unsupported PPTX format

                Console.WriteLine("Unsupported PPTX format: " + ex.Message);

            }

            catch (Aspose.Slides.PptUnsupportedFormatException ex)

            {

                // Handle unsupported PPT format

                Console.WriteLine("Unsupported PPT format: " + ex.Message);

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }



        // Helper method to collect all comments from a presentation

        private static List<string> CollectComments(Presentation pres)

        {

            List<string> comments = new List<string>();

            // Iterate through each comment author

            for (int authorIndex = 0; authorIndex < pres.CommentAuthors.Count; authorIndex++)

            {

                ICommentAuthor author = pres.CommentAuthors[authorIndex];

                // Iterate through each slide

                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)

                {

                    ISlide slide = pres.Slides[slideIndex];

                    // Retrieve comments added by the current author on the current slide

                    IComment[] slideComments = slide.GetSlideComments(author);

                    foreach (IComment comment in slideComments)

                    {

                        // Build a readable representation of the comment

                        string entry = string.Format("Slide {0}, Author: {1}, Text: {2}", slideIndex + 1, author.Name, comment.Text);

                        comments.Add(entry);

                    }

                }

            }

            return comments;

        }

    }

}


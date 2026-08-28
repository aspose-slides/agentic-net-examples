// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX comments to SharePoint list using C#

//

// Description:

// Demonstrates how to read comments from a PPTX file using Aspose.Slides for .NET,

// iterate through comment authors and their comments, and map comment data to

// SharePoint list columns. The example includes placeholder code where the

// SharePoint integration would occur and saves the presentation after processing.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Comments, SharePoint,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Extract PPTX comments for migration to SharePoint.

// - Build C# utilities that synchronize presentation comments with SharePoint lists.

// - Automate comment analysis or reporting from PowerPoint files.

// - Integrate Aspose.Slides comment handling into .NET applications.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportCommentsToSharePoint

{

    class Program

    {

        static void Main(string[] args)

        {

            string presentationPath = "input.pptx";



            if (!File.Exists(presentationPath))

            {

                Console.WriteLine("Presentation file not found: " + presentationPath);

                return;

            }



            try

            {

                using (Presentation presentation = new Presentation(presentationPath))

                {

                    // Iterate over comment authors

                    foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)

                    {

                        // Iterate over comments of each author

                        foreach (IComment comment in commentAuthor.Comments)

                        {

                            // Map comment fields to SharePoint list columns (placeholder)

                            // Example mapping:

                            // Title   = comment.Author.Name

                            // Body    = comment.Text

                            // Slide   = comment.Slide.SlideNumber

                            // Created = comment.CreatedTime

                            Console.WriteLine("Author: " + comment.Author.Name);

                            Console.WriteLine("Comment: " + comment.Text);

                            Console.WriteLine("Slide Number: " + comment.Slide.SlideNumber);

                            Console.WriteLine("Created: " + comment.CreatedTime);



                            // Placeholder for SharePoint list insertion

                            try

                            {

                                // SharePoint integration code would go here.

                                // For example: sharePointList.AddItem(...);

                            }

                            catch (Exception ex)

                            {

                                // Handle missing SharePoint assembly or runtime errors

                                Console.WriteLine("SharePoint integration error: " + ex.Message);

                            }

                        }

                    }



                    // Save the presentation (if any changes were made)

                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                }

            }

            catch (PptxUnsupportedFormatException)

            {

                // Format not supported

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


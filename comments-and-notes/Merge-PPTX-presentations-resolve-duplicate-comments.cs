// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Merge PPTX presentations resolve duplicate comments using C#

//

// Description:

// Demonstrates how to merge two PPTX presentations while preserving and

// resolving duplicate comment authors using C# and Aspose.Slides for .NET.

// The example loads two source presentations, creates unique author names,

// maps comments to the new authors, clones slides, transfers comments, and

// saves the merged presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Merge, Comments, Duplicate Authors,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Merge multiple PowerPoint files into a single presentation.

// - Preserve and correctly reassign comments when author names collide.

// - Automate comment handling during presentation consolidation.

// - Build .NET tools for PowerPoint comment management and workflow automation.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Collections.Generic;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace MergePresentations

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath1 = "Presentation1.pptx";

            string inputPath2 = "Presentation2.pptx";

            string outputPath = "MergedPresentation.pptx";



            if (!File.Exists(inputPath1))

            {

                Console.WriteLine("Input file 1 does not exist: " + inputPath1);

                return;

            }



            if (!File.Exists(inputPath2))

            {

                Console.WriteLine("Input file 2 does not exist: " + inputPath2);

                return;

            }



            try

            {

                // Load source presentations

                Aspose.Slides.Presentation sourcePres1 = new Aspose.Slides.Presentation(inputPath1);

                Aspose.Slides.Presentation sourcePres2 = new Aspose.Slides.Presentation(inputPath2);



                // Destination presentation

                Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();



                // Mapping of source authors to destination authors

                Dictionary<Aspose.Slides.CommentAuthor, Aspose.Slides.ICommentAuthor> authorMap = new Dictionary<Aspose.Slides.CommentAuthor, Aspose.Slides.ICommentAuthor>();



                // Process authors from first source

                foreach (object authorObj in sourcePres1.CommentAuthors)

                {

                    Aspose.Slides.CommentAuthor srcAuthor = (Aspose.Slides.CommentAuthor)authorObj;

                    string uniqueName = srcAuthor.Name + "_1";

                    Aspose.Slides.ICommentAuthor destAuthor = destPres.CommentAuthors.AddAuthor(uniqueName, srcAuthor.Initials);

                    authorMap.Add(srcAuthor, destAuthor);

                }



                // Process authors from second source

                foreach (object authorObj in sourcePres2.CommentAuthors)

                {

                    Aspose.Slides.CommentAuthor srcAuthor = (Aspose.Slides.CommentAuthor)authorObj;

                    string uniqueName = srcAuthor.Name + "_2";

                    Aspose.Slides.ICommentAuthor destAuthor = destPres.CommentAuthors.AddAuthor(uniqueName, srcAuthor.Initials);

                    authorMap.Add(srcAuthor, destAuthor);

                }



                // Clone slides from first source

                Aspose.Slides.ISlideCollection destSlides = destPres.Slides;

                foreach (Aspose.Slides.ISlide srcSlide in sourcePres1.Slides)

                {

                    destSlides.AddClone(srcSlide);

                }

                int firstSourceStartIndex = 1; // default slide at index 0



                // Clone slides from second source

                foreach (Aspose.Slides.ISlide srcSlide in sourcePres2.Slides)

                {

                    destSlides.AddClone(srcSlide);

                }

                int secondSourceStartIndex = firstSourceStartIndex + sourcePres1.Slides.Count;



                // Transfer comments from first source

                for (int i = 0; i < sourcePres1.Slides.Count; i++)

                {

                    Aspose.Slides.ISlide srcSlide = sourcePres1.Slides[i];

                    Aspose.Slides.ISlide destSlide = destPres.Slides[firstSourceStartIndex + i];

                    Aspose.Slides.IComment[] srcComments = srcSlide.GetSlideComments(null);

                    foreach (Aspose.Slides.IComment srcComment in srcComments)

                    {

                        Aspose.Slides.CommentAuthor srcAuthor = (Aspose.Slides.CommentAuthor)srcComment.Author;

                        Aspose.Slides.ICommentAuthor destAuthor = authorMap[srcAuthor];

                        destAuthor.Comments.AddComment(srcComment.Text, destSlide, srcComment.Position, srcComment.CreatedTime);

                    }

                }



                // Transfer comments from second source

                for (int i = 0; i < sourcePres2.Slides.Count; i++)

                {

                    Aspose.Slides.ISlide srcSlide = sourcePres2.Slides[i];

                    Aspose.Slides.ISlide destSlide = destPres.Slides[secondSourceStartIndex + i];

                    Aspose.Slides.IComment[] srcComments = srcSlide.GetSlideComments(null);

                    foreach (Aspose.Slides.IComment srcComment in srcComments)

                    {

                        Aspose.Slides.CommentAuthor srcAuthor = (Aspose.Slides.CommentAuthor)srcComment.Author;

                        Aspose.Slides.ICommentAuthor destAuthor = authorMap[srcAuthor];

                        destAuthor.Comments.AddComment(srcComment.Text, destSlide, srcComment.Position, srcComment.CreatedTime);

                    }

                }



                // Save merged presentation

                destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);



                // Dispose resources

                sourcePres1.Dispose();

                sourcePres2.Dispose();

                destPres.Dispose();

            }

            catch (Exception ex)

            {

                // Format not supported or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


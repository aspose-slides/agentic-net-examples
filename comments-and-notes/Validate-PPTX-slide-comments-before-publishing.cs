// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate PPTX slide comments before publishing using C#

//

// Description:

// Demonstrates how to validate PPTX slide comments before publishing using C# 

// and Aspose.Slides for .NET. The example loads a presentation, checks each 

// slide for existing comments, adds a default comment when none are found, 

// and saves the validated presentation. This pattern helps automate 

// comment validation in PowerPoint workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Slide, Comments, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Ensure every slide contains at least one comment before publishing.

// - Automate validation of slide comments in .NET applications.

// - Integrate comment checks into PowerPoint processing pipelines.

// - Generate default comments for slides lacking annotations.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



namespace SlidesCommentValidator

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "validated_output.pptx";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Ensure there is at least one comment author

                Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("AutoAuthor", "AA");



                // Position for automatically added comments

                System.Drawing.PointF defaultPosition = new System.Drawing.PointF(0.1f, 0.1f);



                // Iterate through all slides and validate comments

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

                {

                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    Aspose.Slides.IComment[] slideComments = slide.GetSlideComments(null);



                    // If a slide has no comments, add a default comment

                    if (slideComments == null || slideComments.Length == 0)

                    {

                        author.Comments.AddComment("Auto-generated comment for slide " + (slideIndex + 1), slide, defaultPosition, DateTime.Now);

                    }

                }



                // Save the validated presentation

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);



                // Dispose the presentation object

                presentation.Dispose();



                Console.WriteLine("Presentation validated and saved to: " + outputPath);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                // Format not supported comment

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


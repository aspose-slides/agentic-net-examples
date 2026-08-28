// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Enable comment rendering in JPG with notes using C#

//

// Description:

// Demonstrates how to enable comment rendering in JPG with notes using C# and 

// Aspose.Slides for .NET. The example loads a PPTX file, configures rendering 

// options to include notes and comments, generates JPEG images for slides that 

// contain comments, and saves the (potentially unchanged) presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPG, Enable, Comment, 

// Rendering, Notes, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate enable comment rendering in JPG with notes.

// - Build C# tools for PowerPoint presentation processing.

// - Generate JPEG images of slides that contain comments, including notes.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlidesCommentNotesJpg

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPresentationPath = "output.pptx";

            string outputImagesDir = "output_images";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                using (Presentation pres = new Presentation(inputPath))

                {

                    if (!Directory.Exists(outputImagesDir))

                    {

                        Directory.CreateDirectory(outputImagesDir);

                    }



                    // Configure rendering options to include notes and comments

                    RenderingOptions renderingOptions = new RenderingOptions();

                    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();

                    notesCommentsOptions.NotesPosition = NotesPositions.BottomTruncated;

                    notesCommentsOptions.CommentsPosition = CommentsPositions.Right;

                    notesCommentsOptions.ShowCommentsByNoAuthor = true;

                    renderingOptions.SlidesLayoutOptions = notesCommentsOptions;



                    for (int index = 0; index < pres.Slides.Count; index++)

                    {

                        ISlide slide = pres.Slides[index];

                        IComment[] slideComments = slide.GetSlideComments(null);

                        if (slideComments != null && slideComments.Length > 0)

                        {

                            IImage image = slide.GetImage(renderingOptions, 1f, 1f);

                            string imagePath = Path.Combine(outputImagesDir, $"Slide_{slide.SlideNumber}.jpg");

                            image.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);

                        }

                    }



                    // Save the (possibly unchanged) presentation before exiting

                    pres.Save(outputPresentationPath, SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


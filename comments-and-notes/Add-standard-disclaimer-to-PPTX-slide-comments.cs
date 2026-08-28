// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add standard disclaimer to PPTX slide comments using C#

//

// Description:

// Demonstrates how to add a standard disclaimer comment to every slide in a

// PPTX presentation using C# and Aspose.Slides for .NET. The example loads an

// existing presentation, creates a comment author, inserts the disclaimer text

// as a comment on each slide at a specified position, and saves the updated

// file. This pattern can be used to automate the inclusion of legal or

// confidentiality notices in PowerPoint files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Disclaimer, Slide Comments,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automatically add confidentiality or legal disclaimer comments to all slides.

// - Integrate disclaimer insertion into .NET PowerPoint processing pipelines.

// - Ensure compliance by embedding standard notices in presentation files.

// - Generate or modify PPTX files with consistent comment metadata.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



namespace AddDisclaimerComments

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            string outputPath = args.Length > 1 ? args[1] : "output.pptx";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Add or retrieve the disclaimer author

                    Aspose.Slides.ICommentAuthor disclaimerAuthor = presentation.CommentAuthors.AddAuthor("Disclaimer", "DS");



                    // Position for the comment on each slide

                    PointF commentPosition = new PointF(0.1f, 0.1f);

                    string disclaimerText = "This presentation contains confidential information. Do not distribute without permission.";



                    // Add the disclaimer comment to every slide

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        Aspose.Slides.ISlide slide = presentation.Slides[i];

                        disclaimerAuthor.Comments.AddComment(disclaimerText, slide, commentPosition, DateTime.Now);

                    }



                    // Save the modified presentation

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported for PPTX files

                Console.WriteLine("The file format is not supported (PPTX).");

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                // Format not supported for PPT files

                Console.WriteLine("The file format is not supported (PPT).");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


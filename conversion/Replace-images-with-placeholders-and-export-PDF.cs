// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Replace images with placeholders and export PDF using C#

//

// Description:

// Demonstrates how to replace all picture frames in a PowerPoint presentation

// with rectangular placeholders containing the text "Image Placeholder" and

// then export the modified presentation to PDF using Aspose.Slides for .NET.

// The example includes loading a PPTX file, iterating through slides and shapes,

// performing the replacement, and saving the result as a PDF document.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, PDF, Replace Images, Placeholders, 

// Presentation Processing, Automation, Office Automation

//

// Use Cases:

// - Automate the replacement of images with placeholders in PPTX files.

// - Generate PDF versions of presentations after image removal.

// - Build .NET tools for preparing slide decks for review or publishing.

// - Integrate image placeholder logic into larger presentation workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ReplaceImages

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPath = "output.pdf";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                Presentation presentation = new Presentation(inputPath);



                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

                {

                    ISlide slide = presentation.Slides[slideIndex];



                    for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)

                    {

                        IShape shape = slide.Shapes[shapeIndex];



                        if (shape is IPictureFrame picture)

                        {

                            float x = picture.X;

                            float y = picture.Y;

                            float width = picture.Width;

                            float height = picture.Height;



                            slide.Shapes.Remove(picture);



                            IAutoShape placeholder = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, width, height);

                            placeholder.TextFrame.Text = "Image Placeholder";

                        }

                    }

                }



                // Export the modified presentation to PDF

                presentation.Save(outputPath, SaveFormat.Pdf);

                presentation.Dispose();

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Compare JPG size before after comment rendering using C#

//

// Description:

// Demonstrates how to compare JPG size before and after comment rendering using C#

// and Aspose.Slides for .NET. The example loads a PPTX file, exports each slide

// to JPEG images twice—once without rendering comments and once with comments

// rendered—then calculates and displays the total file size difference. It also

// saves a copy of the original presentation.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPG, Compare, Size, Before, After,

// Presentation Processing, Office Automation, Comments Rendering

//

// Use Cases:

// - Automate comparison of JPEG image sizes before and after comment rendering.

// - Build C# tools for PowerPoint slide image export with optional comment inclusion.

// - Validate the impact of comment rendering on exported slide assets.

// - Integrate slide export and size analysis into .NET applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace Example

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input presentation and output directories

            string inputPath = "input.pptx";

            string outputDir = "output";

            string outputDirWithComments = "output_with_comments";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            // Ensure output directories are created

            Directory.CreateDirectory(outputDir);

            Directory.CreateDirectory(outputDirWithComments);



            try

            {

                // Load the presentation

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

                {

                    // Convert each slide to JPG without rendering comments

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        Aspose.Slides.ISlide slide = presentation.Slides[i];

                        Aspose.Slides.IImage image = slide.GetImage(1f, 1f);

                        string imagePath = Path.Combine(outputDir, $"Slide_{i + 1}.jpg");

                        image.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);

                    }



                    // Set rendering options to include comments

                    Aspose.Slides.Export.RenderingOptions renderingOptions = new Aspose.Slides.Export.RenderingOptions();

                    Aspose.Slides.Export.NotesCommentsLayoutingOptions notesComments = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();

                    notesComments.CommentsPosition = Aspose.Slides.Export.CommentsPositions.Right;

                    notesComments.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomTruncated;

                    renderingOptions.SlidesLayoutOptions = notesComments;



                    // Convert each slide to JPG with comments rendered

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        Aspose.Slides.ISlide slide = presentation.Slides[i];

                        Aspose.Slides.IImage image = slide.GetImage(renderingOptions, 1f, 1f);

                        string imagePath = Path.Combine(outputDirWithComments, $"Slide_{i + 1}_comments.jpg");

                        image.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);

                    }



                    // Calculate total file sizes for comparison

                    long totalSizeWithout = 0;

                    long totalSizeWith = 0;

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        string pathWithout = Path.Combine(outputDir, $"Slide_{i + 1}.jpg");

                        string pathWith = Path.Combine(outputDirWithComments, $"Slide_{i + 1}_comments.jpg");

                        if (File.Exists(pathWithout))

                        {

                            totalSizeWithout += new FileInfo(pathWithout).Length;

                        }

                        if (File.Exists(pathWith))

                        {

                            totalSizeWith += new FileInfo(pathWith).Length;

                        }

                    }



                    Console.WriteLine($"Total size without comments: {totalSizeWithout} bytes");

                    Console.WriteLine($"Total size with comments: {totalSizeWith} bytes");

                    Console.WriteLine($"Size increase: {totalSizeWith - totalSizeWithout} bytes");



                    // Save the presentation before exiting (as required)

                    string savedPresentationPath = Path.Combine(outputDir, "SavedPresentation.pptx");

                    presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The requested format is not supported.");

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine($"An error occurred: {ex.Message}");

            }

        }

    }

}


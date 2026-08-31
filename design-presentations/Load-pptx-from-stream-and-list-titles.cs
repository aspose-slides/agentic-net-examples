// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load pptx from stream and list slide titles using C#

//

// Description:

// Demonstrates how to load a PPTX file from a FileStream, enumerate each slide

// to find title placeholders, output the titles to the console, and save the

// presentation using Aspose.Slides for .NET. The example illustrates typical

// presentation-processing steps for PowerPoint files in a standalone console

// application. Developers can adapt this pattern to automate PPTX workflows,

// extract metadata, or integrate presentation handling into .NET solutions.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Stream, List Titles, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate loading PPTX from a stream and extracting slide titles.

// - Build C# tools for PowerPoint presentation analysis.

// - Generate or modify PPTX files in .NET applications.

// - Validate presentation content before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Util;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))

            {

                using (Presentation presentation = new Presentation(fileStream))

                {

                    // Enumerate slide titles

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        ISlide slide = presentation.Slides[i];

                        IShape[] titleShapes = SlideUtil.FindShapesByPlaceholderType(slide, PlaceholderType.Title);

                        foreach (IShape shape in titleShapes)

                        {

                            if (shape is IAutoShape autoShape && autoShape.TextFrame != null)

                            {

                                string titleText = autoShape.TextFrame.Text;

                                Console.WriteLine($"Slide {i + 1} Title: {titleText}");

                            }

                        }

                    }



                    // Save presentation before exit

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            // Handle other exceptions (e.g., external URLs)

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


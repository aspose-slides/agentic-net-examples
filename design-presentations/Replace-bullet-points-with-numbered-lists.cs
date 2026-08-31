// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Replace bullet points with numbered lists using C#

//

// Description:

// Demonstrates how to replace bullet points with numbered lists using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, Bullet, Points, 

// Numbered, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate replace bullet points with numbered lists.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        if (args.Length >= 1)

        {

            inputPath = args[0];

        }

        if (args.Length >= 2)

        {

            outputPath = args[1];

        }



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                // Iterate through all slides

                foreach (Aspose.Slides.ISlide slide in presentation.Slides)

                {

                    // Iterate through all shapes on the slide

                    foreach (Aspose.Slides.IShape shape in slide.Shapes)

                    {

                        // Process only AutoShape objects that contain a TextFrame

                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;

                        if (autoShape != null && autoShape.TextFrame != null)

                        {

                            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                            // Replace each paragraph's bullet with a numbered bullet, preserving depth

                            for (int i = 0; i < textFrame.Paragraphs.Count; i++)

                            {

                                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[i];

                                paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;

                                // Keep existing indentation level (Depth) unchanged

                                paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)1;

                            }

                        }

                    }

                }



                // Save the modified presentation

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}


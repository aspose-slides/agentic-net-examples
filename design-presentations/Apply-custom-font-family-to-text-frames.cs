// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply custom font family to text frames using C#

//

// Description:

// Demonstrates how to apply a custom font family to all text portions within

// text frames of a PowerPoint presentation using Aspose.Slides for .NET.

// The example loads an existing PPTX, iterates through slides, shapes and

// groups, updates the LatinFont of each portion, and saves the result.

// This pattern can be used to enforce branding or replace missing fonts.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, custom font, font family, text frames,

// presentation processing, Office automation

//

// Use Cases:

// - Enforce corporate font across all text in a presentation.

// - Replace missing or unsupported fonts in existing PPTX files.

// - Build .NET tools that modify text styling in bulk.

// - Prepare presentations for distribution where specific fonts are required.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";

        string customFontFamily = "Arial";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            using (Presentation presentation = new Presentation(inputPath))

            {

                foreach (ISlide slide in presentation.Slides)

                {

                    foreach (IShape shape in slide.Shapes)

                    {

                        if (shape is IAutoShape autoShape && autoShape.TextFrame != null)

                        {

                            ITextFrame textFrame = autoShape.TextFrame;

                            foreach (IParagraph paragraph in textFrame.Paragraphs)

                            {

                                foreach (IPortion portion in paragraph.Portions)

                                {

                                    // Change only the font family, keep other formatting intact

                                    portion.PortionFormat.LatinFont = new FontData(customFontFamily);

                                }

                            }

                        }

                        else if (shape is IGroupShape groupShape)

                        {

                            ProcessGroupShape(groupShape, customFontFamily);

                        }

                    }

                }



                // Save the modified presentation

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }



    static void ProcessGroupShape(IGroupShape groupShape, string fontFamily)

    {

        foreach (IShape shape in groupShape.Shapes)

        {

            if (shape is IAutoShape autoShape && autoShape.TextFrame != null)

            {

                foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)

                {

                    foreach (IPortion portion in paragraph.Portions)

                    {

                        portion.PortionFormat.LatinFont = new FontData(fontFamily);

                    }

                }

            }

            else if (shape is IGroupShape innerGroup)

            {

                ProcessGroupShape(innerGroup, fontFamily);

            }

        }

    }

}


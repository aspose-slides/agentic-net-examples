// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add timestamp watermark to PPTX and export to GIF using C#

//

// Description:

// Demonstrates how to add a timestamp watermark to each slide of a PPTX file

// using Aspose.Slides for .NET and then export the modified presentation as an

// animated GIF. The example includes loading a presentation, inserting a

// timestamp shape, saving the updated PPTX, and converting it to GIF with

// specific options.

//

// Keywords:

// C#, PowerPoint, PPTX, GIF, Aspose.Slides for .NET, Timestamp, Watermark,

// Presentation Processing, Office Automation, Animated GIF

//

// Use Cases:

// - Automatically embed current timestamp on all slides of a presentation.

// - Generate animated GIF previews of PowerPoint files with watermarks.

// - Build .NET tools for presentation branding and conversion workflows.

// - Validate and preview PPTX content before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AddTimestampWatermark

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            string outputPresentationPath = "output_with_watermark.pptx";

            string outputGifPath = "output.gif";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Add timestamp watermark to each slide

                    foreach (ISlide slide in presentation.Slides)

                    {

                        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        IAutoShape watermark = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 30);

                        watermark.AddTextFrame(timestamp);

                        watermark.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;

                        watermark.FillFormat.FillType = FillType.NoFill;

                        watermark.LineFormat.FillFormat.FillType = FillType.NoFill;

                    }



                    // Save the modified presentation

                    presentation.Save(outputPresentationPath, SaveFormat.Pptx);



                    // Export to animated GIF

                    GifOptions gifOptions = new GifOptions

                    {

                        DefaultDelay = 1000,

                        TransitionFps = 25,

                        ExportHiddenSlides = false

                    };

                    presentation.Save(outputGifPath, SaveFormat.Gif, gifOptions);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported for the input file

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                // Format not supported for the input file

                Console.WriteLine("The presentation format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}


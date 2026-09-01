// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add timestamp watermark to PPTX PDF using C#

//

// Description:

// Demonstrates how to add a timestamp watermark to each slide of a PPTX file

// and then convert the presentation to PDF using Aspose.Slides for .NET. The

// example loads a presentation, creates a semi‑transparent rectangle with the

// current date‑time in the bottom‑right corner of every slide, saves an

// intermediate PPTX (optional) and finally exports the result as a PDF file.

// This pattern can be used to automate watermarking and conversion tasks in

// .NET applications.

//

// Keywords:

// C#, Aspose.Slides, PPTX, PDF, Timestamp, Watermark, Presentation Conversion,

// PowerPoint Automation, .NET

//

// Use Cases:

// - Add a timestamp watermark to PowerPoint slides before distribution.

// - Convert watermarked PPTX files to PDF in batch processes.

// - Integrate presentation watermarking into C# tools or services.

// - Ensure document traceability with generation timestamps.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AddTimestampWatermark

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "input.pptx";

            string outputPdfPath = "output.pdf";



            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            try

            {

                using (Presentation presentation = new Presentation(inputPath))

                {

                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");



                    foreach (ISlide slide in presentation.Slides)

                    {

                        // Define watermark size and position (bottom‑right corner)

                        float shapeWidth = 300f;

                        float shapeHeight = 30f;

                        float posX = presentation.SlideSize.Size.Width - shapeWidth - 10f;

                        float posY = presentation.SlideSize.Size.Height - shapeHeight - 10f;



                        // Add a transparent rectangle with timestamp text

                        IAutoShape watermark = slide.Shapes.AddAutoShape(

                            ShapeType.Rectangle,

                            posX,

                            posY,

                            shapeWidth,

                            shapeHeight);



                        watermark.AddTextFrame(timestamp);

                        watermark.FillFormat.FillType = FillType.NoFill;

                        watermark.LineFormat.FillFormat.FillType = FillType.NoFill;



                        // Format the text

                        if (watermark.TextFrame != null && watermark.TextFrame.Paragraphs.Count > 0)

                        {

                            IPortion portion = watermark.TextFrame.Paragraphs[0].Portions[0];

                            portion.PortionFormat.FontHeight = 12f;

                            portion.PortionFormat.FontBold = NullableBool.True;

                            portion.PortionFormat.FillFormat.FillType = FillType.Solid;

                            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

                        }

                    }



                    // Save the modified presentation (optional, satisfies "save before exit")

                    string tempPptxPath = "temp_output.pptx";

                    presentation.Save(tempPptxPath, SaveFormat.Pptx);



                    // Save as PDF with default options

                    PdfOptions pdfOptions = new PdfOptions();

                    presentation.Save(outputPdfPath, SaveFormat.Pdf, pdfOptions);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}


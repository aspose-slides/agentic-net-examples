using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source presentation
            using (Presentation sourcePres = new Presentation("source.pptx"))
            {
                // Access the first slide
                ISlide sourceSlide = sourcePres.Slides[0];

                // Assume the first shape is an AutoShape containing text
                IAutoShape autoShape = sourceSlide.Shapes[0] as IAutoShape;
                if (autoShape == null || autoShape.TextFrame == null)
                {
                    throw new InvalidOperationException("No text shape found on the first slide.");
                }

                // Get the text of the first paragraph
                string paragraphText = autoShape.TextFrame.Paragraphs[0].Text;

                // Create a temporary presentation to render the paragraph as an image
                using (Presentation tempPres = new Presentation())
                {
                    // Add a blank slide
                    ISlide tempSlide = tempPres.Slides.AddEmptySlide(tempPres.Slides[0].LayoutSlide);

                    // Add a textbox shape with the paragraph text
                    IAutoShape textBox = tempSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
                    textBox.AddTextFrame(paragraphText);

                    // Render the slide to an image
                    using (IImage slideImage = tempSlide.GetImage(1f, 1f))
                    {
                        // Save the image to a memory stream
                        using (MemoryStream imgStream = new MemoryStream())
                        {
                            slideImage.Save(imgStream, Aspose.Slides.ImageFormat.Png);
                            imgStream.Position = 0;

                            // Create the final presentation that will be saved as PDF
                            using (Presentation finalPres = new Presentation())
                            {
                                // Add a blank slide
                                ISlide finalSlide = finalPres.Slides.AddEmptySlide(finalPres.Slides[0].LayoutSlide);

                                // Add the rendered image as a picture shape
                                IPictureFrame picture = finalSlide.Shapes.AddPictureFrame(
                                    ShapeType.Rectangle,
                                    0,
                                    0,
                                    slideImage.Width,
                                    slideImage.Height,
                                    finalPres.Images.AddImage(imgStream));

                                // Save the final presentation as PDF
                                PdfOptions pdfOptions = new PdfOptions();
                                finalPres.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
                            }
                        }
                    }
                }

                // Save the source presentation before exiting (as required)
                sourcePres.Save("source_saved.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
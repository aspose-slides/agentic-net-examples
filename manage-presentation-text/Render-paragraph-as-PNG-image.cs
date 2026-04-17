using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RenderParagraphToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPptxPath = "input.pptx";
            // Output PNG path for the rendered paragraph
            string outputPngPath = "paragraph.png";
            // Output presentation path (to satisfy save-before-exit rule)
            string outputPptxPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPptxPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPptxPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPptxPath);

                // Get first slide
                ISlide slide = pres.Slides[0];

                // Assume first shape is an AutoShape containing a paragraph
                IAutoShape autoShape = (IAutoShape)slide.Shapes[0];
                ITextFrame textFrame = autoShape.TextFrame;
                IParagraph paragraph = textFrame.Paragraphs[0];
                string paragraphText = paragraph.Text;

                // Create bitmap and draw the paragraph text
                int bitmapWidth = 800;
                int bitmapHeight = 200;
                Bitmap bitmap = new Bitmap(bitmapWidth, bitmapHeight);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.White);
                    Font font = new Font("Arial", 24);
                    Brush brush = Brushes.Black;
                    graphics.DrawString(paragraphText, font, brush, new PointF(10, 10));
                }

                // Save bitmap as PNG (extension determines format, no ImageFormat enum used)
                bitmap.Save(outputPngPath);
                bitmap.Dispose();

                // Save presentation before exit (as required)
                pres.Save(outputPptxPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Paragraph rendered to PNG successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
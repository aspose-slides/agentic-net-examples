using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TimestampTagExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Presentation presentation = null;
            try
            {
                if (File.Exists(inputPath))
                {
                    presentation = new Presentation(inputPath);
                }
                else
                {
                    presentation = new Presentation();
                }

                // Attach a timestamp tag to each slide
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    // Add a textbox shape with the timestamp (position and size can be adjusted)
                    IAutoShape timestampShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 350, 200, 30);
                    timestampShape.TextFrame.Text = timestamp;
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
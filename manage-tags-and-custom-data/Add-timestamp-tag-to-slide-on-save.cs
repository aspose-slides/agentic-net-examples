// -----------------------------------------------------------------------------
// Example: Add timestamp tag to slide on save using C#
//
// Description:
// Demonstrates how to add a timestamp textbox to each slide of a PowerPoint
// presentation before saving it using C# and Aspose.Slides for .NET. The example
// shows how to load an existing presentation (or create a new one), iterate
// through all slides, insert a shape containing the current date and time, and
// then save the modified presentation. This pattern can be used to automate
// PPTX workflows, embed metadata, or track changes in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Timestamp, Slide, Save,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a timestamp tag to each slide on save.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
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

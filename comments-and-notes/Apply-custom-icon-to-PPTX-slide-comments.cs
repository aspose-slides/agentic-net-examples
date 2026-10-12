// -----------------------------------------------------------------------------
// Example: Apply Custom Icon to PPTX Slide Comments Using Aspose.Slides
//
// Description:
// This console application loads an existing PowerPoint PPTX file or creates a new one,
// adds a modern comment with a priority tag, determines the priority level, and inserts
// a colored rectangle shape as a custom icon near the comment. The result is saved as a
// PPTX file, demonstrating automated comment visualization with Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide comments, custom icon, comment priority
//
// Use Cases:
// - Visualize comment importance in generated presentations.
// - Automate annotation of slides with priority-based icons.
// - Integrate comment handling into PowerPoint report generation pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.10.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace AsposeSlidesCommentIconExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = null;

            try
            {
                if (File.Exists(inputPath))
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();
                }

                // Ensure at least one slide exists
                if (presentation.Slides.Count == 0)
                {
                    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                }

                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a comment author
                Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

                // Define comment priority (could be parameterized)
                string priority = "High"; // Options: High, Medium, Low

                // Add a modern comment with priority information
                string commentText = $"Priority: {priority} - Review required.";
                Aspose.Slides.IModernComment comment = author.Comments.AddModernComment(
                    commentText,
                    slide,
                    null,
                    new System.Drawing.PointF(200f, 150f),
                    System.DateTime.Now);

                // Determine icon color based on priority
                System.Drawing.Color iconColor;
                if (priority.Equals("High", StringComparison.OrdinalIgnoreCase))
                {
                    iconColor = System.Drawing.Color.Red;
                }
                else if (priority.Equals("Medium", StringComparison.OrdinalIgnoreCase))
                {
                    iconColor = System.Drawing.Color.Orange;
                }
                else if (priority.Equals("Low", StringComparison.OrdinalIgnoreCase))
                {
                    iconColor = System.Drawing.Color.Green;
                }
                else
                {
                    iconColor = System.Drawing.Color.Gray;
                }

                // Insert a rectangle shape as a custom icon near the comment
                float iconX = comment.Position.X - 20f;
                float iconY = comment.Position.Y - 20f;
                Aspose.Slides.IShape iconShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    iconX,
                    iconY,
                    15f,
                    15f);

                iconShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                iconShape.FillFormat.SolidFillColor.Color = iconColor;

                // Optionally remove the shape border
                iconShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                iconShape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Transparent;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved to '{outputPath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
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

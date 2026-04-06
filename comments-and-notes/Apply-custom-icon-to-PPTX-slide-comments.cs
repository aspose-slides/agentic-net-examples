using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CommentIconDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists, otherwise create a new one
            Aspose.Slides.Presentation presentation;
            try
            {
                if (File.Exists(inputPath))
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();
                    // Add an empty slide to the new presentation
                    presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Create a new presentation as fallback
                presentation = new Aspose.Slides.Presentation();
                presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
            }

            // Ensure there is at least one slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a comment author
            Aspose.Slides.ICommentAuthor author = presentation.CommentAuthors.AddAuthor("John Doe", "JD");

            // Define comment text with priority metadata (e.g., "[High]")
            string commentText = "[High] Review the financial figures.";
            System.Drawing.PointF commentPosition = new System.Drawing.PointF(100, 100);
            Aspose.Slides.IModernComment modernComment = author.Comments.AddModernComment(
                commentText,
                slide,
                null,
                commentPosition,
                DateTime.Now);

            // Determine priority from comment text
            string priority = "Low";
            if (commentText.StartsWith("[High]"))
                priority = "High";
            else if (commentText.StartsWith("[Medium]"))
                priority = "Medium";

            // Choose icon color based on priority
            System.Drawing.Color iconColor = System.Drawing.Color.Green;
            if (priority == "High")
                iconColor = System.Drawing.Color.Red;
            else if (priority == "Medium")
                iconColor = System.Drawing.Color.Orange;

            // Add an icon shape near the comment position
            float iconSize = 20f;
            Aspose.Slides.IAutoShape iconShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                commentPosition.X - iconSize - 5,
                commentPosition.Y,
                iconSize,
                iconSize);
            iconShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            iconShape.FillFormat.SolidFillColor.Color = iconColor;
            iconShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

            // Save the presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save exceptions (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
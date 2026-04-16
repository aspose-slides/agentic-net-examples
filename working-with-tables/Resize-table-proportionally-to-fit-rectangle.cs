using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableResizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the target rectangle where the table should fit (in points)
            const float targetX = 100f;
            const float targetY = 100f;
            const float targetWidth = 400f;
            const float targetHeight = 300f;

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Define table dimensions (3 rows x 3 columns)
                const int rows = 3;
                const int cols = 3;
                double[] columnWidths = new double[cols];
                double[] rowHeights = new double[rows];

                // Initialize column widths and row heights with equal sizes
                for (int i = 0; i < cols; i++)
                {
                    columnWidths[i] = 100.0; // 100 points per column
                }
                for (int i = 0; i < rows; i++)
                {
                    rowHeights[i] = 50.0; // 50 points per row
                }

                // Add the table at origin (0,0) using the correct overload
                Aspose.Slides.ITable table = slide.Shapes.AddTable(0f, 0f, columnWidths, rowHeights);

                // Calculate original table size
                double originalWidth = 0;
                foreach (double w in columnWidths) { originalWidth += w; }
                double originalHeight = 0;
                foreach (double h in rowHeights) { originalHeight += h; }

                // Determine scaling factor to fit proportionally within the target rectangle
                float scaleX = targetWidth / (float)originalWidth;
                float scaleY = targetHeight / (float)originalHeight;
                float scale = Math.Min(scaleX, scaleY);

                // Apply scaled size to the table
                table.Width = (float)originalWidth * scale;
                table.Height = (float)originalHeight * scale;

                // Center the table within the target rectangle
                table.X = targetX + (targetWidth - table.Width) / 2f;
                table.Y = targetY + (targetHeight - table.Height) / 2f;

                // Save the presentation
                try
                {
                    presentation.Save("ResizedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException)
                {
                    // Handle unsupported PPTX format
                    Console.WriteLine("The PPTX format is not supported.");
                }
                catch (Aspose.Slides.PptUnsupportedFormatException)
                {
                    // Handle unsupported PPT format
                    Console.WriteLine("The PPT format is not supported.");
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
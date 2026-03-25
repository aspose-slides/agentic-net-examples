using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "template.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation;

            try
            {
                if (File.Exists(inputPath))
                {
                    // Load existing presentation if template exists
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    // Create a new presentation when template is missing
                    presentation = new Aspose.Slides.Presentation();
                }

                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Define column widths and row heights for the table
                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 30, 30 };

                // Add table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Populate header row
                table[0, 0].TextFrame.Text = "Header 1";
                table[0, 1].TextFrame.Text = "Header 2";
                table[0, 2].TextFrame.Text = "Header 3";

                // Populate first data row
                table[1, 0].TextFrame.Text = "Row1 Col1";
                table[1, 1].TextFrame.Text = "Row1 Col2";
                table[1, 2].TextFrame.Text = "Row1 Col3";

                // Populate second data row
                table[2, 0].TextFrame.Text = "Row2 Col1";
                table[2, 1].TextFrame.Text = "Row2 Col2";
                table[2, 2].TextFrame.Text = "Row2 Col3";

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
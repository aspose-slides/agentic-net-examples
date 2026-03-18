using System;
using Aspose.Slides.Export;

namespace MyPresentationApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load the existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Access the specific slide (e.g., second slide, index 1)
                Aspose.Slides.ISlide slide = presentation.Slides[1];

                // Define column widths and row heights for the table
                double[] columnWidths = new double[] { 150, 150, 150 };
                double[] rowHeights = new double[] { 50, 50, 50 };

                // Add a new table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

                // Populate header cells
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

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
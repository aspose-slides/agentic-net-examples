using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation())
            {
                ISlide slide = presentation.Slides[0];

                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 30, 30, 30, 30, 30 };
                ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Header row
                table.Rows[0][0].TextFrame.Text = "Item";
                table.Rows[0][1].TextFrame.Text = "Quantity";
                table.Rows[0][2].TextFrame.Text = "Price";

                // Sample data
                string[] items = new string[] { "Product A", "Product B", "Product C" };
                int[] quantities = new int[] { 5, 12, 7 };
                double[] prices = new double[] { 9.99, 15.5, 3.75 };

                for (int i = 0; i < items.Length; i++)
                {
                    int rowIndex = i + 1; // data rows start after header

                    table.Rows[rowIndex][0].TextFrame.Text = items[i];
                    // Apply custom numeric format for quantity (e.g., thousand separator)
                    table.Rows[rowIndex][1].TextFrame.Text = string.Format("{0:#,##0}", quantities[i]);
                    // Apply custom numeric format for price (two decimal places)
                    table.Rows[rowIndex][2].TextFrame.Text = string.Format("{0:#,##0.00}", prices[i]);
                }

                presentation.Save("TableWithCustomNumberFormat.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
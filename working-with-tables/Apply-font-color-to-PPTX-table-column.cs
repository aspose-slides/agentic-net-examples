using System;
using System.Drawing;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                var presentationPath = "input.pptx";
                var outputPath = "output.pptx";

                using (var pres = new Aspose.Slides.Presentation(presentationPath))
                {
                    var slide = pres.Slides[0];
                    Aspose.Slides.Table table = null;
                    foreach (var shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.Table)
                        {
                            table = (Aspose.Slides.Table)shape;
                            break;
                        }
                    }

                    if (table != null)
                    {
                        int columnIndex = 1; // target column (zero‑based)
                        for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                        {
                            var cell = table[rowIndex, columnIndex];
                            if (cell.TextFrame != null &&
                                cell.TextFrame.Paragraphs.Count > 0 &&
                                cell.TextFrame.Paragraphs[0].Portions.Count > 0)
                            {
                                var portion = cell.TextFrame.Paragraphs[0].Portions[0];
                                var format = portion.PortionFormat;
                                format.FontBold = Aspose.Slides.NullableBool.True;
                                format.FontItalic = Aspose.Slides.NullableBool.False;
                                format.FontHeight = 24;
                                format.LatinFont = new Aspose.Slides.FontData("Arial");
                                format.FillFormat.SolidFillColor.Color = Color.Blue;
                            }
                        }
                    }

                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
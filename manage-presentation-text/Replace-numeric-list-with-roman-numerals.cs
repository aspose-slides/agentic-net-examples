using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceNumericListWithRoman
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    foreach (ISlide slide in presentation.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            if (shape is IAutoShape)
                            {
                                IAutoShape autoShape = (IAutoShape)shape;
                                if (autoShape.TextFrame != null)
                                {
                                    foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                                    {
                                        string originalText = paragraph.Text;
                                        string trimmed = originalText.TrimStart();

                                        int number = 0;
                                        int idx = 0;
                                        while (idx < trimmed.Length && Char.IsDigit(trimmed[idx]))
                                        {
                                            number = number * 10 + (trimmed[idx] - '0');
                                            idx++;
                                        }

                                        if (number > 0 && idx < trimmed.Length && (trimmed[idx] == '.' || trimmed[idx] == ')'))
                                        {
                                            string roman = IntToRoman(number);
                                            string delimiter = trimmed[idx].ToString();
                                            string rest = trimmed.Substring(idx + 1);
                                            string newTrimmed = roman + delimiter + rest;

                                            int leadingSpacesCount = originalText.Length - trimmed.Length;
                                            string leadingSpaces = new string(' ', leadingSpacesCount);
                                            paragraph.Text = leadingSpaces + newTrimmed;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Converts an integer (1-3999) to a Roman numeral string
        private static string IntToRoman(int number)
        {
            if (number < 1 || number > 3999) return number.ToString();

            string[] thousands = { "", "M", "MM", "MMM" };
            string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            return thousands[number / 1000] +
                   hundreds[(number % 1000) / 100] +
                   tens[(number % 100) / 10] +
                   units[number % 10];
        }
    }
}
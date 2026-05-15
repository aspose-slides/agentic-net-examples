using System;
using System.IO;
using System.Text;

namespace MathMlSaver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the output XML file
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "mathml.xml");

            // Captured MathML content as a byte array (replace with actual data)
            byte[] mathMlBytes = Encoding.UTF8.GetBytes("<math><mi>x</mi></math>");

            try
            {
                // Write the byte array to the file using a FileStream
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(mathMlBytes, 0, mathMlBytes.Length);
                }

                Console.WriteLine("MathML successfully saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle any I/O errors
                Console.WriteLine("Error saving MathML: " + ex.Message);
            }
        }
    }
}
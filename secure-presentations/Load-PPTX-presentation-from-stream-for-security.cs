using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input file path
            string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load presentation from file stream
            FileStream fileStream = null;
            Presentation presentation = null;
            try
            {
                fileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                presentation = new Presentation(fileStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            // Check protection status
            IPresentationInfo presentationInfo = PresentationFactory.Instance.GetPresentationInfo(inputFile);
            bool isWriteProtected = presentationInfo.IsWriteProtected == NullableBool.True;
            bool isWriteProtectedByPassword = false;
            if (isWriteProtected)
            {
                // Replace "writePass" with actual password if needed
                isWriteProtectedByPassword = presentationInfo.CheckWriteProtection("writePass");
            }

            bool isPasswordProtected = presentationInfo.IsPasswordProtected;
            if (isPasswordProtected)
            {
                // Replace "openPass" with actual password if needed
                bool isOpenPasswordCorrect = presentationInfo.CheckPassword("openPass");
            }

            // Remove write protection if present
            if (presentation.ProtectionManager.IsWriteProtected)
            {
                presentation.ProtectionManager.RemoveWriteProtection();
            }

            // Save presentation before exit
            string outputFile = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            try
            {
                presentation.Save(outputFile, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
                // Format not supported
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
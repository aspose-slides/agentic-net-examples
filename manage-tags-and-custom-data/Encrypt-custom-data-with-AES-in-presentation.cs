// -----------------------------------------------------------------------------
// Example: Encrypt custom data with AES in presentation using C#
//
// Description:
// Demonstrates how to encrypt custom data with AES in a PowerPoint presentation 
// using C# and Aspose.Slides for .NET. The example encrypts a plain text string,
// embeds the Base64‑encoded encrypted data into a textbox, then applies password 
// protection to the presentation file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, AES, Encryption, Custom Data, 
// Presentation, Presentation Processing, Office Automation
//
// Use Cases:
// - Encrypt custom data with AES and embed it in a PowerPoint slide.
// - Generate password‑protected PPTX files programmatically.
// - Build C# tools for secure PowerPoint content creation and distribution.
// - Automate PPTX workflows that require data confidentiality.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Data to encrypt
        string plainText = "Sensitive data";
        string password = "StrongPassword123";

        // AES encryption
        byte[] encryptedBytes;
        byte[] iv;
        using (Aes aes = Aes.Create())
        {
            aes.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            aes.GenerateIV();
            iv = aes.IV;
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                encryptedBytes = ms.ToArray();
            }
        }

        // Combine IV and encrypted data
        byte[] combined = new byte[iv.Length + encryptedBytes.Length];
        Buffer.BlockCopy(iv, 0, combined, 0, iv.Length);
        Buffer.BlockCopy(encryptedBytes, 0, combined, iv.Length, encryptedBytes.Length);
        string encryptedBase64 = Convert.ToBase64String(combined);

        // Create presentation
        Presentation presentation = new Presentation();

        // Add a slide
        ISlide slide = presentation.Slides[0];

        // Add a textbox with encrypted data
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
        shape.TextFrame.Text = encryptedBase64;

        // Encrypt presentation
        presentation.ProtectionManager.EncryptDocumentProperties = false;
        presentation.ProtectionManager.Encrypt(password);

        // Save presentation
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "EncryptedPresentation.pptx");
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}

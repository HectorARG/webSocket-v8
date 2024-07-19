using System;
using System.IO;
using WebSocketSharp;
using WebSocketSharp.Server;
using iTextSharp.text.pdf;
using PdfReader = iTextSharp.text.pdf.PdfReader;

namespace WebSocketPrintServer
{
    class PrintBehavior : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            if (e.IsText)
            {
                string base64Pdf = e.Data;
                byte[] pdfBytes = Convert.FromBase64String(base64Pdf);
                string tempFileName = Path.GetTempFileName();
                try
                {
                    using (var reader = new PdfReader(pdfBytes))
                    {
                        using (var printer = new PdfStamper(reader, new FileStream(tempFileName, FileMode.Create)))
                        {
                            printer.Close();
                        }
                    }

                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = @"C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe";
                    process.StartInfo.Arguments = $"/p /h \"{tempFileName}\"";
                    process.Start();
                    process.WaitForExit();

                    System.Threading.Thread.Sleep(3000);
                    System.IO.File.Delete(tempFileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al imprimir: " + ex.Message);
                }
            }
        }


        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Servidor de impresión WebSocket iniciado en el puerto 3035.");
                var wssv = new WebSocketServer("ws://127.0.0.1:3035");
                wssv.AddWebSocketService<PrintBehavior>("/Print");
                wssv.Start();
                Console.ReadKey(true);
                wssv.Stop();
            }
        }
    }
}
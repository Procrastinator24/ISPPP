using ISPPP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
//using Telegram.Bot.Types.InputFiles;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;



namespace ISPPP
{
    [Serializable]

   

    public class ScreenshotToPDF
    {
        public static void SaveScreenToPdf(string botToken, long chatId)
        {
            // Захват скриншота экрана
            var screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (var graphics = Graphics.FromImage(screenshot))
            {
                graphics.CopyFromScreen(Point.Empty, Point.Empty, Screen.PrimaryScreen.Bounds.Size);
            }

            // Сохранение скриншота в PDF
            var pdfPath = Path.Combine(Path.GetTempPath(), $"screenshot_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.pdf");
            using (var document = new iTextSharp.text.Document())
            {
                PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));
                document.Open();
                var image = iTextSharp.text.Image.GetInstance(screenshot, ImageFormat.Png);
                image.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                document.Add(image);
               
                document.Close();
            }

            // botClient = new TelegramBotClient(botToken);
            // Отправка PDF в Telegram
      /* string botToken = "6672794046:AAHWP9MlBIaWIKS-DldQaUdoTKxbNA65H34";

            using (var client = new TelegramBotClient(botToken))
            {     

            {
                //   using (var client = new TelegramBotClient("123456789:ABCDEFGHIJK-lmnopqrstuvwxyz")
                //{ 
                //  string botToken = "6672794046:AAHWP9MlBIaWIKS - DldQaUdoTKxbNA65H34";

                using (var fileStream = new FileStream(pdfPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var inputFile = new InputOnlineFile(fileStream, Path.GetFileName(pdfPath));
                    client.SendDocumentAsync(chatId, inputFile).Wait();
                }
            }
          
            // Удаление временного файла
            File.Delete(pdfPath);*/
        }
    }

    public class Save
    {
        public Workpiece[] workpieces { get; set; }
        public MethodType method { get; set; }
    }
	public static class FileWork
	{
		static public Save Save(string filePath)
		{
			return JsonConvert.DeserializeObject<Save>(File.ReadAllText(filePath));
		}
		static public void Load(Save save, string name)
		{
			string json = JsonConvert.SerializeObject(save);

			File.WriteAllText(name, json);
		}
	}
	public enum MethodType
    {
        Empty = 0,
        Jonson_0 = 10,
        Jonson_1 = 11,
        Jonson_2 = 12,
        Jonson_3 = 13,
        Jonson_4 = 14,
        Jonson_5 = 15,
        Petrov_sum_1 = 21,
        Petrov_sum_2 = 22,
		Petrov_difference = 23,
    }
    static class MethodTypeExtensions
    {
        static public string GetPlanMethodDescriptionByEnumType(MethodType method)
        {
            string methodDescription = "";
            switch (method)
            {
                case MethodType.Empty:
                    {
                        methodDescription = "Исходная последовательность";
                        break;
                    }
                case MethodType.Jonson_0:
                    {
                        methodDescription = "Алгоритм Джонсона";
                        break;
                    }
                case MethodType.Jonson_1:
                    {
                        methodDescription = "Обощение 1";
                        break;
                    }
                case MethodType.Jonson_2:
                    {
                        methodDescription = "Обощение 2";
                        break;
                    }
                case MethodType.Jonson_3:
                    {
                        methodDescription = "Обощение 3";
                        break;
                    }
                case MethodType.Jonson_4:
                    {
                        methodDescription = "Обощение 4";
                        break;
                    }
                case MethodType.Jonson_5:
                    {
                        methodDescription = "Обощение 5";
                        break;
                    }
                case MethodType.Petrov_sum_1:
                    {
                        methodDescription = "Cумма 1";
                        break;
                    }
                case MethodType.Petrov_sum_2:
                    {
                        methodDescription = "Cумма 2";
                        break;
                    }
                case MethodType.Petrov_difference:
                    {
                        methodDescription = "Разность";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return methodDescription;
        }
    }
}

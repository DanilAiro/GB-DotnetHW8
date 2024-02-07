using System.Diagnostics;

namespace HW8;

internal class Program
{
  static void Main(string[] args)
  {
    string arg1 = "txt";
    string arg2 = "привет";
    if (args.Length == 2)
    {
      arg1 = args[0];
      arg2 = args[1];
    }

    FindFile(arg1, arg2);
  }

  static void FindFile(string extension, string text)
  {
    foreach (string path in Directory.GetLogicalDrives())
    FindFile(path, extension, text);
  }

  static void FindFile(string path, string extension, string text)
  {
    try
    {
      foreach (string fileName in Directory.GetFiles(path))
      {
        if (Path.GetExtension(fileName).Replace(".", "") == extension)
        {
          using (FileStream fs = new FileStream(fileName, FileMode.Open))
          {
            using (StreamReader sr = new StreamReader(fs))
            {
              if (sr.ReadToEnd().Contains(text))
              {
                sr.Close();
                fs.Close();
                Process.Start("notepad.exe", fileName);
              }
            }
          }
        }
      }

      foreach (string directoryName in Directory.GetDirectories(path))
      {
          FindFile(directoryName, extension, text);
      }
    } catch
    {
      Console.WriteLine("Проблемы с доступом к жойКазино?!");
    }
  }
}

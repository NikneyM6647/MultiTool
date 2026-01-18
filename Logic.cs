using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace MultiTool
{
    internal class Logic
    {
        public bool devMode = false;

        public Action<string> _log;

        public Logic(Action<string> log = null)
        {
            _log = log ?? (msg => { });
        }

        private void Log(string messege)
        {
            _log?.Invoke(messege);
        }

        public void CreateMainFoldrs()
        {
            string MainPath = @"D:\";
            Directory.CreateDirectory(MainPath);

            string[] FolderNameInDDisk = {
            "Programms", "Games", "GamesT", "Downloads",
            "ImportantThings", "Music", "College"
        };

            string[] FoldersInPrg = {
            "Discord", "Telegram", "Яндекс",
            "Obsidian", "AdobePhotoshop",
            "Zapret", "Radmin", "Magesync", "OBS",
            "DroidCam", "VPN", "VScode", "VSCommunity", "SQLServer"
        };

            string[] FoldersInGames = { "Steam", "Epic" };

            string[] FoldersInDownloads = {
            "png", "gif", "ico", "vid", "exe",
            "doc", "mus", "torr", "gifForSteam"
        };

            string[] FoldersInImpThi = { "OldPhotos", "Paintings" };
            string[] FoldersInCllg = { "CodeFromCllg", "Trainings" };



            for (int i = 0; i < FolderNameInDDisk.Length; i++)
            {
                string fullPath = Path.Combine(MainPath, FolderNameInDDisk[i]);
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                    Log($"Папка {FolderNameInDDisk[i]} создана в {MainPath}");
                }
                else
                {
                    Log($"Папка {FolderNameInDDisk[i]} уже есть");
                }
            }

            CreateSubFolders(MainPath, FolderNameInDDisk[0], FoldersInPrg);
            CreateSubFolders(MainPath, FolderNameInDDisk[1], FoldersInGames);
            CreateSubFolders(MainPath, FolderNameInDDisk[3], FoldersInDownloads);
            CreateSubFolders(MainPath, FolderNameInDDisk[4], FoldersInImpThi);
            CreateSubFolders(MainPath, FolderNameInDDisk[6], FoldersInCllg);
        }

        public void DevCreateMainFoldrs()
        {
            string MainPath = @"D:\testnote";
            Directory.CreateDirectory(MainPath);

            string[] FolderNameInDDisk = {
            "Programms", "Games", "GamesT", "Downloads",
            "ImportantThings", "Music", "College"
        };

            string[] FoldersInPrg = {
            "Discord", "Telegram", "Яндекс",
            "Obsidian", "AdobePhotoshop",
            "Zapret", "Radmin", "Magesync", "OBS",
            "DroidCam", "VPN", "VScode", "VSCommunity", "SQLServer"
        };

            string[] FoldersInGames = { "Steam", "Epic" };

            string[] FoldersInDownloads = {
            "png", "gif", "ico", "vid", "exe",
            "doc", "mus", "torr", "gifForSteam"
        };

            string[] FoldersInImpThi = { "OldPhotos", "Paintings" };
            string[] FoldersInCllg = { "CodeFromCllg", "Trainings" };



            for (int i = 0; i < FolderNameInDDisk.Length; i++)
            {
                string fullPath = Path.Combine(MainPath, FolderNameInDDisk[i]);
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                    Log($"Папка {FolderNameInDDisk[i]} создана в {MainPath}");
                }
                else
                {
                    Log($"Папка {FolderNameInDDisk[i]} уже есть");
                }
            }

            CreateSubFolders(MainPath, FolderNameInDDisk[0], FoldersInPrg);
            CreateSubFolders(MainPath, FolderNameInDDisk[1], FoldersInGames);
            CreateSubFolders(MainPath, FolderNameInDDisk[3], FoldersInDownloads);
            CreateSubFolders(MainPath, FolderNameInDDisk[4], FoldersInImpThi);
            CreateSubFolders(MainPath, FolderNameInDDisk[6], FoldersInCllg);

            CreateTestFiles();
        }

        public void DevMode()
        {
            if (devMode == false)
            {
                devMode = true;
                Log("Режим разработчика включен");
                Process.Start("explorer.exe", @"D:\");
            }
            else
            {
                devMode = false;
                Log("Режим разработчика выключен");
            }
        }

        private void CreateSubFolders(string mainPath, string parent, string[] subFolders)
        {
            foreach (string folder in subFolders)
            {
                string path = Path.Combine(mainPath, parent, folder);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    Log($"Папка {folder} в {parent} создана");
                }
            }
        }

        public void SortDownloads()
        {
            string configPath = "config.json";

            // Если файла нет — создаём по умолчанию
            if (!File.Exists(configPath))
            {
                var defaultConfig = new AppConfig();
                var json = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configPath, json);
            }

            // Читаем настройки из JSON
            var jsonContent = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<AppConfig>(jsonContent) ?? new AppConfig();

            string downloadsPath = config.WatchFolder;

            // Проверка папки
            if (!Directory.Exists(downloadsPath))
            {
                Log("Папка Downloads не найдена!");
                return;
            }

            var files = Directory.GetFiles(downloadsPath);
            if (files.Length == 0)
            {
                Log("Папка пуста — нечего сортировать.");
                return;
            }

            // Используем правила из JSON
            var rules = config.Rules;

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file);
                string fileName = Path.GetFileName(file);
                string targetFolder = null;

                if (string.IsNullOrEmpty(ext)) continue;

                // Особая логика для .gif
                if (ext.Equals(".gif", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        using (var img = System.Drawing.Image.FromFile(file))
                        {
                            targetFolder = img.Width == 750 ? "gifForSteam" : "gif";
                        }
                    }
                    catch
                    {
                        targetFolder = "gif";
                    }
                }
                else if (rules.ContainsKey(ext))
                {
                    targetFolder = rules[ext];
                }

                if (targetFolder != null)
                {
                    string destFolder = Path.Combine(downloadsPath, targetFolder);
                    string destPath = Path.Combine(destFolder, fileName);

                    if (!Directory.Exists(destFolder))
                        Directory.CreateDirectory(destFolder);

                    if (!File.Exists(destPath))
                    {
                        File.Move(file, destPath);
                        Log($"  > {fileName} > {targetFolder}");
                    }
                }
            }

            Log("Сортировка завершена!");
        }

        public void DevSortDownloads()
        {
            string downloadsPath = @"D:\testnote\Downloads";

            if (!Directory.Exists(downloadsPath))
            {
                Log("Папка Downloads не найдена!");
                return;
            }

            var files = Directory.GetFiles(downloadsPath);
            if (files.Length == 0)
            {
                Log("Папка пуста — нечего сортировать.");
                return;
            }

            var rules = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { ".png", "png" }, { ".jpg", "png" }, { ".jpeg", "png" },
            { ".mp4", "vid" }, { ".avi", "vid" }, { ".mkv", "vid" },
            { ".exe", "exe" },
            { ".mp3", "mus" }, { ".wav", "mus" },
            { ".torrent", "torr" },
            { ".ico", "ico" },
            { ".pdf", "doc" }, { ".doc", "doc" }, { ".docx", "doc" }, { ".odt", "doc" },
            { ".zip", "torr" }, { ".rar", "torr" }, { ".jar", "exe" }, {".txt", "doc"}
        };

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file);
                string fileName = Path.GetFileName(file);
                string targetFolder = null;

                if (string.IsNullOrEmpty(ext)) continue;

                if (ext.Equals(".gif", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        using (var img = System.Drawing.Image.FromFile(file))
                        {
                            targetFolder = img.Width == 750 ? "gifForSteam" : "gif";
                        }
                    }
                    catch
                    {
                        targetFolder = "gif";
                    }
                }
                else if (rules.ContainsKey(ext))
                {
                    targetFolder = rules[ext];
                }
                if (targetFolder != null)
                {
                    string destFolder = Path.Combine(downloadsPath, targetFolder);
                    string destPath = Path.Combine(destFolder, fileName);

                    if (!Directory.Exists(destFolder))
                        Directory.CreateDirectory(destFolder);

                    if (!File.Exists(destPath))
                    {
                        File.Move(file, destPath);
                        Log($"  > {fileName} > {targetFolder}");
                    }
                }
            }

            Log("Сортировка завершена!");
        }

        public void DevDeltestFiles()
        {
            string pathik = @"D:\testnote";
            Directory.Delete(pathik, true);
            Log("Тестовая папка удалена");
            return;
        }

        public void CreateTestFiles()
        {
            string downloadsPath = @"D:\testnote\Downloads";

            // Убедимся, что папка существует
            if (!Directory.Exists(downloadsPath))
            {
                Directory.CreateDirectory(downloadsPath);
            }

            // Список тестовых файлов
            string[] testFiles = {
                "image1.png",
                "photo.jpg",
                "animation.gif",
                "video.mp4",
                "document.pdf",
                "archive.zip",
                "program.exe",
                "music.mp3",
                "data.docx",
                "icon.ico",
                "notes.odt",
                "movie.avi",
                "setup.jar"
            };


            foreach (string fileName in testFiles)
            {
                string fullPath = Path.Combine(downloadsPath, fileName);

                // Создаём пустой файл (0 байт)
                File.Create(fullPath).Dispose(); // .Dispose() закрывает файл сразу

                Log($"Создан тестовый файл: {fileName}");

            }
        }
        public void OpenJsonfile()
        {
            string configPath = "config.json";

            // Если файла ещё нет — создаём его
            if (!File.Exists(configPath))
            {
                var defaultConfig = new AppConfig();
                var json = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configPath, json);
            }

            // Открываем файл в Блокноте (или в системном редакторе по умолчанию)
            Process.Start(new ProcessStartInfo
            {
                FileName = configPath,
                UseShellExecute = true // ← обязательно!
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace WindowsTempCleaner
{
    public class DeleteResult { public int DeletedCount; public int FailedCount; }

    public class Cleaner
    {
        private readonly Action<string> _log;

        // Default excludes: extensions or keywords (comma separated in UI)
        private readonly string[] DefaultExcludes = new[] { ".exe", ".dll", ".sys", "pagefile", "hiberfile" };

        public Cleaner(Action<string> log)
        {
            _log = log;
        }

        public List<string> GetCandidateFiles(string[] folders, int olderThanDays, string excludeCsv)
        {
            var excludes = BuildExcludes(excludeCsv);
            var candidates = new List<string>();
            var threshold = DateTime.Now.AddDays(-olderThanDays);

            foreach (var folder in folders.Distinct())
            {
                try
                {
                    if (!Directory.Exists(folder)) continue;
                    var files = Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories);
                    foreach (var f in files)
                    {
                        try
                        {
                            var fi = new FileInfo(f);
                            if (fi.LastWriteTime > threshold) continue;
                            if (IsExcluded(f, excludes)) continue;
                            candidates.Add(f);
                        }
                        catch { }
                    }
                }
                catch (UnauthorizedAccessException) { _log?.Invoke($"Access denied: {folder}"); }
                catch (Exception ex) { _log?.Invoke(ex.Message); }
            }

            return candidates.OrderBy(p => p).ToList();
        }

        private string[] BuildExcludes(string excludeCsv)
        {
            var list = new List<string>(DefaultExcludes);
            if (!string.IsNullOrWhiteSpace(excludeCsv))
            {
                var extra = excludeCsv.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).Where(s => s.Length > 0);
                list.AddRange(extra);
            }
            return list.Select(s => s.ToLowerInvariant()).ToArray();
        }

        private bool IsExcluded(string path, string[] excludes)
        {
            var lower = path.ToLowerInvariant();
            foreach (var ex in excludes)
            {
                if (ex.StartsWith("."))
                {
                    if (Path.GetExtension(lower) == ex) return true;
                }
                else
                {
                    if (lower.Contains(ex)) return true;
                }
            }
            return false;
        }

        public DeleteResult DeleteFiles(List<string> files, bool sendToRecycleBin)
        {
            int deleted = 0, failed = 0;
            foreach (var f in files)
            {
                try
                {
                    if (sendToRecycleBin)
                    {
                        FileSystem.DeleteFile(f, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    }
                    else
                    {
                        File.Delete(f);
                    }
                    deleted++;
                    _log?.Invoke($"Deleted: {f}");
                }
                catch (Exception ex)
                {
                    failed++;
                    _log?.Invoke($"Failed to delete {f} — {ex.Message}");
                }
            }
            return new DeleteResult { DeletedCount = deleted, FailedCount = failed };
        }
    }
}
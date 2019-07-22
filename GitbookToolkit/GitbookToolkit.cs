using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GitbookToolkit
{
    public partial class GitbookToolkit : Form
    {
        private readonly Queue<PowerShellScriptsTask> _taskQueue;

        public GitbookToolkit()
        {
            InitializeComponent();
            _taskQueue = new Queue<PowerShellScriptsTask>();
            CheckDefaultBuildTypes();
        }

        private void CheckDefaultBuildTypes()
        {
            buildTypes.SetItemChecked(0, true);
        }

        private void btnSelectBookRootPath_Click(object sender, EventArgs e)
        {
            var dialogResult = bookFolderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                txtBookRootPath.Text = bookFolderBrowserDialog.SelectedPath;
            }
        }

        private static PowerShellScriptsTaskResult RunPowerShellScripts(PowerShellScriptsTask task, BackgroundWorker worker)
        {
            using (var ps = PowerShell.Create())
            {
                task.Scripts.ForEach(s => ps.AddScript(s));

                // prepare a new collection to store output stream objects
                var outputCollection = new PSDataCollection<PSObject>();

                outputCollection.DataAdded += (sender, args) =>
                {
                    worker.ReportProgress(50, new PowerShellScriptsTaskResult
                    {
                        Message = outputCollection[args.Index].BaseObject.ToString()
                    });
                };

                // begin invoke execution on the pipeline
                // use this overload to specify an output stream buffer
                IAsyncResult result = ps.BeginInvoke<PSObject, PSObject>(null, outputCollection);

                // do something else until execution has completed.
                // this could be sleep/wait, or perhaps some other work
                while (result.IsCompleted == false)
                {
                }

                return new PowerShellScriptsTaskResult
                {
                    Message = task.EndMessage
                };
            }
        }

        private void DisableAllButtons()
        {
            btnSelectBookRootPath.Enabled = false;
            btnInstall.Enabled = false;
            btnBuild.Enabled = false;
        }

        private void EnableAllButtons()
        {
            btnSelectBookRootPath.Enabled = true;
            btnInstall.Enabled = true;
            btnBuild.Enabled = true;
        }

        private void AppendLog(string log)
        {
            psLog.Text += $"{log}\r\n";
            psLog.Select(psLog.TextLength -1, 0);
            psLog.ScrollToCaret();
        }

        public static string GetDefaultBrowserPath()
        {
            string urlAssociation = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http";
            string browserPathKey = @"$BROWSER$\shell\open\command";

            RegistryKey userChoiceKey = null;
            string browserPath = "";

            try
            {
                //Read default browser path from userChoiceLKey
                userChoiceKey = Registry.CurrentUser.OpenSubKey(urlAssociation + @"\UserChoice", false);

                //If user choice was not found, try machine default
                if (userChoiceKey == null)
                {
                    //Read default browser path from Win XP registry key
                    var browserKey = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);

                    //If browser path wasn’t found, try Win Vista (and newer) registry key
                    if (browserKey == null)
                    {
                        browserKey =
                            Registry.CurrentUser.OpenSubKey(
                                urlAssociation, false);
                    }
                    var path = CleanifyBrowserPath(browserKey.GetValue(null) as string);
                    browserKey.Close();
                    return path;
                }
                else
                {
                    // user defined browser choice was found
                    string progId = (userChoiceKey.GetValue("ProgId").ToString());
                    userChoiceKey.Close();

                    // now look up the path of the executable
                    string concreteBrowserKey = browserPathKey.Replace("$BROWSER$", progId);
                    var kp = Registry.ClassesRoot.OpenSubKey(concreteBrowserKey, false);
                    browserPath = CleanifyBrowserPath(kp.GetValue(null) as string);
                    kp.Close();
                    return browserPath;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private static string CleanifyBrowserPath(string p)
        {
            string[] url = p.Split('"');
            string clean = url[1];
            return clean;
        }

        private string GetBaseScript()
        {
            return $"Set-Location -Path \"{txtBookRootPath.Text}\"";
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            _taskQueue.Enqueue(new PowerShellScriptsTask
            {
                StartMessage = "正在初始化Book...",
                Scripts = new List<string>
                {
                    GetBaseScript(),
                    "gitbook install"
                },
                EndMessage = "初始化完成..."
            });
            StartPsBackgroundWorker();
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            for (var index = 0; index < buildTypes.Items.Count; index++)
            {
                var itemChecked = buildTypes.GetItemChecked(index);

                if (itemChecked)
                {
                    var scripts = new List<string>
                    {
                        GetBaseScript(),
                    };

                    var itemType = buildTypes.Items[index].ToString();

                    if (itemType == "HTML")
                    {
                        scripts.Add("gitbook build");
                    }
                    else
                    {
                        scripts.Add($"gitbook {itemType.ToLower()}");
                    }

                    _taskQueue.Enqueue(new PowerShellScriptsTask
                    {
                        StartMessage = $"正在生成{itemType}文件...",
                        Scripts = scripts,
                        EndMessage = "执行完毕..."
                    });
                }
            }

            StartPsBackgroundWorker();
        }

        private void StartPsBackgroundWorker()
        {
            if (!psBackgroundWorker.IsBusy && _taskQueue.Count > 0)
            {
                DisableAllButtons();
                psBackgroundWorker.RunWorkerAsync(_taskQueue.Dequeue());
            }
            else
            {
                EnableAllButtons();
            }
        }

        private void psBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var task = e.Argument as PowerShellScriptsTask;

            worker?.ReportProgress(0, new PowerShellScriptsTaskResult
            {
                Message = task?.StartMessage
            });

            var result = RunPowerShellScripts(task, worker);

            worker?.ReportProgress(100, result);
        }

        private void psBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!(e.UserState is PowerShellScriptsTaskResult taskResult))
            {
                return;
            }

            if (!displayFullLogToggle.Checked && e.ProgressPercentage == 50)
            {
                return;
            }

            AppendLog(taskResult.Message);
        }

        private void psBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StartPsBackgroundWorker();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            AppendLog("预览服务开其中...");
            AppendLog($"当新打开的窗口显示\"Serving book on http://localhost:4000\"时，点击 打开预览");

            var psPath = @"c:\windows\system32\WindowsPowerShell\v1.0\powershell.exe";
            var previewCommand = $"-Command {GetBaseScript()}; gitbook serve;";
            Process.Start(psPath, previewCommand);
        }

        private void btnOpenPreview_Click(object sender, EventArgs e)
        {
            Process.Start(GetDefaultBrowserPath(), "http://localhost:4000");
        }
    }
}

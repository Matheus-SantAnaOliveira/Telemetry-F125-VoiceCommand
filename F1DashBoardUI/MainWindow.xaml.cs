using Microsoft.Web.WebView2.Core;
using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Text.Json;
using System.Windows;
using WindowsDisplayAPI;

namespace F1DashboardUI
{
    public partial class MainWindow : Window
    {
        private const string PipeName = "F1DashboardPipe"; 
        private bool _isRunning = true;
        private const string BlankPage = "about:blank";
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MoveToMonitor(1); 
            WindowState = WindowState.Maximized;

            await WebView.EnsureCoreWebView2Async();
            WebView.CoreWebView2.Settings.AreDevToolsEnabled = false;
            WebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            WebView.CoreWebView2.Settings.IsZoomControlEnabled = false;
            _ = Task.Run(PipeServerLoop);
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            _isRunning = false;
        }

        private async Task PipeServerLoop()
        {
            while (_isRunning)
            {
                try
                {
                    using var server = new NamedPipeServerStream(PipeName, PipeDirection.In, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
                    await server.WaitForConnectionAsync();

                    if (!_isRunning) break;

                    using var reader = new StreamReader(server, Encoding.UTF8);
                    string? json = await reader.ReadToEndAsync();

                    if (!string.IsNullOrEmpty(json))
                    {
                        try
                        {
                            var dto = JsonSerializer.Deserialize<ShowDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                            if (dto != null && Uri.IsWellFormedUriString(dto.Url, UriKind.Absolute))
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    MoveToMonitor(dto.Monitor);
                                    WebView.CoreWebView2.Navigate(dto.Url);
                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Erro ao processar comando: " + ex.Message);
                        }
                    }

                    server.Disconnect();
                }
                catch (Exception ex)
                {
                    if (_isRunning)
                        Console.WriteLine("Erro no pipe server: " + ex.Message);
                }
            }
        }

        private void MoveToMonitor(int monitorIndex)
        {
            var displays = Display.GetDisplays().ToList();
            if (!displays.Any()) return;

            if (monitorIndex < 0 || monitorIndex >= displays.Count)
                monitorIndex = 0;

            var target = displays[monitorIndex];
            var pos = target.CurrentSetting.Position;
            var res = target.CurrentSetting.Resolution;

            Left = pos.X;
            Top = pos.Y;
            Width = res.Width;
            Height = res.Height;

            WindowStyle = WindowStyle.None;        
            WindowState = WindowState.Normal;
            WindowState = WindowState.Maximized;
            Topmost = false;
        }

        private class ShowDto
        {
            public string? Url { get; set; }
            public int Monitor { get; set; } = 1;
            public string? Action { get; set; }
        }
    }
}
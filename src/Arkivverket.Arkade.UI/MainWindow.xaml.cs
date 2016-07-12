﻿using Arkivverket.Arkade.UI.Util;
using Arkivverket.Arkade.Core;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Serilog;
using System.IO;

namespace Arkivverket.Arkade.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = Properties.Resources.General_WindowTitle;
            progressBar.Value = 0;

            // Init logging
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.ColoredConsole(outputTemplate: "{Timestamp:yyyy-MM-ddTHH:mm:ss.fff} {SourceContext} [{Level}] {Message}{NewLine}{Exception}")
                            .CreateLogger();

        }



        private void loadArchive_Click(object sender, RoutedEventArgs e)
        {
            string filename = new FileFolderDialogs().ChooseFile(Properties.Resources.FileSelectionWindowNameArchive,
                                                                 Properties.Resources.FileSelectionDefaultTar, 
                                                                 Properties.Resources.FileSelectionFilterTar);

            textBoxLogMessages.AppendText(filename);
        }

        private async void testButton_Click(object sender, RoutedEventArgs e)
        {

            //construct Progress<T>, passing ReportProgress as the Action<T> 
            var progressIndicator = new Progress<int>(ReportProgress);
            //call async method 
            int counts = await new BigSlowAsync().DoSomethingRatherSlow(progressIndicator);

        }

        void ReportProgress(int value)
        {
            progressBar.Value++;
            textBoxLogMessages.AppendText("The big slow test is updating\n");
            Log.Information($"Big and slow {progressBar.Value}");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.HumanInterfaceDevice;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using UwpDiagnostics.Collectors;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpDiagnostics
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            output.Text = "Processing...";
            var xOutput = new StringOutputWriter();

            {
                await DeviceInformationCollector.Execute(xOutput);
            }

            output.Text = xOutput.ToString();
        }

        private async void SendToServer_Click(object sender, RoutedEventArgs e)
        {
            var xClient = new HttpClient();
            await xClient.PutAsync(new Uri("http://laptop-matthijs:60864/Home/Put"), new HttpStringContent(output.Text));

        }
    }
}

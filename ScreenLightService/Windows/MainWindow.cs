using System;
using System.Windows.Forms;
using ScreenLightService.Models;
using ScreenLightService.Classes;
using ScreenLightService.Windows;

namespace ScreenLightService
{
    public partial class MainWindow : Form
    {
        ScreenCapturer _screenCapturer;
        ImageManipulator _im;

        public MainWindow()
        {
            InitializeComponent();
            _screenCapturer = new ScreenCapturer();
            _im = new ImageManipulator();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                this.Hide();
            }
            else if(WindowState == FormWindowState.Normal 
                || WindowState == FormWindowState.Maximized)
            {
                notifyIcon.Visible = false;
            }
        }


        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _screenCapturer.Stop();
            this.Close();
        }

        private void LEDSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LedPositionWindow().Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PSMP_Kursovik
{
    public static class GUIController
    {
        private static Form1 _instance;

        public static void setForm(Form1 f)
        {
            _instance = f;
        }

        public static void updateProgressBar(int incValue)
        {
            ProgressBar PB = (ProgressBar)_instance.Controls["progressBar1"];
            PB.BeginInvoke(new MethodInvoker(() => PB.Increment(incValue)));
        }

        public static void updateSuccessLabel(int successCount)
        {
            Label L = (Label)_instance.Controls["successLabel"];
            L.BeginInvoke(new MethodInvoker(() => L.Text = successCount.ToString()));
        }

        public static void updateAliveThreadsLabel(int aliveThreadsCount)
        {
            Label L = (Label)_instance.Controls["aliveThreadsLabel"];
            L.BeginInvoke(new MethodInvoker(() => L.Text = aliveThreadsCount.ToString()));
        }

        public static void updateFailsLabel(int failCount)
        {
            Label L = (Label)_instance.Controls["failLabel"];
            L.BeginInvoke(new MethodInvoker(() => L.Text = failCount.ToString()));
        }

        public static void appendLog(string threadId, string text)
        {
            RichTextBox RTB = (RichTextBox)_instance.Controls["richTextBox1"];
            RTB.BeginInvoke(new MethodInvoker(() => RTB.AppendText(string.Format("Thread #{0}: {1}" + Environment.NewLine, threadId, text))));
        }

        public static void startButtonEnabled(bool enabled)
        {
            Button B = (Button)_instance.Controls["button1"];
            B.BeginInvoke(new MethodInvoker(() => B.Enabled = enabled));
        }

        public static void stopButtonEnabled(bool enabled)
        {
            Button B = (Button)_instance.Controls["button2"];
            B.BeginInvoke(new MethodInvoker(() => B.Enabled = enabled));
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.Collections;

namespace Speech_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        bool Awake = true;

        private void button1_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer sSynth = new SpeechSynthesizer();
            PromptBuilder pBuilder = new PromptBuilder();
            SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine();

            Choices sList = new Choices();
            sList.Add(new string[] { "Jarvis Hello" });
            sList.Add(new string[] { "Jarvis Chrome" });
            sList.Add(new string[] { "Jarvis Facebook" });
            sList.Add(new string[] { "Jarvis Launch Go" });
            sList.Add(new string[] { "Jarvis Launch Rim World" });
            sList.Add(new string[] { "Jarvis Launch Rust" });
            sList.Add(new string[] { "Jarvis Launch Sins" });
            sList.Add(new string[] { "Jarvis Launch K S P" });
            sList.Add(new string[] { "Jarvis Launch Skype" });
            sList.Add(new string[] { "Jarvis Launch Unity" });
            sList.Add(new string[] { "Jarvis Wake Up" });
            sList.Add(new string[] { "Jarvis Go To Sleep" });
            sList.Add(new string[] { "Jarvis Close Applications" });
            sList.Add(new string[] { "Jarvis Exit" });
            Grammar gr = new Grammar(new GrammarBuilder(sList));
            try
            {
                sRecognize.RequestRecognizerUpdate();
                sRecognize.LoadGrammar(gr);
                sRecognize.SpeechRecognized += sRecognize_SpeechRecognized;
                sRecognize.SetInputToDefaultAudioDevice();
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);
                sRecognize.Recognize();
            }

            catch
            {
                return;
            }
        }
        private void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "Jarvis Wake Up")
            {
                Awake = true;
            }

            if (e.Result.Text == "Jarvis Go To Sleep")
            {
                Awake = false;
            }

            if (Awake == true)
            {
                if (e.Result.Text == "Jarvis Hello")
                {
                    MessageBox.Show("Hello, I am Jarvis version 1.0");
                }
                if (e.Result.Text == "Jarvis Chrome")
                {
                    LaunchChrome();
                }
                if (e.Result.Text == "Jarvis Facebook")
                {
                    LaunchFacebook();
                }
                if (e.Result.Text == "Jarvis Launch Go")
                {
                    LaunchCSGO();
                }
                if (e.Result.Text == "Jarvis Launch Rim World")
                {
                    LaunchRim();
                }
                if (e.Result.Text == "Jarvis Launch Rust")
                {
                    LaunchRust();
                }
                if (e.Result.Text == "Jarvis Launch Sins")
                {
                    LaunchSins();
                }
                if (e.Result.Text == "Jarvis Launch K S P")
                {
                    LaunchKSP();
                }
                if (e.Result.Text == "Jarvis Launch Skype")
                {
                    LaunchSkype();
                }
                if (e.Result.Text == "Jarvis Launch Unity")
                {
                    LaunchUnity();
                }
                if (e.Result.Text == "Jarvis Close Applications")
                {
                    CloseApplication();
                }
                if (e.Result.Text == "Jarvis Exit")
                {
                    Environment.Exit(0);
                }
            }
        }

        private void LaunchChrome()
        {
            Process.Start("chrome.exe");
        }

        private void LaunchFacebook()
        {
            Process.Start("chrome.exe", "www.facebook.com");
        }
        private void LaunchCSGO()
        {
            Process.Start("steam://rungameid/730");
        }
        private void LaunchRim()
        {
            Process.Start("RimWorld.exe");
        }
        private void LaunchRust()
        {
            Process.Start("steam://rungameid/252490");
        }
        private void LaunchSins()
        {
            Process.Start("steam://rungameid/204880");
        }
        private void LaunchKSP()
        {
            Process.Start("steam://rungameid/220200");
        }
        private void LaunchSkype()
        {
            Process.Start("Skype.exe");
        }
        private void LaunchUnity()
        {
            Process.Start("C:\\Program Files\\Unity\\Editor\\Unity.exe");
        }

        private void CloseApplication()
        {
            ProcessClass myProcess = new ProcessClass();
            myProcess.CloseProcesses();
            Console.Write(myProcess.ToString());

        }
    }
}
    

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
using System.Threading;

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
            sList.Add(new string[] { "Nisp Hello" });
            sList.Add(new string[] { "Nisp Launch Chrome" });
            sList.Add(new string[] { "Nisp Facebook" });
            sList.Add(new string[] { "Nisp Launch Go" });
            sList.Add(new string[] { "Nisp Launch Rim World" });
            sList.Add(new string[] { "Nisp Launch Rust" });
            sList.Add(new string[] { "Nisp Launch Sins" });
            sList.Add(new string[] { "Nisp Launch K S P" });
            sList.Add(new string[] { "Nisp Launch Skype" });
            sList.Add(new string[] { "Nisp Launch Unity" });
            sList.Add(new string[] { "Nisp Wake Up" });
            sList.Add(new string[] { "That will be all" });
            sList.Add(new string[] { "Nisp Close Applications" });
            sList.Add(new string[] { "Nisp Tell A Joke" });
            sList.Add(new string[] { "Nisp Exit" });
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

            // Initialize a new instance of the SpeechSynthesizer.
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the audio output. 
            synth.SetOutputToDefaultAudioDevice();

            if (e.Result.Text == "Nisp Wake Up")
            {
                Awake = true;
                // Speak a string.
                synth.Speak("Welcome Back Kmannder");
            }

            if (e.Result.Text == "That will be all for now")
            {
                // Speak a string.
                synth.Speak("I'll be here Sir");
                Awake = false;
            }

            if (Awake == true)
            {
                if (e.Result.Text == "Nisp Hello")
                {
                    // Speak a string.
                    synth.Speak("Hello, I am Nisp version 1.0");
                }
                if (e.Result.Text == "Nisp Launch Chrome")
                {

                    // Speak a string.
                    synth.Speak("Launching Google Chrome");
                    LaunchChrome();
 //                   int milliseconds = 2000;
   //                 Thread.Sleep(milliseconds);
     //               SendKeys.Send("Bing");
       //             SendKeys.Send("{ENTER}");
                }
                if (e.Result.Text == "Nisp Facebook")
                {
                    LaunchFacebook();
                    // Speak a string.
                    synth.Speak("Opening your Facebook");
                }
                if (e.Result.Text == "Nisp Launch Go")
                {
                    // Speak a string.
                    synth.Speak("Launching Counter Strike: Global Offensive");
                    LaunchCSGO();
                }
/*needs some work*/                if (e.Result.Text == "Nisp Launch Rim World")
                {
                    // Speak a string.
                    synth.Speak("Launching Rim World");
                    LaunchRim();
                }
                if (e.Result.Text == "Nisp Launch Rust")
                {
                    // Speak a string.
                    synth.Speak("Launching Rust");
                    LaunchRust();
                }
                if (e.Result.Text == "Nisp Launch Sins")
                {
                    // Speak a string.
                    synth.Speak("Sins Of Solar Empire");
                    LaunchSins();
                }
                if (e.Result.Text == "Nisp Launch K S P")
                {
                    LaunchKSP();
                    // Speak a string.
                    synth.Speak("Launching Kerbal Space Program");
                }
                if (e.Result.Text == "Nisp Launch Skype")
                {
                    LaunchSkype();
                    // Speak a string.
                    synth.Speak("Launching Skype");
                }
                if (e.Result.Text == "Nisp Launch Unity")
                {
                    LaunchUnity();
                    // Speak a string.
                    synth.Speak("Launching Unity");
                }
/*needs some work*/                if (e.Result.Text == "Nisp Close Applications")
                {
                    CloseApplication();
                    // Speak a string.
                    synth.Speak("Closing Application");
                }
                if (e.Result.Text == "Nisp Tell A Joke")
                {
                    // Speak a string.
                    synth.Speak("Your Face, Ha Ha Ha Ha Ha Ha Ha Ha Ha ");
                }
                if (e.Result.Text == "Nisp Exit")
                {
                    // Speak a string.
                    synth.Speak("Nisp shutting down, Good Bye sir");
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
    

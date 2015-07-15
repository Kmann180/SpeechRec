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
        bool JokeMade;
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
            sList.Add(new string[] { "Jack Hello" });
            sList.Add(new string[] { "Jack Launch Chrome" });
            sList.Add(new string[] { "Jack Go To My Facebook" });
            sList.Add(new string[] { "Jack Launch Go" });
            sList.Add(new string[] { "Jack Launch Rim World" });
            sList.Add(new string[] { "Jack Launch Rust" });
            sList.Add(new string[] { "Jack Launch Sins" });
            sList.Add(new string[] { "Jack Launch K S P" });
            sList.Add(new string[] { "Jack Launch Skype" });
            sList.Add(new string[] { "Jack Launch Unity" });
            sList.Add(new string[] { "Jack Wake Up" });
            sList.Add(new string[] { "That will be all for now" });
            sList.Add(new string[] { "Jack Close Window" });
            sList.Add(new string[] { "Jack Save Progress" });
            sList.Add(new string[] { "Alt Tab" });
            sList.Add(new string[] { "Jack Tell A Joke" });
            sList.Add(new string[] { "That Was A Good One Jack" });
            sList.Add(new string[] { "Jack You Are Funny" });
            sList.Add(new string[] { "Jack You're A Little Bitch" });
            sList.Add(new string[] { "Jack Lock" });
            sList.Add(new string[] { "Jack Exit" });
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

            if (e.Result.Text == "Jack Wake Up")
            {
                Awake = true;
                // Speak a string.
                synth.Speak("Welcome Back");
            }

            if (e.Result.Text == "That will be all for now")
            {
                // Speak a string.
                synth.Speak("I'll be here Sir");
                Awake = false;
            }

            if (Awake == true)
            {
                if (e.Result.Text == "Jack Hello")
                {
                    // Speak a string.
                    synth.Speak("Hello sir, how are you doing, I am Jak Version 1.0");
                    AllBoolFalse();
                }
                if (e.Result.Text == "Jack Launch Chrome")
                {

                    // Speak a string.
                    synth.Speak("Launching Google Chrome");
                    LaunchChrome();
                    AllBoolFalse();
 //                   int milliseconds = 2000;
   //                 Thread.Sleep(milliseconds);
     //               SendKeys.Send("Bing");
       //             SendKeys.Send("{ENTER}");
                }
                if (e.Result.Text == "Jack Go To My Facebook")
                {
                    LaunchFacebook();
                    // Speak a string.
                    synth.Speak("Opening your Facebook");
                    AllBoolFalse();
                }
                if (e.Result.Text == "Jack Launch Go")
                {
                    // Speak a string.
                    synth.Speak("Launching Counter Strike: Global Offensive");
                    LaunchCSGO();
                    AllBoolFalse();
                }
/*needs some work*/                if (e.Result.Text == "Jack Launch Rim World")
                {
                    // Speak a string.
                    synth.Speak("Launching Rim World");
                    LaunchRim();
                    AllBoolFalse();
                }
                if (e.Result.Text == "Jack Launch Rust")
                {
                    // Speak a string.
                    synth.Speak("Launching Rust");
                    LaunchRust();
                    AllBoolFalse();
                }
                if (e.Result.Text == "Jack Launch Sins")
                {
                    // Speak a string.
                    synth.Speak("Sins Of Solar Empire");
                    LaunchSins();
                    AllBoolFalse();
                }
                if (e.Result.Text == "Jack Launch K S P")
                {
                    LaunchKSP();
                    // Speak a string.
                    synth.Speak("Launching Kerbal Space Program");
                    AllBoolFalse();
                }
                if (e.Result.Text == "Jack Launch Skype")
                {
                    LaunchSkype();
                    // Speak a string.
                    synth.Speak("Launching Skype");
                    AllBoolFalse();
                }
                if (e.Result.Text == "Jack Launch Unity")
                {
                    LaunchUnity();
                    // Speak a string.
                    synth.Speak("Launching Unity");
                    AllBoolFalse();
                }
                if (e.Result.Text == "Jack Save Progress")
                {
                    Save();
                    // Speak a string.
                    synth.Speak("Saving");
                    AllBoolFalse();
                }
                if (e.Result.Text == "Alt Tab")
                {
                    AltTab();
                    synth.Speak("Switching windows");
                    AllBoolFalse();
                }
                if (e.Result.Text == "Jack Close Window")
                {
                    CloseApplication();
                    // Speak a string.
                    synth.Speak("Closing Application");
                    AllBoolFalse();
                }
                if (e.Result.Text == "Jack Tell A Joke")
                {
                    // Speak a string.
                    synth.Speak("Your Face, Ha Ha Ha Ha Ha Ha Ha Ha Ha ");
                    AllBoolFalse(JokeMade);
                }
                if (e.Result.Text == "Jack Lock")
                {
                    // Speak a string.
                    LockComputer();
                    AllBoolFalse();
                }
                if (e.Result.Text == "Jack Exit")
                {
                    // Speak a string.
                    synth.Speak("Jack shutting down, Good Bye sir");
                    Environment.Exit(0);
                }
                if (e.Result.Text == "Jack You're A Little Bitch")
                {
                    // Speak a string.
                    synth.Speak("Fuck Off asshole");
                    Environment.Exit(0);
                }



                if (JokeMade == true)
                {
                    if (e.Result.Text == "Jack You Are Funnyr")
                    {
                        // Speak a string.
                        synth.Speak("Did you want to hear another?");
                        AllBoolFalse();
                    }
                    if (e.Result.Text == "That Was A Good One Jack")
                    {
                        // Speak a string.
                        synth.Speak("Ill be here all night");
                        AllBoolFalse();
                    }
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
            SendKeys.SendWait("%{F4}");
/*            ProcessClass myProcess = new ProcessClass();
            myProcess.CloseProcesses();
            Console.Write(myProcess.ToString());
            */
        }
        private void Save()
        {
            SendKeys.SendWait("^s");
        }
        private void AltTab()
        {
            SendKeys.Send("%{TAB}");
        }
        private void LockComputer()
        {
            System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
        }

        private void AllBoolFalse(bool exception)
        {
            JokeMade = false;
            exception = true;
        }
        private void AllBoolFalse()
        {
            JokeMade = false;
        }
    }
}
    

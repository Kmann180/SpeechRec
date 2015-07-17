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
        bool EnterNumber1;
        int Number1 = -1;
        bool EnterNumber2;
        int Number2 = -1;
        bool EnterOperator; 
        float MathAnswer;

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

            Choices NumbersCh = new Choices();
            for (int i = -999; i < 1000; i++)
            {
                NumbersCh.Add(i.ToString());
            }
            NumbersCh.Add("Times");
            NumbersCh.Add("Multiply");
            NumbersCh.Add("Divided");
            NumbersCh.Add("Divide");
            NumbersCh.Add("Plus");
            NumbersCh.Add("Minus");
            NumbersCh.Add("Add");
            NumbersCh.Add("Subtract");
            NumbersCh.Add("Power");
            NumbersCh.Add("Left Over");
            Choices OperatorCh = new Choices();
            Grammar MathGr = new Grammar(new GrammarBuilder(NumbersCh));
            

            Choices MainCh = new Choices();
            MainCh.Add(new string[] { "Jack Hello" });
            MainCh.Add(new string[] { "Jack Launch Chrome" });
            MainCh.Add(new string[] { "Jack Go To My Facebook" });
            MainCh.Add(new string[] { "Jack Launch Go" });
            MainCh.Add(new string[] { "Jack Launch Rim World" });
            MainCh.Add(new string[] { "Jack Launch Rust" });
            MainCh.Add(new string[] { "Jack Launch Sins" });
            MainCh.Add(new string[] { "Jack Launch K S P" });
            MainCh.Add(new string[] { "Jack Launch Skype" });
            MainCh.Add(new string[] { "Jack Launch Unity" });
            MainCh.Add(new string[] { "Jack Wake Up" });
            MainCh.Add(new string[] { "That will be all for now" });
            MainCh.Add(new string[] { "Jack Close Window" });
            MainCh.Add(new string[] { "Jack Save Progress" });
            MainCh.Add(new string[] { "Alt Tab" });
            MainCh.Add(new string[] { "Jack Tell A Joke" });
            MainCh.Add(new string[] { "That Was A Good One Jack" });
            MainCh.Add(new string[] { "Jack You Are Funny" });
            MainCh.Add(new string[] { "Enter My Number" });
            MainCh.Add(new string[] { "What Are My Numbers?" });
            MainCh.Add(new string[] { "What Is My Answer?" });
            MainCh.Add(new string[] { "Jack Lock" });
            MainCh.Add(new string[] { "Jack Exit" });
            Grammar MainGr = new Grammar(new GrammarBuilder(MainCh));
            try
            {
                sRecognize.RequestRecognizerUpdate();
                sRecognize.LoadGrammar(MainGr);
                sRecognize.LoadGrammar(MathGr);
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
                    synth.Speak("Hello you are running Version 1.0 of Jak");
                    AllBoolFalse();
                }
                if (e.Result.Text == "Jack Exit")
                {
                    // Speak a string.
                    synth.Speak("Jack shutting down");
                    Environment.Exit(0);
                }
//Math (-999 to 999)
                if (e.Result.Text == "Enter My Number")
                {
                    EnterNumber1 = true;
                   // Speak a string.
                    synth.Speak("Enter your number now");
                   // AllBoolFalse();
                }
                if (e.Result.Text == "What Are My Numbers?")
                {
                    synth.Speak("Your first number is " + Number1.ToString() + ", your second number is " + Number2.ToString());
                }
                if (e.Result.Text == "What Is My Answer?")
                {
                    synth.Speak(MathAnswer.ToString());
                }
                if (EnterNumber2 == true)
                {
                    for (int i = -999; i < 1000; i++)
                    {
                        if (e.Result.Text == i.ToString())
                        {
                            Number2 = i;
                            EnterNumber2 = false;
                            EnterOperator = true;
                            synth.Speak(i.ToString());
                            synth.Speak("is your second number. Enter your operator now.");
                        }
                    }
                }
                if (EnterNumber1 == true)
                {
                    for (int i = -999; i < 1000; i++)
                    {
                        if (e.Result.Text == i.ToString())
                        {
                            Number1 = i;
                            EnterNumber1 = false;
                            synth.Speak(i.ToString());
                            synth.Speak("is your first number. Enter your second number now.");
                            EnterNumber2 = true;
                        }
                    }
                }
                if (EnterOperator == true)
                {
                    if (e.Result.Text == "Add" || e.Result.Text == "Plus")
                    {
                        MathAnswer = Number1 + Number2;
                        synth.Speak("Your answer is " + MathAnswer);
                        EnterOperator = false;
                    }
                    if (e.Result.Text == "Subtract" || e.Result.Text == "Minus")
                    {
                        MathAnswer = Number1 - Number2;
                        synth.Speak("Your answer is " + MathAnswer);
                        EnterOperator = false;
                    }
                    if (e.Result.Text == "Multiply" || e.Result.Text == "Times")
                    {
                        MathAnswer = Number1 * Number2;
                        synth.Speak("Your answer is " + MathAnswer);
                        EnterOperator = false;
                    }
                    if (e.Result.Text == "Divide" || e.Result.Text == "Divided")
                    {
                        MathAnswer = Number1 / Number2;
                        synth.Speak("Your answer is " + MathAnswer);
                        EnterOperator = false;
                    }
                    if (e.Result.Text == "Leftover")
                    {
                        MathAnswer = Number1 % Number2;
                        synth.Speak("Your answer is " + MathAnswer);
                        EnterOperator = false;
                    }
                    if (e.Result.Text == "Power")
                    {
                        MathAnswer = Number1;
                        for (int i = 0; i < Number2; i++)
                        {
                            MathAnswer *= Number1;
                        }
                        synth.Speak("Your answer is " + MathAnswer);
                        EnterOperator = false;
                    }
                    
                }
//Launching Stuff
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
//Controlling Windows
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
                if (e.Result.Text == "Jack Lock")
                {
                    // Speak a string.
                    LockComputer();
                    AllBoolFalse();
                }
                
//JAK is funny
                if (e.Result.Text == "Jack Tell A Joke")
                {
                    // Speak a string.
                    synth.Speak("Your Face, Ha Ha Ha Ha Ha Ha Ha Ha Ha ");
                    AllBoolFalse(JokeMade);
                }
                if (JokeMade == true)
                {
                    if (e.Result.Text == "Jack You Are Funny")
                    {
                        // Speak a string.
                        synth.Speak("Well Duh You Made Me");
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
    

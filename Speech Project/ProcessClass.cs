using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.Collections;
using System.Security.Permissions;


namespace Speech_Project
{
    [MonitoringDescriptionAttribute("ProcessDesc")]
    [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
    [HostProtectionAttribute(SecurityAction.LinkDemand, SharedState = true, Synchronization = true,
        ExternalProcessMgmt = true, SelfAffectingProcessMgmt = true)]
    [PermissionSetAttribute(SecurityAction.InheritanceDemand, Name = "FullTrust")]
    public class ProcessClass : Component
    {
        public void CloseProcesses(/*string ProcName*/)
        {
            // Get all processes running on the local computer.
            Process[] localAll = Process.GetProcessesByName("chrome.exe");
            foreach (Process A in localAll)
            {
                A.Kill();
            }
        }
    }
}

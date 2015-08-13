/*
 * Created by Ranorex
 * User: Rachelle Tanase
 * Date: 8/12/2015
 * Time: 11:54 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace RachelleTanaseTestSuite
{
    /// <summary>
    /// Description of OpenBrowser.
    /// </summary>
    [TestModule("B4E2E99C-99DF-4842-A852-E581DA348D80", ModuleType.UserCode, 1)]
    public class OpenBrowser : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenBrowser()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            //Start a web browser
            Host.Local.OpenBrowser("https://login.salesforce.com/", "ie");
            Delay.Milliseconds(10000); //Wait for the next page to load
        }
    }
}

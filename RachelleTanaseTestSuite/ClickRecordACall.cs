/*
 * Created by Ranorex
 * User: wc_ka
 * Date: 8/12/2015
 * Time: 12:05 PM
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
    /// Description of ClickRecordACall.
    /// </summary>
    [TestModule("FC0BA825-2557-4505-9EFB-A59EA1E85D9B", ModuleType.UserCode, 1)]
    public class ClickRecordACall : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ClickRecordACall()
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
            
            //Click "Record a Call" button
            InputTag recordCallButton = Ranorex.Host.Local.FindSingle<InputTag>("/dom[@domain='na12.salesforce.com']//td[#'topButtonRow']/input[@title='Record a Call']");
            recordCallButton.Focus(); recordCallButton.MoveTo(); Delay.Milliseconds(100); recordCallButton.Click();
            Delay.Milliseconds(40000); //Wait for next page to load
        }
    }
}

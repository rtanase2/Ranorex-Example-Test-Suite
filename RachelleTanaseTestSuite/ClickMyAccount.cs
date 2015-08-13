/*
 * Created by Ranorex
 * User: Rachelle Tanase
 * Date: 8/12/2015
 * Time: 11:59 AM
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
    /// Description of ClickMyAccount.
    /// </summary>
    [TestModule("AF470558-2422-4DD0-8DC7-2339DB39D1F3", ModuleType.UserCode, 1)]
    public class ClickMyAccount : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ClickMyAccount()
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
            
        	//Click the "My Account" button
            ATag myScheduleButton = Ranorex.Host.Local.FindSingle<ATag>("/dom[@domain='na12.salesforce.com']//li[#'01rU0000000YP6A_Tab']/a[@innertext='My Accounts']");
            myScheduleButton.MoveTo(); Delay.Milliseconds(100); myScheduleButton.Click();
            Delay.Milliseconds(35000); //wait for the next page to load
        }
    }
}

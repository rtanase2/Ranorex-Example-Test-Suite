/*
 * Created by Ranorex
 * User: wc_ka
 * Date: 8/12/2015
 * Time: 12:44 PM
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
    /// Description of SelectCInMyAccounts.
    /// </summary>
    [TestModule("EE8976FC-BD97-4697-A784-3C7E282D15A4", ModuleType.UserCode, 1)]
    public class SelectCInMyAccounts : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SelectCInMyAccounts()
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
            
            //Click the C button in the My Accounts page
            ATag cButton = Ranorex.Host.Local.FindSingle<ATag>("/dom[@domain='na12.salesforce.com']//iframe[#'itarget']//div[#'vodNavLinks']//a[@innertext='C']");
            cButton.MoveTo(); Delay.Milliseconds(100);; cButton.Click();
            Delay.Milliseconds(23000); //Wait for next page to load
        }
    }
}

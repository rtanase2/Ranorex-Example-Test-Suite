/*
 * Created by Ranorex
 * User: Rachelle Tanase
 * Date: 8/12/2015
 * Time: 12:47 PM
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
    /// Description of SelectCanterMark.
    /// </summary>
    [TestModule("B7B013EF-5B82-41F1-9195-BEC1A3432371", ModuleType.UserCode, 1)]
    public class SelectCanterMark : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SelectCanterMark()
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
            
            //Click Canter, Mark in list on My Accounts page
            ATag canterMarkButton = Ranorex.Host.Local.FindSingle<ATag>("/dom[@domain='na12.salesforce.com']//iframe[#'itarget']//table[#'vodResultSet']//a[@innertext='Canter, Mark']");
            canterMarkButton.MoveTo(); Delay.Milliseconds(100);; canterMarkButton.Click();
            Delay.Milliseconds(10000); //Wait for next page to load
        }
    }
}

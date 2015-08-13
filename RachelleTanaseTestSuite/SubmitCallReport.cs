/*
 * Created by Ranorex
 * User: Rachelle Tanase
 * Date: 8/12/2015
 * Time: 6:04 PM
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
    /// Description of SubmitCallReport.
    /// </summary>
    [TestModule("72142B78-CDBF-425F-B12F-2485DA9DED7E", ModuleType.UserCode, 1)]
    public class SubmitCallReport : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SubmitCallReport()
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
            
            ButtonTag submit = Ranorex.Host.Local.FindSingle<ButtonTag>("/dom[@domain='na12.salesforce.com']//iframe[#'itarget']//button[#'btnSubmit2']");
            
            while(!submit.EnsureVisible()){
            	Keyboard.Press("{DOWN}");
            }
            
            submit.MoveTo(); submit.Click(); Delay.Milliseconds(35000);
        }
    }
}

/*
 * Created by Ranorex
 * User: Rachelle Tanase
 * Date: 8/12/2015
 * Time: 1:14 PM
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
    /// Description of SelectCholecapAndLabrinone.
    /// </summary>
    [TestModule("41FE2C9C-4F00-443E-B34D-3F4E76353159", ModuleType.UserCode, 1)]
    public class SelectCholecapAndLabrinone : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SelectCholecapAndLabrinone()
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
            
            InputTag cholecapBox = Ranorex.Host.Local.FindSingle<InputTag>("/dom[@domain='na12.salesforce.com']//iframe[#'itarget']//input[#'chkda00U0000006DoZJIA0']");
            InputTag labrinoneBox = Ranorex.Host.Local.FindSingle<InputTag>("/dom[@domain='na12.salesforce.com']//iframe[#'itarget']//input[#'chkda00U0000006DoZNIA0']");
            
            //Scroll down until you can see the check boxes for Cholecap and Labrinone
            while(!cholecapBox.EnsureVisible()){
            	Keyboard.Press("{DOWN}");
            }
            
            //Check the two boxes next to Cholecap and Labrinone
            cholecapBox.Focus(); cholecapBox.MoveTo(); Delay.Milliseconds(100); cholecapBox.Click();
            labrinoneBox.Focus(); labrinoneBox.MoveTo(); Delay.Milliseconds(100); labrinoneBox.Click();
            Delay.Milliseconds(1000); //Wait for next page to load
        }
    }
}

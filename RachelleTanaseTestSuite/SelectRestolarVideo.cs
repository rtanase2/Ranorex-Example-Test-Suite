/*
 * Created by Ranorex
 * User: Rachelle Tanase
 * Date: 8/12/2015
 * Time: 5:50 PM
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
    /// Description of SelectRestolarVideo.
    /// </summary>
    [TestModule("0CBEBA76-C999-4FD5-8513-69CBD16BB820", ModuleType.UserCode, 1)]
    public class SelectRestolarVideo : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SelectRestolarVideo()
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
            
            //Create a reference to the check box next to the restolar video option
            InputTag restolarBox = Ranorex.Host.Local.FindSingle<InputTag>("/dom[@domain='na12.salesforce.com']//iframe[#'itarget']//input[#'chkspa00U0000006DoVNIA0']");
            
            //Scroll down so that the user can see the check box
            while(!restolarBox.EnsureVisible()){
            	Keyboard.Press("{DOWN}");
            }
            
            //Click the box
            restolarBox.Focus(); restolarBox.MoveTo(); Delay.Milliseconds(100); restolarBox.Click();
            Delay.Milliseconds(100); //Wait to make sure process goes through
        }
    }
}

/*
 * Created by Ranorex
 * User: Rachelle Tanase
 * Date: 8/12/2015
 * Time: 6:29 PM
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
    /// Description of Logout.
    /// </summary>
    [TestModule("F45DDC8A-EB4E-43E6-A8C6-F994D241EE09", ModuleType.UserCode, 1)]
    public class Logout : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Logout()
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
            
            //Click the "Diana Lam" account button
            DivTag accountButton = Ranorex.Host.Local.FindSingle<DivTag>("/dom[@domain='c.na12.visual.force.com']//div[#'userNavButton']");
            accountButton.MoveTo(); accountButton.Click(); Delay.Milliseconds(100);
            
            //Click logout button
            ATag logoutButton = Ranorex.Host.Local.FindSingle<ATag>("/dom[@domain='c.na12.visual.force.com']//div[#'userNav-menuItems']/a[@innertext='Logout']");
            logoutButton.MoveTo(); logoutButton.Click(); Delay.Milliseconds(2000); //Wait for the next page to load
        }
    }
}

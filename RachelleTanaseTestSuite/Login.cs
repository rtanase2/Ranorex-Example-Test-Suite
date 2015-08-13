/*
 * Created by Ranorex
 * User: Rachelle Tanase
 * Date: 8/12/2015
 * Time: 11:52 AM
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
    /// Description of LoginModule.
    /// </summary>
    [TestModule("8175FE10-4268-4787-961C-ED497F06D7A4", ModuleType.UserCode, 1)]
    public class Login : ITestModule
    {    	    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Login()
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
            //Enter username and password
            InputTag loginField = Ranorex.Host.Local.FindSingle<InputTag>("/dom[@domain='login.salesforce.com']//input[#'username']");
            loginField.Click();
            Keyboard.Press("{END}{SHIFT DOWN}{HOME}{SHIFT UP}{DELETE}"); //Clear current value in username field
            loginField.PressKeys("bb10@bb2.com");
            InputTag passwordField = Ranorex.Host.Local.FindSingle<InputTag>("/dom[@domain='login.salesforce.com']//input[#'password']");
            passwordField.Click();
            Keyboard.Press("{END}{SHIFT DOWN}{HOME}{SHIFT UP}{DELETE}"); //Clear current value in password field
            passwordField.PressKeys("bugb1234");
            
            //Press the login button
            ButtonTag loginButton = Ranorex.Host.Local.FindSingle<ButtonTag>("/dom[@domain='login.salesforce.com']//div[#'theloginform']/form[@name='login']/?/?/button[@id='Login']");
            loginButton.MoveTo(); Delay.Milliseconds(100); loginButton.Click();
            Delay.Milliseconds(10000); //wait for the next page to load
        }
    }
}

/*
 * Created by Ranorex
 * User: Rachelle Tanase
 * Date: 8/12/2015
 * Time: 6:00 PM
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
    /// Description of ChangeRestolarQuantity.
    /// </summary>
    [TestModule("0F2548CA-EEC7-492B-9D54-291AA95A1C39", ModuleType.UserCode, 1)]
    public class ChangeRestolarQuantity : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ChangeRestolarQuantity()
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
            
            //Select the Restolar Video quanitity input field
            InputTag quantity = Ranorex.Host.Local.FindSingle<InputTag>("/dom[@domain='na12.salesforce.com']//iframe[#'itarget']//input[#'qtyida00U0000006DoVNIA0']");
            
            //Scroll down until you can see the quantity field
            while(!quantity.EnsureVisible()){
            	Keyboard.Press("{DOWN}");
            }
            
            //Change the quantity
            quantity.Focus(); quantity.Click(); Keyboard.Press("{END}{SHIFT DOWN}{HOME}{SHIFT UP}{DELETE}" + "2");  //Clear the input field
            Delay.Milliseconds(500); //Wait
        }
    }
}

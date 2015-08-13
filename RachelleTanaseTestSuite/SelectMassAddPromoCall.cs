/*
 * Created by Ranorex
 * User: Rachelle Tanase
 * Date: 8/12/2015
 * Time: 1:07 PM
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
    /// Description of SelectMassAddPromoCall.
    /// </summary>
    [TestModule("83D1CB69-DD30-4259-9E1C-3173EE8DE1A6", ModuleType.UserCode, 1)]
    public class SelectMassAddPromoCall : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SelectMassAddPromoCall()
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
            
            //Click Record Type ID selector
            SelectTag recordTypeId = Ranorex.Host.Local.FindSingle<SelectTag>("/dom[@domain='na12.salesforce.com']//iframe[#'itarget']//select[#'RecordTypeId']");
            recordTypeId.Focus(); recordTypeId.MoveTo(); Delay.Milliseconds(100); recordTypeId.Click(); Delay.Milliseconds(100);
            
            Keyboard.Press("{DOWN},{DOWN},{DOWN},{ENTER}"); //Select the Mass Add Promo Call option
            Delay.Milliseconds(25000); //Wait for next page to load
        }
    }
}

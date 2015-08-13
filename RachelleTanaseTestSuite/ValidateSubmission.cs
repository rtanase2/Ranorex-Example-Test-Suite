/*
 * Created by Ranorex
 * User: Rachelle Tanase
 * Date: 8/12/2015
 * Time: 6:12 PM
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
    /// Description of ValidateSubmission.
    /// </summary>
    [TestModule("99FDADB9-6FCB-4EE2-ABBE-7667C3F1B584", ModuleType.UserCode, 1)]
    public class ValidateSubmission : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateSubmission()
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
            
            //Create new ATag to hod the printable view link
            ATag print;
            //If the printable view link is on the page then the form was submitted successfully
            if(Ranorex.Host.Local.TryFindSingle<ATag>("/dom[@domain='c.na12.visual.force.com']//iframe[#'vod_iframe']//table[#'bodyTable']//div/div[1]/?/?/a[@innertext='Printable View']", out print)){
            	Ranorex.Report.Success("Submission was successful");
            }
            //Else, the submission failed.
            else {
            	Ranorex.Report.Error("Submission unsuccessful");
            	throw new Ranorex.ValidationException("Call report not was not successfully submitted.");
            }
            
        }
    }
}

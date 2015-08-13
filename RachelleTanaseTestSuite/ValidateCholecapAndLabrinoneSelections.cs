/*
 * Created by Ranorex
 * User: Rachelle Tanase
 * Date: 8/12/2015
 * Time: 7:06 PM
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
    /// Description of ValidateCholecapAndLabrinoneSelections.
    /// </summary>
    [TestModule("DC489C6E-ED90-4E2D-858F-C6E300D5DFAE", ModuleType.UserCode, 1)]
    public class ValidateCholecapAndLabrinoneSelections : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ValidateCholecapAndLabrinoneSelections()
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
            
            TdTag temp;
            
            //Validate that the Detailing Priority section shows Cholecap and Labrinone
            if(Ranorex.Host.Local.TryFindSingle<TdTag>("/dom[@domain='na12.salesforce.com']//iframe[#'itarget']//tr[#'dpi_1']/td[@innertext='Cholecap']", out temp)){
            	Ranorex.Report.Success("Cholecap successfully recorded in Detailed Priority");
            }
            else {
            	Ranorex.Report.Warn("Cholecap not successfully recorded in Detailed Priority");
            }
            
            if(Ranorex.Host.Local.TryFindSingle<TdTag>("/dom[@domain='na12.salesforce.com']//iframe[#'itarget']//tr[#'dpi_2']/td[@innertext='Labrinone']", out temp)){
            	Ranorex.Report.Success("Labrinone successfully recorded in Detailed Priority");
            }
            else {
            	Ranorex.Report.Warn("Labrinone not successfully recorded in Detailed Priority");
            }
            
            //Validate that Call Discussion contains both Cholecap and Labrinone in the correct order
            SelectTag temp1;
            int cCount = 0;
            int lCount = 0;
            int counter = 0;
            bool cCorrect = false;
            bool lCorrect = false;
            //Get first select box and parse through options to find which is selected
            if(Ranorex.Host.Local.TryFindSingle<SelectTag>("/dom[@domain='na12.salesforce.com']//iframe[#'itarget']//select[#'1.Call2_Discussion_vod__c.Product_vod__c']", out temp1)){
            	foreach(OptionTag obj in temp1.Options){
            		if(obj.Selected){
            			if(counter == 1){
            				cCount++;
            				cCorrect = true;
            			}
            			else if(counter == 2){
            				lCount++;
            			}
            		}
            		counter++;
            	}
            }
            //Get second select box and parse through options to find which is selected
            if(Ranorex.Host.Local.TryFindSingle<SelectTag>("/dom[@domain='na12.salesforce.com']//iframe[#'itarget']//select[#'2.Call2_Discussion_vod__c.Product_vod__c']", out temp1)){
            	counter = 0;
            	foreach(OptionTag obj in temp1.Options){
            		if(obj.Selected){
            			if(counter == 1){
            				cCount++;
            			}
            			else if(counter == 2){
            				lCount++;
            				lCorrect = true;
            			}
            		}
            		counter++;
            	}
            }
            //Print correct message
            if(cCorrect && lCorrect){
            	Ranorex.Report.Success("Both Labrinone and Cholecap are listed in the Call Discussion in the correct positions");
            }
            else if(cCount == 1 && lCount == 1){
            	Ranorex.Report.Warn("Both Labrinone and Cholecap are listed in the Call Discussion, but they are in the wrong positions");
            }
            else{
            	Ranorex.Report.Warn("Labrinone appears in Call Discussion " + lCount + " times and Cholecap appears in Call Discussion " + cCount + " times.");
            }
        }
    }
}

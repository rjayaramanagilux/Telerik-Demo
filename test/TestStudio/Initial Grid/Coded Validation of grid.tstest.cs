using Telerik.WebAii.Controls.Html;
using Telerik.WebAii.Controls.Xaml;
using Telerik.WebAii.Controls.Xaml.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;
using ArtOfTest.WebAii.Design;
using ArtOfTest.WebAii.Design.Execution;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

namespace Telerik_Demo_App
{

    //
    // You can add custom execution steps by simply
    // adding a void function and decorating it with the [CodedStep] 
    // attribute to the test method. 
    // Those steps will automatically show up in the test steps on save.
    //
    // The BaseWebAiiTest exposes all key objects that you can use
    // to access the current testcase context. [i.e. ActiveBrowser, Find ..etc]
    //
    // Data driven tests can use the Data[columnIndex] or Data["columnName"] 
    // to access data for a specific data iteration.
    //
    // Example:
    //
    // [CodedStep("MyCustom Step Description")]
    // public void MyCustomStep()
    // {
    //        // Custom code goes here
    //      ActiveBrowser.NavigateTo("http://www.google.com");
    //
    //        // Or
    //        ActiveBrowser.NavigateTo(Data["url"]);
    // }
    //
        

    public class Coded_Validation_of_grid : BaseWebAiiTest
    {

        #region [ Dynamic Pages Reference ]

        private Pages _pages;

        /// <summary>
        /// Gets the Pages object that has references
        /// to all the elements, frames or regions
        /// in this project.
        /// </summary>
        public Pages Pages
        {
            get
            {
                if (_pages == null)
                {
                    _pages = new Pages(Manager.Current);
                }
                return _pages;
            }
        }

        #endregion
        
        // Add your test methods here...

        [CodedStep(@"New Coded Step")]
        public void Fixture_Setup()
        {
            SetExtractedValue("contactName", "Holmes");
        }

        [CodedStep(@"New Coded Step")]
        public void Open_contact_form_for_test_user()
        {
            HtmlTable table = Find.ByXPath<HtmlTable>("//div[@id='content']/table");

            string contactName = GetExtractedValue("contactName") as string;
            HtmlTableRow row = table.Find.TableRow(contactName);

            HtmlAnchor cell = row.Find.ByContent<HtmlAnchor>("View Contact");
            string windowUrl = cell.HRef;
            SetExtractedValue("contactWindowUrl", windowUrl);

            cell.Click();            
        }

    }
}















// hiding way off down here so Jim can find it if he is a dork and forgets how
// HtmlTableRow row = Pages.Main_Grid_Page.ContactGridTable.Find.TableRow(contactName);


//HtmlTable table = Find.ByXPath<HtmlTable>("//div[@id='content']/table");

//string contactName = GetExtractedValue("contactName") as string;
//HtmlTableRow row = table.Find.TableRow(contactName);

//HtmlAnchor cell = row.Find.ByContent<HtmlAnchor>("View Contact");
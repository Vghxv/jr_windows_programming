using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Windows.Input;
using System.Windows.Forms;
using System.IO;
using OpenQA.Selenium.Interactions;
using System.Security.Permissions;

namespace DrawingForm.Tests
{
    public class Robot
    {
        private static WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";
        private const string APP_PROJECT_NAME = "DrawingForm";
        private const string APP_TITLE = "SlideForge";

        // constructor
        public Robot()
        {
            if (_driver == null)
            {
                string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
                string targetAppPath = Path.Combine(solutionPath, APP_PROJECT_NAME, "bin", "Debug", $"{APP_PROJECT_NAME}.exe");
                var options = new AppiumOptions();
                options.AddAdditionalCapability("app", targetAppPath);
                _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                _windowHandles = new Dictionary<string, string>
                {
                    { APP_TITLE, _driver.CurrentWindowHandle }
                };
                SwitchTo(APP_TITLE);
                _driver.Manage().Window.Maximize();
            }
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {
                    }
                }
            }
        }

        // clean up
        public void CleanUp()
        {
            if (_driver != null)
            {
                SwitchTo(APP_TITLE);
                _driver.Quit();
                _driver.Dispose();
                _windowHandles.Clear();
                _driver = null;
            }
        }

        // launch app
        public void LaunchApp()
        {
            if (_driver != null)
            {
                _driver.LaunchApp();
                _driver.Manage().Window.Maximize();
            }
        }

        // close app
        public void CloseApp()
        {
            if (!IsAppClosed())
            {
                _driver.CloseApp();
            }
        }

        // is app closed
        public bool IsAppClosed()
        {
            if (_driver != null)
            {
                try
                {
                    _driver.FindElementByName(APP_TITLE);
                    return false;
                }
                catch
                {
                    return true;
                }
            }
            return true;
        }

        // test
        public void Sleep(double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        // test
        public void ClickButton(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        // test
        public void PerformAction(IList<ActionSequence> actionSequence)
        {
            _driver.PerformActions(actionSequence);
        }

        // test
        public WindowsElement FindElementByName(string name)
        {
            return _driver.FindElementByName(name);
        }

        // test
        public WindowsElement FindElementByAccessibilityId(string name)
        {
            return _driver.FindElementByAccessibilityId(name);
        }

        // test
        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }

        // test
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        // test
        public void CloseMessageBox()
        {
            _driver.FindElementByName("Ok").Click();
        }

        // test
        public void ClickDataGridViewCellBy(string name, int rowIndex, string columnName)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            _driver.FindElementByName($"{columnName} 資料列 {rowIndex}").Click();
        }

        // test 
        public void AssertButtonState(string name, bool isChecked)
        {
            WindowsElement element = _driver.FindElementByName(name);
            AccessibleStates accessibleStates = (AccessibleStates)Enum.Parse(typeof(AccessibleStates), element.GetAttribute("LegacyState"));
            Assert.IsTrue(isChecked == ((accessibleStates & AccessibleStates.Checked) == AccessibleStates.Checked));
        }

        // test
        public void AssertDataGridViewRowDataBy(string name, int rowIndex, string[] data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");

            // FindElementsByXPath("//*") captures the "row" node as well, hence starting from 1 to skip the "row" node.
            for (int i = 1; i < rowDatas.Count; i++)
            {
                Assert.AreEqual(data[i - 1], rowDatas[i].Text.Replace("(null)", ""));
            }
        }

        // test
        public void AssertDataGridViewRowCountBy(string name, int rowCount)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            Point point = new Point(dataGridView.Location.X, dataGridView.Location.Y);
            AutomationElement element = AutomationElement.FromPoint(point);

            while (element != null && element.Current.LocalizedControlType.Contains("datagrid") == false)
            {
                element = TreeWalker.RawViewWalker.GetParent(element);
            }

            if (element != null)
            {
                GridPattern gridPattern = element.GetCurrentPattern(GridPattern.Pattern) as GridPattern;

                if (gridPattern != null)
                {
                    Assert.AreEqual(rowCount, gridPattern.Current.RowCount);
                }
            }
        }
    }
}

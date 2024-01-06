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
using DrawingModel;
using System.Security.Cryptography;

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
        public Interaction CreateMoveTo(WindowsElement windowsElement, PointerInputDevice device, int x, int y)
        {
            var size = windowsElement.Size;
            return device.CreatePointerMove(windowsElement, x - (size.Width / 2), y - (size.Height / 2), TimeSpan.Zero);
        }

        // test
        public Interaction CreatePointerDown(PointerInputDevice device, MouseButton button)
        {
            return device.CreatePointerDown(button);
        }

        // test
        public Interaction CreatePointerUp(PointerInputDevice device, MouseButton button)
        {
            return device.CreatePointerUp(button);
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
        public void AssertDataGridCellValue(WindowsElement windowsElement, int rowIndex, int columnIndex, string value)
        {
            var row = windowsElement.FindElementByName($"資料列 {rowIndex}");
            var cell = row.FindElementByName($"儲存格 {columnIndex}");
            Assert.AreEqual(value, cell.Text);
        }

        // test 
        public void AssertButtonState(string name, bool isChecked)
        {
            WindowsElement element = _driver.FindElementByName(name);
            AccessibleStates accessibleStates = (AccessibleStates)Enum.Parse(typeof(AccessibleStates), element.GetAttribute("LegacyState"));
            Assert.IsTrue(isChecked == ((accessibleStates & AccessibleStates.Checked) == AccessibleStates.Checked));
        }

        // test
        public void AssertModelInfoCellString(WindowsElement dataGridView, int rowIndex, int columnIndex ,string data)
        {
            var text = dataGridView
            .FindElementByName($"Row {rowIndex}")
            .FindElementByName($"{Constant.ModelInfoColumnName[columnIndex]} Row {rowIndex}").Text;
            Assert.AreEqual(data, text);
        }

        // test press delete btn in model info
        public void PressModelInfoCell(WindowsElement dataGridView, int rowIndex, int columnIndex)
        {
            dataGridView
            .FindElementByName($"Row {rowIndex}")
            .FindElementByName($"{Constant.ModelInfoColumnName[columnIndex]} Row {rowIndex}").Click();
        }

        //public void AssertModelInfoRowCount(WindowsElement dataGridView, int rowCount)
        //{
        //    var rows = dataGridView.FindElementsByXPath("*[starts-with(text(), 'Row')]");
        //    //Assert.AreEqual(rowCount);
        //    for (int i = 0; i < rowCount; i++)
        //    {
        //        Assert.AreEqual($"Row {i}", rows[i].Text);
        //    }
        //}

        // test
        public void AssertModelInfoRowCount(WindowsElement dataGridView, int rowCount)
        {
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

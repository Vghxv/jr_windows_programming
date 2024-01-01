using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DrawingModel;
using Newtonsoft.Json.Bson;
using OpenQA.Selenium.Appium.Windows;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace DrawingForm.Tests
{
    [TestClass()]
    public class MainFormTests
    {
        private static Robot _robot;

        private static ActionBuilder _actionBuilder;
        private static PointerInputDevice _pointerInputDevice;

        private WindowsElement _canvasPanel;
        private WindowsElement _slideInfo;
        private WindowsElement _modelInfo;

        private readonly string CANVA_PANEL = "canvasPanel";
        // init
        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            _robot = new Robot();
        }

        // cleanup
        [ClassCleanup()]
        public static void Cleanup()
        {
            _robot.CleanUp();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            if (_robot.IsAppClosed())
                _robot.LaunchApp();
            _actionBuilder = new ActionBuilder();
            _pointerInputDevice = new PointerInputDevice(PointerKind.Pen);
            _canvasPanel = _robot.FindElementByAccessibilityId(Constant.CANVA_PANEL);
            //Assert.AreEqual(_canvasPanel.Size,ToString(), "Custom");
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            _robot.CloseApp();
        }

        // toolStripButtons
        [TestMethod()]
        public void TestDrawButtons()
        {
            //_robot.ClickButton(Constant.LINE);
            //_robot.AssertButtonState(Constant.LINE, true);
            //_robot.AssertButtonState(Constant.RECTANGLE, false);
            //_robot.AssertButtonState(Constant.ELLIPSE, false);
            //_robot.ClickButton(Constant.RECTANGLE);
            //_robot.AssertButtonState(Constant.LINE, false);
            //_robot.AssertButtonState(Constant.RECTANGLE, true);
            //_robot.AssertButtonState(Constant.ELLIPSE, false);
            //_robot.ClickButton(Constant.ELLIPSE);
            //_robot.AssertButtonState(Constant.LINE, false);
            //_robot.AssertButtonState(Constant.RECTANGLE, false);
            //_robot.AssertButtonState(Constant.ELLIPSE, true);
            //_robot.ClickButton(Constant.MOUSE);
            //_robot.AssertButtonState(Constant.MOUSE, true);
            //_robot.AssertButtonState(Constant.LINE, false);
            //_robot.AssertButtonState(Constant.RECTANGLE, false);
            //_robot.AssertButtonState(Constant.ELLIPSE, false);
        }

        public Interaction CreateMoveTo(WindowsElement windowsElement, PointerInputDevice device, int x, int y)
        {
            var size = windowsElement.Size;
            return device.CreatePointerMove(windowsElement, x - (size.Width / 2), y - (size.Height / 2), TimeSpan.Zero);
        }

        public Interaction CreatePointerDown(PointerInputDevice device, MouseButton button)
        {
            return device.CreatePointerDown(button);
        }

        public Interaction CreatePointerUp(PointerInputDevice device, MouseButton button)
        {
            return device.CreatePointerUp(button);
        }

        [TestMethod()]
        public void TestDrawButtons1()
        {
            _robot.ClickButton(Constant.LINE);
            float x = 1.25f;
            _actionBuilder
            .AddActions(CreateMoveTo(_canvasPanel, _pointerInputDevice, (int)(100 * x), (int)(100 * x)))
            //.AddActions(CreateMoveTo(_canvasPanel, _pointerInputDevice, 100, 100))
            .AddActions(CreatePointerDown(_pointerInputDevice, MouseButton.Left))
            .AddActions(CreateMoveTo(_canvasPanel, _pointerInputDevice, 200, 200))
            .AddActions(CreatePointerUp(_pointerInputDevice, MouseButton.Left));
            _robot.PerformAction(_actionBuilder.ToActionSequenceList());
            _robot.Sleep(5);
        }
    }
}
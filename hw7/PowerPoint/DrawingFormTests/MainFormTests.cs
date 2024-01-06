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
        private WindowsElement _canvasPanel;
        private WindowsElement _slideInfo;
        private WindowsElement _modelInfo;

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
            _canvasPanel = _robot.FindElementByAccessibilityId(Constant.CANVA_PANEL);
            _slideInfo = _robot.FindElementByAccessibilityId(Constant.SLIDE_INFO);
            _modelInfo = _robot.FindElementByAccessibilityId(Constant.MODEL_INFO);
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            _robot.CloseApp();
        }

        public void DrawShape(string shapeName,Coordinates coordinates)
        {
            ActionBuilder actionBuilder = new ActionBuilder();
            PointerInputDevice pointerInputDevice = new PointerInputDevice(PointerKind.Pen);
            _robot.ClickButton(shapeName);
            actionBuilder
            .AddActions(_robot.CreatePointerUp(pointerInputDevice, MouseButton.Left))
            .AddActions(_robot.CreateMoveTo(_canvasPanel, pointerInputDevice, (int)coordinates.x1, (int)coordinates.y1))
            .AddActions(_robot.CreatePointerDown(pointerInputDevice, MouseButton.Left))
            .AddActions(_robot.CreateMoveTo(_canvasPanel, pointerInputDevice, (int)coordinates.x2, (int)coordinates.y2))
            .AddActions(_robot.CreatePointerUp(pointerInputDevice, MouseButton.Left));
            _robot.PerformAction(actionBuilder.ToActionSequenceList());
        }

        [TestMethod()]
        public void TestDrawShapes()
        {
            List<Coordinates> coordinates_list = new List<Coordinates>
            {
                new Coordinates(100, 100, 200, 200),
                new Coordinates(300, 300, 400, 400),
                new Coordinates(100, 500, 200, 600)
            };
            List<string> strings = new List<string>
            {
                Constant.LINE,
                Constant.RECTANGLE,
                Constant.ELLIPSE
            };
            for (int i = 0; i < coordinates_list.Count; i++)
            {
                DrawShape(strings[i], coordinates_list[i]);
                _robot.AssertModelInfoCellString(_modelInfo, i, 2, coordinates_list[i].FormatToString());
            }
        }

        [TestMethod()]
        public void TestRedoUndo()
        {
            List<Coordinates> coordinates_list = new List<Coordinates>
            {
                new Coordinates(100, 100, 200, 200),
                new Coordinates(300, 300, 400, 400),
                new Coordinates(100, 500, 200, 600)
            };
            foreach (Coordinates coordinates in coordinates_list)
            {
                DrawShape(Constant.RECTANGLE, coordinates);
            }
            _robot.ClickButton(Constant.UNDO);
            _robot.ClickButton(Constant.UNDO);
            _robot.ClickButton(Constant.UNDO);
            _robot.ClickButton(Constant.REDO);
            _robot.ClickButton(Constant.REDO);
            _robot.ClickButton(Constant.REDO);
            _robot.ClickButton(Constant.UNDO);
            _robot.AssertModelInfoRowCount(_modelInfo, 2);
            coordinates_list.RemoveAt(2);
            for (int i = 0; i < 2; i++)
            {
                _robot.AssertModelInfoCellString(_modelInfo, i, 2, coordinates_list[i].FormatToString());
            }
        }
    }
}
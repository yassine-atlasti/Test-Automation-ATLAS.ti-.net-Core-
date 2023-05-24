﻿using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System.Net;
namespace Test_Automation_Core.UIElements.Dialogs
{
    public class FilePicker
    {
        private readonly WindowsDriver<WindowsElement> driver;

        public FilePicker(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }

        public void EnterFilePath(string filePath)
        {
            //Entering the file path in the adress box of the file picker using shortcut CTRL+L, the filePath parameter , and the Enter Key
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);
            action.KeyDown(Keys.Control).SendKeys("l").KeyUp(Keys.Control).SendKeys(filePath).SendKeys(Keys.Enter).Perform();
        }



        public void EnterFileName(string fileName)
        {
            //Entering the file path in the adress box of the file picker using shortcut CTRL+L, the filePath parameter , and the Enter Key
            OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);
            action.KeyDown(Keys.Alt).SendKeys("n").KeyUp(Keys.Control).SendKeys(fileName).SendKeys(Keys.Enter).Perform();
        }


        public void ClickOpenButton()
        {
            driver.FindElementByName("Open").Click();
        }

        public void ClickCancelButton()
        {
            driver.FindElementByName("Cancel").Click();
        }
        public void ClickSelectFolderButton()
        {
            driver.FindElementByName("Select Folder").Click();
        }

        public void ClickSaveButton()
        {
            driver.FindElementByName("Save").Click();
        }
    }
}

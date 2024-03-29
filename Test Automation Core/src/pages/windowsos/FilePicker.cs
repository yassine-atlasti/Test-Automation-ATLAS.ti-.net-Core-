﻿using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using TextCopy;
namespace Test_Automation_Core.src.pages.windowsos
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


            ClipboardService.SetText(filePath);

            // Create a new Actions object
            Actions action = new Actions(driver);

            Thread.Sleep(1000);

            // Use CTRL+L to focus on the address bar, then paste the clipboard content 
            action.KeyDown(Keys.Control).SendKeys("l").KeyUp(Keys.Control).SendKeys(Keys.Control + "v").KeyUp(Keys.Control).SendKeys(Keys.Enter).Perform();
        }



        public void EnterFileName(string fileName)
        {
            ClipboardService.SetText(fileName);

            // Create a new Actions object
            Actions action = new Actions(driver);

            /**
            // Press and hold the Alt key
            action.KeyDown(Keys.Alt);

            // Send the "n" key
            action.SendKeys("n");

            // Release the Alt key
            action.KeyUp(Keys.Alt);

            // Perform the action to send the Alt+N shortcut
            action.Perform();
            **/
            action.SendKeys(Keys.Alt + "n").KeyUp(Keys.Alt).Perform();

            // Paste the clipboard content
            action.SendKeys(Keys.Control + "v").KeyUp(Keys.Control).Perform();



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


        public void ClickYesIfVisible()
        {
            // Try to find the "Yes" element
            try
            {
                var yesElement = driver.FindElementByName("Yes");

               
                
                    // Click the "Yes" button
                    yesElement.Click();
                    Console.WriteLine("Clicked 'Yes' button.");
                
            }

            catch(Exception ex)
            {
                // Log or handle the case where the "Yes" button is not visible
                Console.WriteLine("'Yes' button is not visible or not found.");
            }
            
           
        }

    }
}

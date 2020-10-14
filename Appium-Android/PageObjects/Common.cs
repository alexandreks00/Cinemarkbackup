using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.IO;
using Assert = NUnit.Framework.Assert;

namespace Appium_Android.PageObjects
{
    public class Common : Session
    {
 
        
        public static void WaitAndRetry(TimeSpan period)
        {


            try
            {

                System.Threading.Thread.Sleep(period);

            }
            catch (Exception e)
            {

                Assert.Fail(e.Message);
            }
            finally
            {

                //Log
            }
        }

        //public static void scrollToElement(String elementName1, String elementName2)
        //{
        //    WebElement abc = driver.findElement(By.name(elementName1));
        //    WebElement abc2 = driver.findElement(By.name(elementName2));
        //    int x = abc.getLocation().getX();
        //    int y = abc.getLocation().getY();
        //    int x1 = abc2.getLocation().getX();
        //    int y1 = abc2.getLocation().getY();
        //    driver.swipe(x1, y1, x, y, 1);
        //}


    }




        
}

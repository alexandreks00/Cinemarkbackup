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
using System;
using System.IO;
using Assert = NUnit.Framework.Assert;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Threading.Tasks;
using Appium_Android.PageObjects;
namespace Appium_Android
{
    public class Session
    {
        const string Host = "http://127.0.0.1:4723/wd/hub";
        public static AppiumDriver<AndroidElement> _driver;


        //AndroidDriver<IWebElement> driver;

        [SetUp]
        public void SessionInit()
        {


            var appPath = @"C:\\Users\\Alexandre.DESKTOP-2TBN4PM\\Desktop\\Appium-Android\\Appium-Android\\Appium-Android\\cinemark.apk";

            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.cinemark.debug");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            //appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "8.1");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "com.cinemark.presentation.common.MainActivity");
            appiumOptions.AddAdditionalCapability(AndroidMobileCapabilityType.AutoGrantPermissions, true);
            //appiumOptions.AddAdditionalCapability("chromedriverExecutable", @"C:\driver\chromedriver.exe");
            appiumOptions.AddAdditionalCapability("allowSessionOverride", true);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App, appPath);
            appiumOptions.AddAdditionalCapability("udid", "emulator-5554");
            appiumOptions.AddAdditionalCapability("automationName", "UiAutomator2");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.NoReset, false);
            
            appiumOptions.AddAdditionalCapability("gpsEnabled", true);
            appiumOptions.AddAdditionalCapability("unicodeKeyboard", true);
            appiumOptions.AddAdditionalCapability("resetKeyboard", true);


            _driver = new AndroidDriver<AndroidElement>(new Uri(Host), appiumOptions);

            Assert.IsNotNull(_driver.Context);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);



        }
      


    } 
}
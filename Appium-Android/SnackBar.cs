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
using System.Threading;
using Appium_Android.PageObjects;
using System.Globalization;

namespace Appium_Android
{
    public class SnackBar : Session
    {
        /* Elementos */
        public static string menuSnackBar = "com.cinemark.debug:id/action_snackbar";
        public static string viewNomeCinema = "com.cinemark.debug:id/cineNameTextView";
        public static string escolhaSeuSnack = "//android.widget.TextView[@text='Escolha seu snack']";
        public static string menuToyStory = "//android.widget.RelativeLayout[@index='2']";
        public static string menuVingadores = "//android.widget.RelativeLayout[@index='3']";
        public static string menuCombos = "//android.widget.RelativeLayout[@index='4']";
        public static string menuPipocas = "//android.widget.RelativeLayout[@index='5']";
        public static string addPipocas1 = "new UiSelector().resourceId(\"com.cinemark.debug:id/moreNewProductButton\").instance(0)";
        public static string addPipocas2 = "new UiSelector().resourceId(\"com.cinemark.debug:id/moreNewProductButton\").instance(1)";
        public static string precoPipocas1 = "new UiSelector().resourceId(\"com.cinemark.debug:id/textViewNewProductValue\").instance(0)";
        public static string precoPipocas2 = "new UiSelector().resourceId(\"com.cinemark.debug:id/textViewNewProductValue\").instance(1)";
        public static string somaValorSnacks = "com.cinemark.debug:id/txtviewButtonValue";
        
        [Test]
        public void validaValorSnacks()
        {
            TimeSpan period = TimeSpan.FromSeconds(2);
            int tryCount = 2;
            if (tryCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(tryCount));

            Cinemas cinemas = new Cinemas();
            cinemas.EscolherCinemaComSucesso();

            while (true)
            { 
                try
                {
                    AndroidElement menu_snackbar = _driver.FindElementById(menuSnackBar);
                    menu_snackbar.Click();
                    break;
                
                }
                catch (StaleElementReferenceException)
                {
                    if (--tryCount == 0)
                        throw;
                    Common.WaitAndRetry(period);
                }
            }
            
            AndroidElement pipocas = _driver.FindElementByXPath(menuPipocas);
                    pipocas.Click();

            AndroidElement add_pipocas1 = _driver.FindElement(MobileBy.AndroidUIAutomator(addPipocas1));
                add_pipocas1.Click();
            AndroidElement add_pipocas2 = _driver.FindElement(MobileBy.AndroidUIAutomator(addPipocas2));
                add_pipocas2.Click();

            AndroidElement preco_pipocas1 = _driver.FindElement(MobileBy.AndroidUIAutomator(precoPipocas1));
                decimal preco1 = Decimal.Parse(preco_pipocas1.Text, NumberStyles.Currency);
            AndroidElement preco_pipocas2 = _driver.FindElement(MobileBy.AndroidUIAutomator(precoPipocas2));
                decimal preco2 = Decimal.Parse(preco_pipocas2.Text, NumberStyles.Currency);
            AndroidElement soma_valor_snacks = _driver.FindElementById(somaValorSnacks);
                decimal soma_final = Decimal.Parse(soma_valor_snacks.Text, NumberStyles.Currency);

            if (!(preco1 + preco2 == soma_final))
                throw new ArgumentException("App nao esta somando os valores corretamente");

        }
    }

   
}

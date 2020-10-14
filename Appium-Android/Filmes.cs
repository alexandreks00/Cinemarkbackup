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
    class Filmes : Session
    {
        public static string menuFilmes = "com.cinemark.debug:id/action_movies";
        public static string deadpool = "//android.widget.TextView[@resource-id='com.cinemark.debug:id/movieTitle', @text='Deadpool 2']";
        public static string filmeSessoesDias = "com.cinemark.debug:id/rclviewCineMoviesDays";
        [Test]
        public void validaTelaSessoes()
        {
            TimeSpan timeout_limit = TimeSpan.FromSeconds(3);
            int retryCount = 2;
            if (retryCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(retryCount));

            Cinemas cinemas = new Cinemas();
            cinemas.EscolherCinemaComSucesso();
            Cinemas.iconeMenuCinemas


        while (true)
        { 
            try
            {
                AndroidElement menu_filmes = _driver.FindElementByAccessibilityId("Filmes");
                menu_filmes.Click();
                    break;
            }
            catch (StaleElementReferenceException)
            {
                if (--retryCount == 0)
                    throw;
                    Common.WaitAndRetry(timeout_limit);
            }
        }


        }
    }
}

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

namespace Appium_Android
{
    public class Cinemas : Session
    {

        public static string idBotaoEntrar = "//android.widget.Button[@text='Entrar', checkable]";
        public static string skip = "com.cinemark.debug:id/txtviewSkip";
        public static string menuCinemas = "com.cinemark.debug:id/action_cine";
        public static string iconeMenuCinemas = "//android.widget.FrameLayout[@content-desc='Cinemas']/android.widget.ImageView";
        readonly public static string cinemaSalvador = "Salvador";
        public static string iconeSearch = "com.cinemark.debug:id/search";
        public static string barraPesquisaCidadeCinema = "com.cinemark.debug:id/search_src_text";
        public static string resultadoPesquisa = "com.cinemark.debug:id/rltlayoutCineSelectMainLayout";
       
        public static string textoPrecoIngressos = "com.cinemark.debug:id/txtviewTicketsPrice";
        public static string filtroSessoes = "com.cinemark.debug:id/txtviewFilterLabel";
        public static string textoDetalhesPreco = "com.cinemark.debug:id/txvTicketsValuesDetail";
        public static string dialogDetalhesPreco = "com.cinemark.debug:id/ivDialogTicketValuesExit";


       readonly TimeSpan period = TimeSpan.FromSeconds(2);

        [Test]
       public void ValidarDialogDetalhesPrecosIngressos()
       {
            int tryCount = 2;

            if (tryCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(tryCount));

            EscolherCinemaComSucesso();

            while (true)
            {
                try
                {
                  
                    

                    AndroidElement texto_preco_ingressos = _driver.FindElementById(textoPrecoIngressos);
                    bool assert_texto_preco_ingressos = texto_preco_ingressos.Displayed;
                    texto_preco_ingressos.Click();

                    AndroidElement texto_detalhes_preco = _driver.FindElementById(textoDetalhesPreco);
                    bool assert_texto_detalhes_preco = texto_detalhes_preco.Displayed;

                    AndroidElement dialog_detalhes_preco = _driver.FindElementById(dialogDetalhesPreco);
                    bool assert_dialog_detalhes_preco = dialog_detalhes_preco.Displayed;


                    break;

                }
                catch (NoSuchElementException)
                {
                    if (--tryCount == 0)
                        throw;
                    Common.WaitAndRetry(period);
                }

          
            
            }



        }
        [Test]
        public void EscolherCinemaComSucesso()
        {

            AndroidElement menu_cinemas = _driver.FindElementById(menuCinemas);
            menu_cinemas.Click();

            AndroidElement skip_pular = _driver.FindElementById(skip);
            skip_pular.Click();

            AndroidElement icone_search = _driver.FindElementById(iconeSearch);
            bool assert_icone_search = icone_search.Displayed;
            icone_search.Click();

            AndroidElement barra_pesquisa = _driver.FindElementById(barraPesquisaCidadeCinema);
            barra_pesquisa.Click(); barra_pesquisa.SendKeys(cinemaSalvador);

            AndroidElement resultado_pesquisa = _driver.FindElementById(resultadoPesquisa);
            resultado_pesquisa.Click();
        }


    }
}

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
    public class Login : Session
    {
        //Elementos:
        public static string botaoEntrar = "com.cinemark.debug:id/buttonEnter";
        public static string botaoEntrarEmail = "//*[@text='Entrar com e-mail']";
        public static string campoInserirEmail = "com.cinemark.debug:id/emailEditText";
        public static string campoInserirSenha = "com.cinemark.debug:id/passwordEditText";
        public static string botaoLoginEntrar = "com.cinemark.debug:id/loginButton";
        public static string emailValido = "juliana.p942@gmail.com";
        public static string menuMinhaConta = "Conta";

        //Elementos que sao exibidos no status de USUARIO LOGADO
        public static string avatar = "com.cinemark.debug:id/imgviewAvatarProfileLogged";
        public static string nome = "com.cinemark.debug:id/textViewNameProfileLogged";
        public static string email = "com.cinemark.debug:id/textViewEmailProfileLogged";
        public static string botaoSair = "com.cinemark.debug:id/textViewEmailProfileLogged";

        //Opcoes de menu
        public static string pedidos = "com.cinemark.debug:id/rltlayoutProfileMyOrders";
        public static string meuCinemark = "com.cinemark.debug:id/rltlayoutMeuCinemark";
        public static string meusDados = "com.cinemark.debug:id/rltlayoutMyDataProfileLogged";
        public static string alterarSenha = "com.cinemark.debug:id/rltlayoutPassswordProfileLogged";
        public static string pagamento = "com.cinemark.debug:id/rltlayoutProfileMyCreditCards";
  
        public static string cupons = "com.cinemark.debug:id/rltlayoutDiscountCouponProfileLogged";
        public static string termos = "com.cinemark.debug:id/rltlayoutProfileLoggedTermsAndConditions";
        public static string atendimento = "com.cinemark.debug:id/rltlayoutFaqProfileLogged";
        public static string sobreOApp = "com.cinemark.debug:id/rltlayoutProfileAbout";



        [Test]
        public void Logar()
        {
            AndroidElement botao_entrar = _driver.FindElementById(botaoEntrar);
            botao_entrar.Click();

            AndroidElement botao_entrar_email = _driver.FindElementByXPath(botaoEntrarEmail);
            botao_entrar_email.Click();

            LogarComEmail(TimeSpan.FromSeconds(3));

        }



        public static void LogarComEmail(TimeSpan period, int tryCount = 2)
        {
            if (tryCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(tryCount));

            while (true)
            {
                try
                {
                    AndroidElement campo_email = _driver.FindElementById(campoInserirEmail);
                    campo_email.Click(); campo_email.SendKeys("juliana.p942@gmail.com");

                    AndroidElement campo_senha = _driver.FindElementById(campoInserirSenha);
                    var exibe_campo_senha = campo_senha.Displayed;

                    if (exibe_campo_senha)
                    {
                        campo_senha.Click(); campo_senha.SendKeys("123456");
                    }

                    AndroidElement botao_login_entrar = _driver.FindElementById(botaoLoginEntrar);
                    botao_login_entrar.Click();
                   
                    break;
                }
                catch 
                {
                    if (--tryCount == 0)
                        throw;
                    Common.WaitAndRetry(period);

                }
            }

        }
        public void LogarEmailFormatoInvalido(TimeSpan period, int tryCount = 2)
        {
            AndroidElement botao_entrar = _driver.FindElementById(botaoEntrar);
            botao_entrar.Click();

            AndroidElement botao_entrar_email = _driver.FindElementByXPath(botaoEntrarEmail);
            botao_entrar_email.Click();

            AndroidElement campo_email = _driver.FindElementById(campoInserirEmail);
            campo_email.Click(); campo_email.SendKeys("email");

            AndroidElement campo_senha = _driver.FindElementById(campoInserirSenha);
            var exibe_campo_senha = campo_senha.Displayed;

                if (exibe_campo_senha)
                {
                    campo_senha.Click(); campo_senha.SendKeys("123456");
                }

            AndroidElement botao_login_entrar = _driver.FindElementById(botaoLoginEntrar);
            botao_login_entrar.Click();


            Assert.IsTrue(botao_login_entrar.Enabled);
       
        }
        public void LogarEmailInvalido(TimeSpan period, int tryCount = 2)
        {
            AndroidElement botao_entrar = _driver.FindElementById(botaoEntrar);
            botao_entrar.Click();

            AndroidElement botao_entrar_email = _driver.FindElementByXPath(botaoEntrarEmail);
            botao_entrar_email.Click();

            AndroidElement campo_email = _driver.FindElementById(campoInserirEmail);
            campo_email.Click(); campo_email.SendKeys("email@invalido.com");

            AndroidElement campo_senha = _driver.FindElementById(campoInserirSenha);
            var exibe_campo_senha = campo_senha.Displayed;

            if (exibe_campo_senha)
            {
                campo_senha.Click(); campo_senha.SendKeys("123456");
            }

            AndroidElement botao_login_entrar = _driver.FindElementById(botaoLoginEntrar);
            botao_login_entrar.Click();

            Assert.IsTrue(botao_login_entrar.Displayed);

        }
        [Test]
        public void MinhaContaMenusExibidos()
        {
            

            TimeSpan period = TimeSpan.FromSeconds(2);
            int tryCount = 2;

            if (tryCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(tryCount));
            
            Logar();

            while (true)
            {
                try
                {
                    AndroidElement menu_minha_conta = _driver.FindElementByAccessibilityId(menuMinhaConta);
                    menu_minha_conta.Click();

                    AndroidElement conta_avatar = _driver.FindElementById(avatar); Assert.IsTrue(conta_avatar.Enabled);
                    AndroidElement conta_nome = _driver.FindElementById(nome); Assert.IsTrue(conta_nome.Enabled);
                    AndroidElement conta_email = _driver.FindElementById(email); Assert.IsTrue(conta_email.Enabled);
                    AndroidElement conta_botao_sair = _driver.FindElementById(botaoSair); Assert.IsTrue(conta_botao_sair.Enabled);

                    break;
                }
                catch (StaleElementReferenceException)
                {
                    if (--tryCount == 0)
                        throw;
                    Common.WaitAndRetry(period);
                }
            }


        }



    }
        
}


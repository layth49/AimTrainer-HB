using System;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WindowsInput;


class Program
{
    static void Main()
    {
        // Set up the driver
        IWebDriver driver = new ChromeDriver("./");

        // Create input simulator
        InputSimulator simulator = new InputSimulator();

        // Navigate to the typing test website
        driver.Navigate().GoToUrl("https://humanbenchmark.com/tests/aim");

        // Give some time for the page to fully load
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        driver.Manage().Window.Maximize(); // Maximizes the window to full screen

        #region
        Thread.Sleep(1000);
        IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[3]/div/div[2]/a[2]"));
        loginButton.Click();

        IWebElement inputUser = WaitForElement(driver, By.CssSelector("#root > div > div.css-1f554t4.e19owgy74 > div > div > form > p:nth-child(1) > input[type=text]"), TimeSpan.FromSeconds(10));
        inputUser.SendKeys("Made by Layth Hammad");
        Thread.Sleep(1000);
        inputUser.Clear();
        inputUser.SendKeys("BOT49");

        IWebElement inputKey = WaitForElement(driver, By.CssSelector("#root > div > div.css-1f554t4.e19owgy74 > div > div > form > p:nth-child(2) > input[type=password]"), TimeSpan.FromSeconds(10));
        inputKey.SendKeys("Layth12+");

        IWebElement confirmButton = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[4]/div/div/form/p[3]/input"));
        confirmButton.Click();

        IWebElement aimButton = WaitForElement(driver, By.XPath("//*[@id=\"root\"]/div/div[4]/div/div/div[2]/div[2]/div/table[1]/tbody/tr[4]/td[2]/div/a[1]"), TimeSpan.FromSeconds(10));
        aimButton.Click();
        #endregion

        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(driver => driver.FindElement(By.TagName("body")).Displayed);

        Thread.Sleep(2000);


        Thread clickThread = new Thread(() => ClickLoop(driver));
        clickThread.Start();

        static IWebElement WaitForElement(IWebDriver driver, By by, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }
    }

    static void ClickLoop(IWebDriver driver)
    {
        for (int i = 0; i < 31; i++)
        {
            IWebElement elem = driver.FindElement(By.CssSelector("#root > div > div:nth-child(4) > div.css-12ibl39.e19owgy77 > div > div.desktop-only > div > div > div > div:nth-child(6)"));
            elem.Click();
        }
    }
}

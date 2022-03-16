using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create tests names
            var tests = new List<string>() { "Ideal", "Nothing","Missing Required Name","Missing Required ZipCode",
                "Missing non Required","Wrong Card Length","XSS Test", };

            //Create test inputs
            var tagNames = new List<String>{"FullName","Email","Address","City","State","Zip","CardName",
                    "CardNumber","ExpirationMonth","ExpirationYear","CVV"};

            var values = new List<List<string>>();
            values.Add(new List<string> { "John Doe", "john@doe.com", "123 S 4095 W", "Some City", "Somewhere", "84042","John Doe", "4444-1234-1234-1234", "August", "24", "685" });
            values.Add(new List<string> { "", "", "", "", "", "", "", "", "","","" });
            values.Add(new List<string> { "", "john@doe.com", "123 S 4095 W", "Some City", "Somewhere", "84042", "John Doe", "4444-1234-1234-1234", "August", "24", "685" });
            values.Add(new List<string> { "John Doe", "john@doe.com", "123 S 4095 W", "Some City", "Somewhere", "", "John Doe", "4444-1234-1234-1234", "August", "24", "685" });
            values.Add(new List<string> { "John Doe", "john@doe.com", "123 S 4095 W", "Some City", "Somewhere", "84042", "John Doe", "", "", "", "" });
            values.Add(new List<string> { "John Doe", "john@doe.com", "123 S 4095 W", "Some City", "Somewhere", "84042", "John Doe", "4444-1234-1234-12", "August", "24", "685" });
            values.Add(new List<string> { "<svg onload=alert(1)><svg>", "john@doe.com", "123 S 4095 W", "Some City", "Somewhere", "84042", "John Doe", "4444-1234-1234-1234", "August", "24", "685" });

                int t = 0;
                foreach (var v in values)
                {
                    //Create the reference for our browser
                    IWebDriver driver = new ChromeDriver();
                    //navigate to Program page
                    driver.Navigate().GoToUrl("https://localhost:5001/");
                    IWebElement addtocart = driver.FindElement(By.Name("AddToCart"));
                    addtocart.Click();
                    IWebElement checkout = driver.FindElement(By.Name("checkout"));
                    checkout.Click();
                    int i = 0;
                    foreach (var tgn in tagNames)
                    {
                        IWebElement element = driver.FindElement(By.Name(tgn));
                        // Identify value
                        var val = v[i];
                        // Do Something
                        element.SendKeys(val);
                        i++;
                    }
                    IWebElement submitorder = driver.FindElement(By.ClassName("MYbtn"));
                    try
                    {
                        submitorder.Click();
                        Console.WriteLine(tests[t]);
                        Console.WriteLine("Success");
                        driver.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(tests[t]);
                        Console.WriteLine("Failure");
                        driver.Close();
                    }
                t++;
                }
        }
    }
}

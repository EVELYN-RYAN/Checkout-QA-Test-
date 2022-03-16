using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;

namespace SeleniumFirst
{
    class Program
    {
        static async void Main(string[] args)
        {
            //Create tests names
            var tests = new List<string>() { "Ideal", "Nothing","Missing Required Name","Missing Required ZipCode",
                "Missing non Required","Wrong Card Length","XSS Test", };

            //Create test inputs
            var tagNames = new List<String>{"FullName","Email","Address","City","State","Zip","CardName",
                    "CardNumber","ExpirationMonth","ExpirationYear","CVV"};

            var values = new List<List<string>>();
            values.Add(new List<string> { "John Doe","john@doe.com", "123 S 4095 W","Some City", "Somewhere", "84042", "4444-1234-1234-1234", "August", "24", "685" });
            values.Add(new List<string> { "","", "", "", "", "", "", "", "" });
            values.Add(new List<string> { "", "john@doe.com", "123 S 4095 W", "Some City", "Somewhere", "84042", "4444-1234-1234-1234", "August", "24", "685" });
            values.Add(new List<string> { "John Doe", "john@doe.com", "123 S 4095 W", "Some City", "Somewhere", "", "4444-1234-1234-1234", "August", "24", "685" });
            values.Add(new List<string> { "John Doe", "john@doe.com", "123 S 4095 W", "Some City", "Somewhere", "84042", "", "", "", "" });
            values.Add(new List<string> { "John Doe", "john@doe.com", "123 S 4095 W", "Some City", "Somewhere", "84042", "4444-1234-1234-12", "August", "24", "685" });
            values.Add(new List<string> { "<svg onload=alert(1)><svg>", "john@doe.com", "123 S 4095 W", "Some City", "Somewhere", "84042", "4444-1234-1234-1234", "August", "24", "685" });

            //Create the reference for our browser
            IWebDriver driver = new ChromeDriver();

            foreach (var t in tests)
            {
                foreach(var v in values)
                {
                    //navigate to Program page
                    driver.Navigate().GoToUrl("https://localhost:5001/");
                    IWebElement addtocart = driver.FindElement(By.Value("CfDJ8N97rxC2o9RAkJZ_0i3wOmY7LyjlMtJMquXFz5YEbaQmgldK_cESFgpoC2xuU-HY_ZU74I1kBXkxK_DazX6XGKZsaizhnH4XFT9KtspuQi46ZGCBwzu04jqkUsmN4wCIkBcXKAD5QHxgurZPrMRWLTQ"));
                    addtocart.click();
                    IWebElement checkout = driver.FindElement(By.Name("checkout"));
                    checkout.click();
                    int i = 0;
                    foreach (var tgn in tagNames)
                    {
                            // Identify value
                            var val = v[i];
                            // Do Something
                            element.SendKeys(val);
                            i++;  
                    }
                    IWebElement submitorder = driver.FindElement(By.Class("MYbtn"));
                    try{
                            submitorder.click();
                            Console.WriteLine(t,"Success");
                        }
                    catch (Exception e){
                            Console.WriteLine(t, "Failure");
                        }
                    
                }
            }
        }
    }
}

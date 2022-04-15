using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ael2;

public class helper
{
    static string fname = "Akshat";
    static string lname = "Gadhwal";
    static string dob = "1999-12-12";
    static string gender = "Male";
    public static IWebDriver f1(IWebDriver driver){  // to get the driver of the iframe inside shadow dom
        driver.Url = "https://app.cloudqa.io/home/AutomationPracticeForm";

        IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
        IWebElement iframe = (IWebElement) jse.ExecuteScript("return document.querySelector('nestedshadow-iframe').shadowRoot.querySelector('iframe')");
        driver.SwitchTo().Frame(iframe);
        return driver;
    } 

    public static string form1_(IWebDriver driver){ // for filling a simple form
        string test_result = "failed";
        driver.FindElement(By.Id("automationtestform")).FindElement(By.Id("fname")).SendKeys(fname);
        driver.FindElement(By.Id("automationtestform")).FindElement(By.Id("lname")).SendKeys(lname);
        driver.FindElement(By.Id("automationtestform")).FindElement(By.Id("dob")).SendKeys(dob);
        driver.FindElement(By.Id("automationtestform")).FindElement(By.Id("Agree")).Click();
        driver.FindElement(By.Id("automationtestform")).FindElement(By.XPath("//button[@type='submit']")).Click();


        // validating the responses sent to the server

        string str = driver.FindElement(By.TagName("pre")).Text;
        var res = JObject.Parse(str);
        
        var res_fname =  res.ContainsKey("First Name") ? res["First Name"].ToString(): "_no_key";
        var res_lname = res.ContainsKey("Last Name") ? res["Last Name"].ToString() : "_no_key";
        var res_dob = res.ContainsKey("Date of Birth") ? res["Date of Birth"].ToString() : "_no_key";
        var res_agree = res.ContainsKey("Agree") ? res["Agree"].ToString() : "_no_key";

        if(fname == res_fname && lname == res_lname && res_dob == dob && res_agree == "Agree"){
            test_result = "passed";
        }
        
        if(test_result != "passed"){
            TestContext.Out.WriteLine(str);
        }

        return test_result;
    }

    public static string validator2(IWebDriver driver){  // response validator for the form of shadowDom of iframe-inside-shadowDom & for the form of nested shodowDom of iframe-inside-shadowDom
        string test_result = "failed";

        string str = driver.FindElement(By.TagName("pre")).Text;
        var res = JObject.Parse(str);
        var res_fname =  res.ContainsKey("fname") ? res["fname"].ToString() : "_no_key";
        var res_lname = res.ContainsKey("lname") ? res["lname"].ToString() : "_no_key";
        var res_gender = res.ContainsKey("gender") ? res["gender"].ToString() : "no_key";

        if(res_fname ==fname && res_lname == lname && res_gender == gender){
            test_result = "passed";
        }
        if(test_result != "passed"){
            TestContext.Out.WriteLine(str);
        }

        return test_result;
    }
}
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ael2;
[TestFixture]
public class Tests
{   
    IWebDriver driver;
    string fname = "Akshat";
    string lname = "Gadhwal";
    string dob = "1999-12-12";
    string gender = "Male";

    [OneTimeSetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void form1()   // form 1
    {
        driver.Url = "https://app.cloudqa.io/home/AutomationPracticeForm";
        string res = helper.form1_(driver);
        if(res == "passed"){
            Assert.Pass();
        }else{
            Assert.Fail();
        }
    }

    [Test]
    public void iframWithoutIdForm1(){    //form 2
        driver.Url = "https://app.cloudqa.io/home/AutomationPracticeForm";
        driver.SwitchTo().Frame(1);
        string res = helper.form1_(driver);
        driver.SwitchTo().DefaultContent();
        if(res == "passed"){
            Assert.Pass();
        }else{
            Assert.Fail();
        }
    }

    [Test] 
    public void iframewithoutIdform2()   // form 3
    {
        driver.Url = "https://app.cloudqa.io/home/AutomationPracticeForm";
        driver.SwitchTo().Frame(1);
        driver.SwitchTo().Frame(0);
        string res = helper.form1_(driver);
        driver.SwitchTo().DefaultContent();
        if(res == "passed"){
            Assert.Pass();
        }else{
            Assert.Fail();
        }
    }

    [Test]
    public void iframewithoutIdform3()  // form 4
    {
        driver.Url = "https://app.cloudqa.io/home/AutomationPracticeForm";
        driver.SwitchTo().Frame(1);
        driver.SwitchTo().Frame(0);
        driver.SwitchTo().Frame(0);
        string res = helper.form1_(driver);
        driver.SwitchTo().DefaultContent();
        if(res == "passed"){
            Assert.Pass();
        }else{
            Assert.Fail();
        }
    }

    [Test]
    public void iframeWithID()   // form 5
    {
        driver.Url = "https://app.cloudqa.io/home/AutomationPracticeForm";
        driver.SwitchTo().Frame(2);
        string res = helper.form1_(driver);
        driver.SwitchTo().DefaultContent();
        if(res == "passed"){
            Assert.Pass();
        }else{
            Assert.Fail();
        }
    }

    [Test]
    public void shadowDom(){  // form 6
        driver.Url = "https://app.cloudqa.io/home/AutomationPracticeForm";
        driver.FindElement(By.Id("shadowdomautomationtestform")).FindElement(By.Id("fname")).SendKeys(fname);
        driver.FindElement(By.Id("shadowdomautomationtestform")).FindElement(By.Id("lname")).SendKeys(lname);
        driver.FindElement(By.Id("shadowdomautomationtestform")).FindElement(By.Id("male")).Click();
        IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
        jse.ExecuteScript("return document.querySelector('#shadowdomautomationtestform').querySelector('s-button').shadowRoot.querySelector('button').click()");
        Assert.Pass();
    }

    [Test]
    public void NestedShadowDom(){  // form 7
        driver.Url = "https://app.cloudqa.io/home/AutomationPracticeForm";
        IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
        jse.ExecuteScript("document.querySelector('#nestedshadowdomautomationtestform').querySelector('nestedshadow-form').shadowRoot.querySelector('#fname').setAttribute('value','Akshat')");
        jse.ExecuteScript("document.querySelector('#nestedshadowdomautomationtestform').querySelector('nestedshadow-form').shadowRoot.querySelector('#lname').setAttribute('value','Gadhwal')");
        jse.ExecuteScript("document.querySelector('#nestedshadowdomautomationtestform').querySelector('nestedshadow-form').shadowRoot.querySelector('#male').click()");
        jse.ExecuteScript("document.querySelector('#nestedshadowdomautomationtestform').querySelector('s-button').shadowRoot.querySelector('button').click()");
        Assert.Pass();
    }

    [Test]
    public void IframeInsideshadowDomSimple(){   // form 8
        driver = helper.f1(driver);
        string res = helper.form1_(driver);
        if(res == "passed"){
            Assert.Pass();
        }else{
            Assert.Fail();
        }
    }

    [Test]
    public void IframeInsideshadowDomWithoutID1(){  // form 9
        driver = helper.f1(driver);
        driver.SwitchTo().Frame(1);
        string res = helper.form1_(driver);
        driver.SwitchTo().DefaultContent();
        if(res == "passed"){
            Assert.Pass();
        }else{
            Assert.Fail();
        }
    }

    [Test]
    public void IframeInsideshadowDomWithoutID2(){  // form 10
        driver = helper.f1(driver);
        driver.SwitchTo().Frame(1);
        driver.SwitchTo().Frame(0);
        string res = helper.form1_(driver);
        driver.SwitchTo().DefaultContent();
        if(res == "passed"){
            Assert.Pass();
        }else{
            Assert.Fail();
        }
    }

    [Test]
    public void IframeInsideshadowDomWithoutID3(){  // form 11
        driver = helper.f1(driver);
        driver.SwitchTo().Frame(1);
        driver.SwitchTo().Frame(0);
        driver.SwitchTo().Frame(0);
        string res = helper.form1_(driver);
        driver.SwitchTo().DefaultContent();
        if(res == "passed"){
            Assert.Pass();
        }else{
            Assert.Fail();
        }
    }

    [Test]
    public void IframeInsideshadowWithID(){  // form 12
        driver = helper.f1(driver);
        driver.SwitchTo().Frame(2);
        string res = helper.form1_(driver);
        driver.SwitchTo().DefaultContent();
        if(res == "passed"){
            Assert.Pass();
        }else{
            Assert.Fail();
        }
    }

    [Test]
    public void IframeInsideshadowShadowDom(){  // form 13
        driver = helper.f1(driver);

        driver.FindElement(By.Id("shadowdomautomationtestform")).FindElement(By.Id("fname")).SendKeys(fname);
        driver.FindElement(By.Id("shadowdomautomationtestform")).FindElement(By.Id("lname")).SendKeys(lname);
        driver.FindElement(By.Id("shadowdomautomationtestform")).FindElement(By.Id("male")).Click();
        IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
        jse.ExecuteScript("return document.querySelector('#shadowdomautomationtestform').querySelector('s-button').shadowRoot.querySelector('button').click()");

        string res = helper.validator2(driver); 
        if(res == "passed"){
            Assert.Pass();
        }else{
            Assert.Fail();
        }
    }

    [Test]
    public void IframeInsideshadowNestedShadowDom(){   // form 14
        driver = helper.f1(driver);
        IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
        jse.ExecuteScript("document.querySelector('#nestedshadowdomautomationtestform').querySelector('nestedshadow-form').shadowRoot.querySelector('#fname').setAttribute('value','Akshat')");
        jse.ExecuteScript("document.querySelector('#nestedshadowdomautomationtestform').querySelector('nestedshadow-form').shadowRoot.querySelector('#lname').setAttribute('value','Gadhwal')");
        jse.ExecuteScript("document.querySelector('#nestedshadowdomautomationtestform').querySelector('nestedshadow-form').shadowRoot.querySelector('#male').click()");
        jse.ExecuteScript("document.querySelector('#nestedshadowdomautomationtestform').querySelector('s-button').shadowRoot.querySelector('button').click()");

        string res = helper.validator2(driver);
        if(res == "passed"){
            Assert.Pass();
        }else{
            Assert.Fail();
        }
    }

    [OneTimeTearDown]
    public void Close()
    {
        driver.Close();
    }
}
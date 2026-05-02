using Reqnroll;
using System;
using Web_UI_Automation_xUnit;

namespace Web_UI_Automation_xUnit.Hooks
{
    [Binding]
    public class TestHooks
    {
        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError != null)
            {
                Console.WriteLine($"[FAILED] Тест '{scenarioContext.ScenarioInfo.Title}' завершився з помилкою!");
                Console.WriteLine($"[ERROR MESSAGE]: {scenarioContext.TestError.Message}");
                Console.WriteLine($"[STACK TRACE]: {scenarioContext.TestError.StackTrace}");
            }
            WebDriverManager.Instance.QuitDriver();
        }
    }
}
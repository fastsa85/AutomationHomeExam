using BoDi;

namespace AutomationHomeExam.StepDefinitions
{
    public abstract class BaseStepDefinitions
    {

        protected readonly IObjectContainer objectContainer;        

        protected BaseStepDefinitions(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;                        
        }
    }
}

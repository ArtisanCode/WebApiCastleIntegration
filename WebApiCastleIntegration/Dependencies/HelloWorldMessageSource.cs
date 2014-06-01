
namespace WebApiCastleIntegration.Dependencies
{
    public class HelloWorldMessageSource : IMessageSource
    {
        public string GetMessage()
        {
            return "Hello World!";
        }
    }
}
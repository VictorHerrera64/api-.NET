
    public class HelloworldService :IHelloWorldService
    {
        public string GetHelloworld()
        {
            return "hello world";
        }
    }

    public interface IHelloWorldService
    {
        string GetHelloworld();
    }

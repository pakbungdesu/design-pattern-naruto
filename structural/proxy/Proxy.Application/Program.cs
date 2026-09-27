using Ninjas;
using RealNinjas;
using ProxyNinjas;

class Program
{
        static void Main(string[] args)
        {

            RealNinja naruto = new RealNinja("Uzumaki Naruto", "Naruto123");
            Ninja shadowNaruto = new ProxyNinja("Naruto Shadow Clone", naruto, "ShadowPass");

            Ninja sasuke = new RealNinja("Uchiha Sasuke", "Sasuke123");
            sasuke.BasicToken = "WrongBasicPass";
            sasuke.AdvancedToken = "Naruto123";

            // Test 1: Wrong basic password
            Console.WriteLine("--- Test 1: Wrong Password ---");
            bool result1 = shadowNaruto.Request(sasuke);
            Console.WriteLine($"Result: {result1}\n");

            // Test 2: Correct basic password, but fail advanced password
            Console.WriteLine("--- Test 2: Correct Basic, Wrong Advanced ---");
            sasuke.BasicToken = "ShadowPass"; // Correct basic password for the proxy
            sasuke.AdvancedToken = "WrongAdvancedPass"; // Wrong advanced password for the real ninja   
            bool result2 = shadowNaruto.Request(sasuke);
            Console.WriteLine($"Result: {result2}\n");

            // Test 3: Pass both basic and advanced passwords correctly
            Console.WriteLine("--- Test 3: Correct Basic and Advanced ---");
            sasuke.AdvancedToken = "Naruto123"; // Correct advanced password for the real ninja
            bool result3 = shadowNaruto.Request(sasuke);
            Console.WriteLine($"Result: {result3}\n");
        }
}

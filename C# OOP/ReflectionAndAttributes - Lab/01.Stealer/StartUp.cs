using System.Reflection;
using System.Text;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result);

        }
    }
/*
              Type myType = typeof(Hello); // Obtained at compile time

               Type myTypeFull = Type.GetType("_01.Stealer.Hello"); // Obtained at runtime, if the name is unknown
               string fullName = typeof(Hello).FullName; //Obtain Class name
               string simpleName = typeof(Hello).Name;


               Hello hello = new Hello();
               Type baseType = hello.BaseType;
               Type[] interfaces = hello.GetInterfaces();

               var sbType = Type.GetType("System.Text.StringBuilder");
               var sb = (StringBuilder)Activator.CreateInstance(sbType);
               var sbCapacity = (StringBuilder)Activator.CreateInstance(sbType, new object[] { 10 });
            
            Type type = typeof(Hello);

            Hello helloInstance = (Hello)Activator.CreateInstance(type, new object[] { "zdr" });
            MethodInfo publicMethods = type.GetMethod("GetInterfaces", new[] {typeof(string)});
        }
    }
    public interface IHello
    {

    }
    public class Hello:IHello
    {
        private string name;
        public Hello(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        public Type BaseType { get; internal set; }

        public Type[] GetInterfaces(string name)
        {
            throw new NotImplementedException();
        }
    }
    public class Zdr : Hello
    {
        public Zdr(string name) : base(name)
        {
        }
    }
    */
}
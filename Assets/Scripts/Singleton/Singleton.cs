using System.Diagnostics;

public class Singleton<T> where T: class, new()
{
    private static T inst = null;

    public static T instance
    {
        get
        {
            if (inst == null){
                inst = new T();
                return inst;
            }
            return inst;
        }
    }
}

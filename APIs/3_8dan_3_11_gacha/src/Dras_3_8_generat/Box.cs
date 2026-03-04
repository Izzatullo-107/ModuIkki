using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dras_3_8_generat;

public class Box<T>
{
    private T _value;

    //M:1
    public void Set(T value)
    {
        _value = value;
    }

    public T Get()
    {
        return _value;
    }

    //M:2
    public T Echo(T value)
    {
        return value;
    }

    //M:3
    public T First { get; set; }
    public T Second { get; set; }
    public Box() 
    {
        _value = First;
        _value = Second;
    }

    //M:4
    public void PrintArray(T[] items)
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    //M:5
    public T Birinch(List<T> values)
    {
        return values[0];
    }

    //M:6

}

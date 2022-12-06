//ArrayList

using System.Collections;

ArrayList arrayList = new ArrayList();
arrayList.Add(15);
arrayList.Add(16);
arrayList.Add(17);


int sum = 0;

foreach (var item in arrayList)
{
    sum += (int)item;
}

Console.WriteLine(sum);




var dataStructure = new GeneriClass<int>();
dataStructure.Data = 10;

Generic<int> generic = new Generic<int>(12);
Generic<string> generic1 = new Generic<string>("generic");

public class GeneriClass<T>
{

    public T Data { get;set; } 
}


public class Generic<T>
{
    public Generic(T x)
    {
        Console.WriteLine(x);
    }
}
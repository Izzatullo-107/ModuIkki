namespace _3_9_Callekshin;

internal class Program
{
    static void Main(string[] args)
    {
        #region ArrayList
        /*
        ArrayList arrayList = new ArrayList();
        //M: 1
        arrayList.Add(2);
        arrayList.Add(3);
        arrayList.Add(5);
        arrayList.Add(7);
        arrayList.Add(11);
        
        //M: 2
        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }

        //M: 3
        Console.WriteLine(arrayList.Count);

        //M: 4
        Console.WriteLine(arrayList[3]);
       
        //M: 5
        arrayList.Add("vaaleykum assalom");
        arrayList.Add("xayr");
        arrayList.Add("nima gapalr");
        arrayList.Add("Assalomu aleykum");

        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }

        //M: 6
        Console.WriteLine(arrayList.Contains("salom"));

        //M: 7
        arrayList.Remove(5);

        //M: 8
        arrayList.Clear();

        //M: 9
        for (var i = 1; i <= 10; i++)
        {
            arrayList.Add(i);
        }

        //M: 10
        for (var i = 0; i < arrayList.Count; i++)
        {
            Console.WriteLine(arrayList[i]);
        }

        //M: 11
        var summ = 0;
        foreach (var item in arrayList)
        {
            if (item is int)
            {
                summ += (int)item;
            }
        }
        Console.WriteLine($"Summ: {summ}");

        //M: 12
        var arrayMaxInt = int.MinValue;
        foreach (var item in arrayList)
        {
            if (item is int)
            {
                arrayMaxInt = Math.Max(arrayMaxInt, (int)item);
            }
        }
        Console.WriteLine($"Max: {arrayMaxInt}");

        //M: 13

        //M: 14
        var arrayList2 = new ArrayList();
        foreach (var item in arrayList)
        {
            if (item is int && (int)item % 2 == 0)
            {
                arrayList2.Add(item);
            }
        }

        //M: 15
        var orderBy = arrayList.OfType<string>().OrderBy(s => s.Length).ToList();
        foreach (var item in orderBy)
        {
            Console.WriteLine(item);
        }

        //M: 16
        var orderByInt = arrayList.OfType<int>().OrderBy(s => s).ToList();
        var orderByString = arrayList.OfType<string>().OrderBy(s => s).ToList();
        var orderByDouble = arrayList.OfType<double>().OrderBy(s => s).ToList();

        arrayList.Clear();

        arrayList.AddRange(orderByInt);
        arrayList.AddRange(orderByString);
        arrayList.AddRange(orderByDouble);

        //M: 17
        for (var i = arrayList.Count - 1; i >= 0; i--)
        {
            Console.WriteLine(arrayList[i]);
        }

        //M: 18
        var arrayList3 = arrayList.Cast<object>().Distinct().ToList();

        arrayList.Clear();

        arrayList.AddRange(arrayList3);

        //M: 19
        arrayList.Clear();
        summ = 0;
        var value = 0;
        for (var i = 0; i < 10; i++)
        {
            value = int.Parse(Console.ReadLine());
            arrayList.Add(value);
            summ += value;
        }
        Console.WriteLine($"Summ: {summ / 10}");

        //M: 20
        arrayList.Sort();// faqat bitta tip uchun ishlaydi
        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }
        */
        #endregion

        #region LinkedList
        /*
        LinkedList<int> linkedList = new LinkedList<int>();

        //M: 21
        linkedList.AddFirst(1);
        linkedList.AddLast(2);
        linkedList.AddLast(3);
        linkedList.AddLast(4);
        linkedList.AddLast(5);

        //M: 22
        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }

        //M: 25
        linkedList.RemoveFirst();

        //M: 26
        linkedList.RemoveLast();

        //M: 28
        Console.WriteLine(linkedList.Contains(3));

        //M: 29
        foreach (var item in linkedList.Reverse())
        {
            Console.WriteLine(item);
        }

        //M: 30
        while (linkedList.Count > 0)
        {
            Console.WriteLine(linkedList.First.Value);
            linkedList.RemoveFirst();
        }

        //M: 31
        var summ = 0;
        foreach (var item in linkedList)
        {
            summ += item;
        }
        Console.WriteLine($"Summ: {summ}");

        //M: 32
        var max = int.MinValue;
        foreach (var item in linkedList)
        {
            if (max < item) max = item;
        }
        Console.WriteLine($"Max: {max}");

        //M: 33
        var min = int.MaxValue;
        foreach (var item in linkedList)
        {
            if (min > item) min = item;
        }
        Console.WriteLine($"Min: {min}");

        //M: 34
        summ = 1;
        while (summ <= 20)
        {
            linkedList.AddLast(summ);
            summ++;
        }

        foreach (var item in linkedList)
        {
            if (item % 2 == 0) Console.WriteLine(item);
        }

        //M: 35
        var linkedList2 = new LinkedList<int>();
        foreach (var item in linkedList)
        {
            linkedList2.AddLast(item);
        }

        //M: 36
        var y = 0;
        var node = (LinkedListNode<int>)null;

        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
            var x = Console.ReadLine();

            if (x.ToLower() == "ha")
            {
                y = int.Parse(Console.ReadLine());
                node = linkedList.Find(item); // Avval o'sha element turgan tugunni topamiz
                break;
            }

        }
        if (node != null)
        {
            linkedList.AddAfter(node, y); // Tugundan keyin yangi 'y' ni qo'shamiz
        }

        //M: 37
        var linkedList3 = new LinkedList<int>();
        foreach (var item in linkedList)
        {
            summ = 0;
            foreach (var subItem in linkedList)
            {

                if (item == subItem && item <2)
                {
                    linkedList3.AddLast(item);
                    summ++;
                }
            }
        }

        //M: 38
        var linkedList4 = new LinkedList<string>();
        foreach (var item in linkedList4)
        {
            if(item.Length > 5) Console.WriteLine(item);
        }

        //M: 39
        var Array = linkedList.Select(x => x).ToArray();

        //M: 40
        var sortedArray = linkedList.OrderBy(x => x).ToArray();
        */

        #endregion


    }
}

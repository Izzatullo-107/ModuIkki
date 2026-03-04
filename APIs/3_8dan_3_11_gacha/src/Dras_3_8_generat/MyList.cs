namespace Dras_3_8_generat;

public class MyList<T> : IMyList<T> where T : class, new()
{
    private T[] _nums;
    private int arrIndex = 0;
    public int Capacity
    {
        get { return _nums.Length; }
    }

    public MyList(int capacity = 4)
    {
        _nums = new T[capacity];
    }
    public bool Add(T num)
    {
        if (arrIndex >= Capacity)
        {
            DoubleCapacity();
        }

        _nums[arrIndex] = num;
        arrIndex++;

        return true;
    }

    private void DoubleCapacity()
    {
        T[] newArr = new T[Capacity * 2];
        for (var i = 0; i < Capacity; i++)
        {
            newArr[i] = _nums[i];
        }
        _nums = newArr;
    }

    public bool Contains(T num)
    {
        for (var i = 0; i < arrIndex; i++)
        {
            if (_nums[i]==num)
            {
                return true;
            }
        }
        return false;
    }

    public T GetById(int index)
    {
        return _nums[index];
    }

    public int IndexOf(T num)
    {
        for (var i = 0; i < Capacity; i++)
        {
            if (_nums[i] == num)
            {
                return i;
            }
        }

        return -1;
    }

    public bool Remove(T num)
    {
        for (var i = 0; i < Capacity; i++)
        {
            if (_nums[i] == num )
            {
                for (var j = i; j < Capacity - 1; j++)
                {
                    _nums[j] = _nums[j + 1];
                }
                --arrIndex;
                return true;
            }
        }

        return false;
    }

    public bool RemoveAll(T num)
    {
        bool removed = false;
        for (var i = 0; i < arrIndex; i++)
        {
            if (_nums[i] == num)
            {
                for (var j = i; j < arrIndex - 1; j++)
                {
                    _nums[j] = _nums[j + 1];
                }
                --arrIndex;
                removed = true;
                i--;
            }
        }
        return removed;
    }

    public bool RemoveAt(int index)
    {
        if (index < 0 || index >= arrIndex)
        {
            return false;
        }

        for (var i = index; i < arrIndex - 1; i++)
        {
            _nums[i] = _nums[i + 1];
        }
        --arrIndex;
        return true;
    }

    public void DisplayElements()
    {
        foreach (var i in _nums)
        {
            Console.Write(i + " ");
        }
    }



    
}
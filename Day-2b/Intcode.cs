using System;
using System.Runtime.CompilerServices;

namespace Day_2b
{
    class Intcode
    {
        private int _pointer;
        private readonly int[] _code;

        public Intcode(int[] code) => _code = code;

        public void Process()
        {
            while (true)
            {
                int command = ConsumeOpCode();
                int a, b, t;
                switch (command)
                {
                    case 1:
                        a = ConsumeOpCode();
                        b = ConsumeOpCode();
                        t = ConsumeOpCode();
                        _code.ExpandingSet(t, _code.ExpandingGet(a) + _code.ExpandingGet(b));
                        //_code[t] = _code[a] + _code[b];
                        break;
                    case 2:
                        a = ConsumeOpCode();
                        b = ConsumeOpCode();
                        t = ConsumeOpCode();
                        _code.ExpandingSet(t, _code.ExpandingGet(a) * _code.ExpandingGet(b));
                        //_code[t] = _code[a] * _code[b];
                        break;
                    case 99:
                        return;
                }
            }
        }

        public int PrintValue(int index) => _code[index];

        private int ConsumeOpCode() => _pointer < _code.Length ? _code[_pointer++] : 99;
    }

    public static class ArrayExtensions
    {
        public static void ExpandingSet(this int[] source, int index, int value)
        {
            if (index > source.Length) Array.Resize(ref source, index + 1);
            source[index] = value;
        }
        public static int ExpandingGet(this int[] source, int index)
        {
            if (index > source.Length) Array.Resize(ref source, index + 1);
            return source[index];
        }
    }
}

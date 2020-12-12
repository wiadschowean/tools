using System;
using System.Linq;
using System.Runtime.InteropServices;
using Math.Gmp.Native;

// Ref: https://machinecognitis.github.io/Math.Gmp.Native/html/8c8c1e55-275f-cff8-2152-883a4eaa163c.htm
namespace MPZ_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            mpz_t rop = new mpz_t();
            gmp_lib.mpz_init(rop);

            byte[] e = Convert.FromBase64String("S/0OzzzDRdsps+I85tNi4d1i3d0Eu8pimcP5SBaqTeBzcADturDYHk1QuoqdTtwX9XY1Wii6AnySpEQ9eUEETYQkTRpq9rBggIkmuFnLygujFT+SI3Z+HLDfMWlBxaPW3Exo5Yqqrzdx4Zze1dqFNC5jJRVEJByd7c6+wqiTnS4dR77mnFaPHt/9IuMhigVisptxPLJ+g9QX4ZJX8ucU6GPSVzzTmwlDIjaenh7L0bC1Uq/euTDUJjzNWnMpHLHnSz2vgxLg4Ztwi91dOpO7KjvdZQ7++nlHRE6zlMHTsnPFSwLwG1ZxnGVdFnuMjEbPA3dcTe54LxOSb2cvZKDZqA==");
            void_ptr data = gmp_lib.allocate((size_t)e.Length);
            Marshal.Copy(e, 0, data.ToIntPtr(), 256);

            gmp_lib.mpz_import(rop, 64, -1, 4, 1, 0, data);

            char_ptr value = gmp_lib.mpz_get_str(char_ptr.Zero, 16, rop);

            Console.WriteLine(value);
        }
    }
}

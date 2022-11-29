using System;
using System.Numerics;

namespace KR
{
    public static class KR
    {
		/// <summary>
		///  бинарное возведение в степень по модулю.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="p"></param>
		/// <returns></returns>
		public static int powmod(int a, int b, int p)
		{
			int res = 1;
			while (b != 0 )
				if (b % 2 != 0)
				{
					res = (int)(res * 1 * a % p);
					--b;
				}
				else
				{
					a = (int)(a * 1 * a % p);
					b >>= 1;
				}
			return res;
		}

		public static List<int> generator(int p)
		{
			List <int> fact = new ();
			List<int> result = new ();
			int phi = KR.phi(p);
			int n = phi;

			for (int i = 2; i * i <= n; ++i)
				if (n % i == 0)
				{
					fact.Add(i);
					while (n % i == 0)
						n /= i;
				}
			if (n > 1)
				fact.Add(n);

			for (int res = 2; res < p; ++res)
			{
				bool ok = true;
				for (var i = 0; i < fact.Count() && ok; ++i)
				{
					ok = powmod(res, phi / fact[i], p) != 1;
					///ok = Math.Pow(res, phi / fact[i]) % p != 1;
				}
				if (ok && IsCoprime(p, res))
				{
					result.Add(res);
				}
			}
			return result;
		}

		public static int phi(int n)
		{
			int result = n;
			for (int i = 2; i * i <= n; ++i)
				if (n % i == 0)
				{
					while (n % i == 0)
						n /= i;
					result -= result / i;
				}
			if (n > 1)
				result -= result / n;
			return result;
		}

		public static bool IsCoprime(int a, int b)
		{
			return a == b
				? a == 1
				: a > b
					? IsCoprime(a - b, b)
					: IsCoprime(b - a, a);
		}
       
        static void Main()
        {
			int p = int.Parse(Console.ReadLine());
			//int b = int.Parse(Console.ReadLine());
			foreach (var x in generator(p))
				Console.WriteLine(x);
        }
    }
}
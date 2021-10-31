using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace Mathematics
{
    public class Arithmetic
    {
        /// <summary>
        /// 約数を列挙する
        /// </summary>
        /// <param name="n">約数を求める数値</param>
        /// <returns>約数のリスト</returns>
        public static List<long> Divisor(long n)
        {
            var res = new List<long>();
            for(var i = 1L; i * i <= n; i++){
                if(n % i == 0){
                    res.Add(i);
                    if(n / i != i){
                        res.Add(n / i);
                    }
                }
            }
            res.Sort();
            return res;
        }

        /// <summary>
        /// 素数判定する
        /// </summary>
        /// <param name="n">素数か判定する数値</param>
        /// <returns>判定結果</returns>
        public static bool IsPrimeNumber(long n)
        {
            if(n == 2){
                return true;
            }
            if(n <= 1 || n % 2 == 0){
                return false;
            }
            for(var i = 3; i <= Math.Sqrt(n); i+=2){
                if(n % i == 0){
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 素数を列挙する（エラトステネスの篩）
        /// </summary>
        /// <param name="n">素数判定する最大値</param>
        /// <returns>判定結果のリスト</returns>
        public static List<bool> SieveOfEratosthenes(long n)
        {
            var prime = new bool[n + 1].Select(v => true).ToList();
            prime[0] = false;
            prime[1] = false;
            for(var i = 2; i <= n; i++){
                if(!prime[i]){
                    continue;
                }
                for(var j = i * 2; j <= n; j += i){
                    prime[j] = false;
                }
            }
            return prime;
        }

        /// <summary>
        /// ２つの整数の最小公倍数を求める
        /// </summary>
        /// <param name="a">１つ目の整数</param>
        /// <param name="b">２つ目の整数</param>
        /// <returns>最小公倍数</returns>
        public static long LCM(long a, long b)
        {
            return a * b / GCD(a, b);
        }

        /// <summary>
        /// ２つの整数の最大公約数を求める
        /// </summary>
        /// <param name="a">１つ目の整数</param>
        /// <param name="b">２つ目の整数</param>
        /// <returns>最大公約数</returns>
        public static long GCD(long a, long b)
        {
            if(a < b){
                return GCD(b, a);
            }
            while(b != 0){
                var temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        /// <summary>
        /// べき乗を求める（繰り返し二乗法）
        /// </summary>
        /// <param name="x">底</param>
        /// <param name="n">指数</param>
        /// <param name="mod">剰余</param>
        /// <returns></returns>
        public static long PowMod(long x, long n, long mod)
        {
            var res = 1L;
            while(n > 0){
                if((n & 1) == 1){
                    res = (res * x) % mod;
                }
                x = (x * x) % mod;
                n = n >> 1;
            }
            return res;
        }

        /// <summary>
        /// 階乗を求める
        /// </summary>
        /// <param name="n">最大値</param>
        /// <returns>階乗</returns>
        public static BigInteger Factorial(int n)
        {
            var res = new BigInteger(1);
            for(var i = 1; i <= n; i++){
                res *= i;
            }
            return res;
        }

        /// <summary>
        /// 等差数列の和を求める
        /// </summary>
        /// <param name="a">a1</param>
        /// <param name="b">an</param>
        /// <param name="n">数列の長さ</param>
        /// <returns>和</returns>
        public static long SumOfProgression(long a, long b, long n)
        {
            return (a + b) * n / 2;
        }
    }
}

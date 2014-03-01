using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;


namespace Xuannh.RSACore
{
    public class Rsa
    {
        private static List<Int64> _primeNumbers = new List<long>();
        private RsaKey _privateKey;
        private RsaKey _publicKey;
        private int _minValue = 1;
        private int _maxValue = 101;
        private Int64 _q, _p, _publicExponent, _privateExponent, _modulus, _euler;
        // Properties
        public static List<Int64> PrimeNumbers { get { return _primeNumbers; } }
        public RsaKey PublicKey
        {
            get { return _publicKey; }
        }
        public RsaKey PrivateKey
        {
            get { return _privateKey; }
        }
        public int MinValue { get { return _minValue; } }
        public int MaxValue { get { return _maxValue; } }
        public Int64 FistPrime {get { return _p; } }
        public Int64 SecondPrime { get { return _q; } }
        public Int64 PublicExponent { get { return _publicExponent; } }//số e
        public Int64 PrivateExponent { get { return _privateExponent; } }//số d
        public Int64 Modulus { get { return _modulus; } }//số n
        public Int64 Euler { get { return _euler; } }// euler của n

        #region contructor
        public Rsa()
        {
            if (PrimeNumbers == null || !PrimeNumbers.Any())
            {
                GeneratorPrimeNumbers(MinValue, MaxValue);
            }
            //GeneralKeys();
        }

        public Rsa(int minValue , int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            GeneratorPrimeNumbers(MinValue, MaxValue);
            GeneralKeys();
        }

        public Rsa(Int64 firstPrime, Int64 secondPrime)
        {
            if (PrimeNumbers == null || !PrimeNumbers.Any())
            {
                GeneratorPrimeNumbers(MinValue, MaxValue);
            }
            GeneralKeys(firstPrime, secondPrime);
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Tìm USCLN của 2 số a, b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static Int64 Euclid(Int64 a, Int64 b)
        {
            while (b != 0)
            {
                var r = a % b;
                a = b;
                b = r;
            }
            return a;//a là ước số chung cần tìm
        }

        //private Int64 EuclidExtended(Int64 a, Int64 b)
        //{
        //    Int64 x,x0, x1,y, y0, y1;
        //    x0 = 1;
        //    x1 = 0;
        //    y0 = 0;
        //    y1 = 1;
        //    y = 1;
        //    while (b > 0 )
        //    {
        //        var r = a%b;
        //        if (r > 0)
        //        {
        //            Int64 q = a / b;
        //            x = x0 - x1*q;
        //            y = y0 - y1*q;
        //            a = b;
        //            b = r;
        //            x0 = x1;
        //            x1 = x;
        //            y0 = y1;
        //            y1 = y;
        //        }
        //    }
        //    return b;
        //}


        private static Int64 CRT()
        {
            //Chinese Remainder Theorem - CRT - Định lý số dư trung hoa (bài toán Hàn tín điểm binh)
            Int64 result = 0;
            return result;
        }

        /// <summary>
        /// giải thuật Bình phương & Nhân tính lũy thừa n của số nguyên x
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private static Int64 PowerModulo(Int64 x, Int64 n, Int64 m)
        {
            Int64 power = 1;
            string binary = Convert.ToString(n, 2);
            foreach (var c in binary.ToArray())
            {
                power = (long)Math.Pow(power, 2) % m;
                if (c == '1')
                {
                    power = (power * x) % m;
                }
            }
            return power;
        }



        private static Int64[] ConvertStringLongs(string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            return ConvertBytesToLongs(bytes);
        }

        private static Int64[] ConvertString64ToLongs(string message)
        {
            var decMessage = Encoding.UTF8.GetString(Convert.FromBase64String(message));
            var longs = decMessage.Split(',').Select(long.Parse).ToArray();
            return longs;
        }

        private static string ConvertLongsToString(Int64[] arrLongs)
        {
            var data = new byte[arrLongs.Length * 8];
            int offset = 0;
            foreach (long value in arrLongs)
            {
                byte[] buffer = BitConverter.GetBytes(value);
                if (BitConverter.IsLittleEndian != true)
                {
                    Array.Reverse(buffer);
                }
                buffer.CopyTo(data, offset);
                offset += 8;
            }
            var byteResult = data.Where(b => b != 0).ToList();
            return Encoding.UTF8.GetString(byteResult.ToArray());
        }

        private static string ConvertLongsToString64(Int64[] arrLongs)
        {
           // var bytes = ConvertLongsToBytes(arrLongs);
            var longString = "";
            for (var i=0;i< arrLongs.Length;i++)
            {
                longString += arrLongs[i].ToString() + ((i+1) < arrLongs.Length ? "," :"");
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(longString)); 
        }

        private static byte[] ConvertLongsToBytes(long[] longs)
        {
            // convert longs to bytes
            var data = new byte[longs.Length * 8];
            int offset = 0;
            foreach (long value in longs)
            {
                byte[] buffer = BitConverter.GetBytes(value);
                if (BitConverter.IsLittleEndian != true)
                {
                    Array.Reverse(buffer);
                }
                buffer.CopyTo(data, offset);
                offset += 8;
            }
            return data.Where(b => b != 0).ToArray();
        }

        private static long[] ConvertBytesToLongs(byte[] bytes)
        {
            var arrLongs = new long[bytes.Count()];
            for (int i = 0; i < bytes.Count(); i++)
            {
                arrLongs[i] = Convert.ToInt64(bytes[i]);
            }
            return arrLongs;
        }

        #endregion

        #region public method

        public bool SetMinMaxValue(int minValue, int maxValue)
        {
            if (minValue > 0 && maxValue > 0 && minValue < maxValue)
            {
                _maxValue = maxValue;
                _minValue = minValue;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Tìm số nghịch đảo (nếu có) của a theo môđun m
        /// Giải thuật sau chỉ thực hiện với các số nguyên m>a>0 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static Int64? EuclidExtended(Int64 a, Int64 m)
        {
            Int64 y = 0; Int64 y0 = 0, y1 = 1;
            while (a > 0)
            {
                var r = m % a;
                if (r == 0)
                {
                    break;
                }
                var q = m / a;
                y = y0 - (y1 * q);
                m = a;
                a = r;
                y0 = y1;
                y1 = y;
            }
            if (a > 1) return null; //a không khả nghịch theo modul m
            return y; //Nghịch đảo modul m của a là y
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstPrime"></param>
        /// <param name="secondPrime"></param>
        /// <returns></returns>
        public static Int64 CalculatePublicModule(Int64 firstPrime, Int64 secondPrime)
        {
            return firstPrime*secondPrime;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstPrime"></param>
        /// <param name="secondPrime"></param>
        /// <returns></returns>
        public static Int64 CalculateEuler(Int64 firstPrime, Int64 secondPrime)
        {
            return (firstPrime -1) * (secondPrime -1);
        }

        /// <summary>
        /// Tính số mũ công khai trog phạm vi từ minValue tới  euler
        /// </summary>
        /// <param name="euler"></param>
        /// <param name="minValue"></param>
        /// <returns></returns>
        public static Int64 GeneralPublicExponent(Int64 euler, int? minValue)
        {
            var rnd = new Random();
            minValue = minValue ==null || minValue< 1 ? 2: minValue;
            var e = rnd.Next((int) minValue, (int)euler);
            var euclid = Euclid(e, euler);
            while (e < 1 || e > euler || euclid != 1)
            {
                e = rnd.Next((int) minValue, (int) euler);
                euclid = Euclid(e, euler);
            }
            return e;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicExponent"></param>
        /// <param name="euler"></param>
        /// <returns></returns>
        public static Int64 CalculatePrivateExponent(Int64 publicExponent, Int64 euler)
        {
            var euclidExtended = EuclidExtended(publicExponent, euler);
            return euclidExtended ?? 0;
        }

        /// <summary>
        /// Sinh PublicKey và PrivateKey
        /// </summary>
        public bool GeneralKeys()
        {
            try
            {
                _publicKey = null;
                _privateKey = null;
                var rnd = new Random();
                //2 p,q là những số nguyên tố ngâu nhiên không trùng nhau
                Int64 q = PrimeNumbers[rnd.Next(0, PrimeNumbers.Count)];
                Int64 p = PrimeNumbers[rnd.Next(0, PrimeNumbers.Count)];
                while (!IsPrimeNumber(q) && q > 0)
                {
                    q = PrimeNumbers[rnd.Next(0, PrimeNumbers.Count)];
                }

                while ((!IsPrimeNumber(p) || p == q) && p > 0)
                {
                    p = PrimeNumbers[rnd.Next(0, PrimeNumbers.Count)];
                }
                Int64 n = p * q; // module được công khai được tính theo công thức n = p*q
                Int64 euler = (p - 1) * (q - 1); // giá trị euler của n được tính theo công thức euler(n) =  (p - 1) * (q - 1)
                Int64 e = 0, d = 0; //e : số mũ công khai ; d : số mũ bí mật; 
                bool flag = false; 
                var minVal = MinValue >= euler? MinValue :2;
                while (!flag)
                {
                    e = rnd.Next(minVal, (int)euler);
                    while (e < 1 || e > euler || Euclid(e, euler) != 1)
                    {
                        e = rnd.Next(minVal, (int)euler);
                    }
                    var euclidExtended = EuclidExtended(e, euler);
                    if (euclidExtended != null)
                    {
                        d = Math.Abs((long)euclidExtended);
                        if (e!=d && (e * d) % euler == 1)
                        {
                            _publicKey = new RsaKey { Exponent = e, Modulus = n };
                            _privateKey = new RsaKey { Exponent = d, Modulus = n };
                            _p = p;
                            _q = q;
                            _modulus = n;
                            _euler = euler;
                            _privateExponent = d;
                            _publicExponent = e;
                            flag = true;
                        }
                    }
                }
                return true;
            } 
            catch(Exception ex)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Sinh PublicKey và PrivateKey với tham số truyền vào là 2 số nguyên tố (ngẫu nhiên) không trùng nhau
        /// </summary>
        /// <param name="firstPrime"></param>
        /// <param name="secondPrime"></param>
        /// <returns></returns>
        public bool GeneralKeys(Int64 firstPrime, Int64 secondPrime)
        {// Sinh PublicKey và PrivateKey với tham số truyền vào là 2 số nguyên tố (ngẫu nhiên) không trùng nhau
            try
            {
                _publicKey = null;
                _privateKey = null;
                //2 số firstPrime và secondPrime là những số nguyên tố không trùng nhau
                if (firstPrime <= 0 || !IsPrimeNumber(firstPrime) || firstPrime <= 0 || !IsPrimeNumber(firstPrime) || firstPrime == secondPrime)
                {
                    return false;
                }
                Int64 p = secondPrime;
                Int64 q = firstPrime;
                Int64 n = CalculatePublicModule(p, q); // module được công khai được tính theo công thức n = p*q
                Int64 euler = CalculateEuler(p, q);
                    // giá trị euler của n được tính theo công thức euler(n) =  (p - 1) * (q - 1)
                Int64 e = 0, d = 0; //e : số mũ công khai ; d : số mũ bí mật; 
                bool flag = false;
                while (!flag)
                {
                    e = GeneralPublicExponent(euler, MinValue);
                    var euclidExtended = EuclidExtended(e, euler);
                    if (euclidExtended != null)
                    {
                        d = Math.Abs((long) euclidExtended);

                        if ( e!=d && (e*d)%euler == 1)
                        {
                            _publicKey = new RsaKey {Exponent = e, Modulus = n};
                            _privateKey = new RsaKey {Exponent = d, Modulus = n};
                            _p = p;
                            _q = q;
                            _modulus = n;
                            _euler = euler;
                            _privateExponent = d;
                            _publicExponent = e;
                            flag = true;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isPublicKey"></param>
        /// <returns></returns>
        public string ToXmlString(bool isPublicKey )
        {
            if (_privateKey != null && _publicKey != null && _privateKey.Modulus == _publicKey.Modulus )
            {
                Int64 modulus=0, exponent=0;
                if (isPublicKey)
                {
                    modulus = _publicKey.Modulus;
                    exponent = _publicKey.Exponent;
                }
                else
                {
                    modulus = _privateKey.Modulus;
                    exponent = _privateKey.Exponent;
                }
                if(modulus>0 && exponent>0)
                {
                    return string.Format(
                    "<?xml version='1.0' encoding='utf-8' ?><RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>", modulus, exponent);
                }
            }

            return "";
        }

        /// <summary>
        /// encrypt(m) = m^e mod n
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static string Encrypt(string msg, RsaKey publicKey)
        {
            // Exponent : e ; Modulus : n
            if (publicKey.Exponent > 0 && publicKey.Modulus > 0)
            {
                var encMassage = ConvertStringLongs(msg);
                var longs = new long[encMassage.Length];
                for (var i = 0; i < encMassage.Length; i++)
                {
                     longs[i] = PowerModulo(encMassage[i], publicKey.Exponent, publicKey.Modulus); //kết quả trả về của function PowerModulo là c hay là encrypt(m)
                }
                return ConvertLongsToString64(longs);
            }
            return string.Empty;
        }

        public static byte[] Encrypt(byte[] data, RsaKey publicKey)
        {
            string result = string.Empty;
            if (publicKey.Exponent > 0 && publicKey.Modulus > 0)
            {
                var encData = ConvertBytesToLongs(data);
                var longs = new long[encData.Length];
                for (var i = 0; i < encData.Length; i++)
                {
                    var output = PowerModulo(encData[i], publicKey.Exponent, publicKey.Modulus);
                    longs[i] = output;
                }
                result = ConvertLongsToString64(longs);
            }
            return Encoding.UTF8.GetBytes(result);
        }

        /// <summary>
        /// decrypt(c)= c^d * mod n
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherText, RsaKey privateKey)
        {
            var result = "";
            // Exponent : d ; Modulus : n
            if (privateKey.Exponent >0 && privateKey.Modulus >0)
            {
               //var decMassage = ConvertStringLongs(cipherText);
                var decMassage = ConvertString64ToLongs(cipherText);
                var longs = new Int64[decMassage.Length];
                for (var i = 0; i < decMassage.Length; i++)
                {
                    var output = PowerModulo(decMassage[i], privateKey.Exponent, privateKey.Modulus); // kết quả trả về của function PowerModulo là m hay decrypt(c)
                    longs[i] =Convert.ToInt64( output);
                }

                result = ConvertLongsToString(longs);

            }
            return result;
        }

        public static byte[] Decrypt(byte[] data, RsaKey privateKey)
        {
            var result = "";
            // Exponent : d ; Modulus : n
            if (privateKey.Exponent > 0 && privateKey.Modulus > 0)
            {
                var decMassage = ConvertString64ToLongs(Encoding.UTF8.GetString(data));
                var longs = new Int64[decMassage.Length];
                for (var i = 0; i < decMassage.Length; i++)
                {
                    var output = PowerModulo(decMassage[i], privateKey.Exponent, privateKey.Modulus); // kết quả trả về của function PowerModulo là m hay decrypt(c)
                    longs[i] = Convert.ToInt64(output);
                }

                result = ConvertLongsToString(longs);

            }
            return Encoding.UTF8.GetBytes(result);
        }

        /// <summary>
        /// Kiểm tra số nguyên truyền vào có phải là số nguyên tố hay không
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPrimeNumber(Int64 number)
        {
            if (number < 0) return false;
            for (var i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        /// <summary>
        /// Tạo sẵn mảng số nguyên tố với phạm vi được cài đặt
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        public static void GeneratorPrimeNumbers(int minValue, int maxValue)
        {
            _primeNumbers = new List<Int64>();
            for (var i = minValue; i < maxValue; i++)
            {
                if (IsPrimeNumber(i))
                {
                    _primeNumbers.Add(i);
                }
            }

        }

        #endregion

    }

    public class RsaKey
    {
        public Int64 Exponent;
        public Int64 Modulus;
    }
}


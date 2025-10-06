using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB01_IT008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BAI01.exec();
            BAI02.exec();
            BAI03.exec();
            BAI04.exec();
            BAI05.exec();
            BAI06.exec();
        }
    }

    static class InputHelper
    {
        /**
         * Hàm nhập và kiểm tra tính hợp lệ của số nguyên từ người dùng
         * @param message: Câu nhắc người dùng
         * @param allowZero: Cho phép nhập số 0
         * @param allowNegative: Cho phép nhập số âm
         * @param callback: Có phải gọi đệ quy (không in message)
         * @param minAllowed: Giới hạn dưới
         * @param maxAllowed: Giới hạn trên
         * @return Số nguyên hợp lệ đã nhập
         */
        static public int ParseInput(string message, bool allowZero, bool allowNegative, bool callback = false, int minAllowed = int.MinValue, int maxAllowed = int.MaxValue)
        {
            int value = 0;
            string? input = "";
            if (!callback)
                Console.Write(message);
            input = Console.ReadLine();
            while (!int.TryParse(input ?? string.Empty, out value))
            {
                Console.WriteLine("Input khong phai la so nguyen. Hay nhap lai.\n");
                Console.Write(message);
                input = Console.ReadLine();
            }
            if (!allowZero && value == 0)
            {
                Console.WriteLine("Input khong duoc bang 0. Hay nhap lai.\n");
                Console.Write(message);
                return ParseInput(message, allowZero, allowNegative, true, minAllowed, maxAllowed);
            }
            if (!allowNegative && value < 0)
            {
                Console.WriteLine("Input khong duoc la so am. Hay nhap lai.\n");
                Console.Write(message);
                return ParseInput(message, allowZero, allowNegative, true, minAllowed, maxAllowed);
            }
            if (value < minAllowed || value > maxAllowed)
            {
                Console.WriteLine($"Input nam ngoai khoang gia tri quy dinh. Hay nhap lai trong khoang [{minAllowed}, {maxAllowed}].\n");
                Console.Write(message);
                return ParseInput(message, allowZero, allowNegative, true, minAllowed, maxAllowed);
            }
            
            return value;
        }
    }

    class MathHelper
    {
        static public bool isPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        static public bool isOdd(int n) => (n % 2 != 0);

        static public bool isSquare(int n)
        {
            int root = (int)Math.Sqrt(n);
            return (root * root == n);
        }
    }

    class Matrix
    {
        public int rows { get; private set; }
        public int cols { get; private set; }

        private int[,] data;
        private static Random rand = new Random();

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.data = new int[rows, cols];
        }

        public Matrix(int rows, int cols, int[,] data)
        {
            this.rows = rows;
            this.cols = cols;
            this.data = data;
        }

        public void Input()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    data[i, j] = InputHelper.ParseInput($"Nhap phan tu [{i},{j}]: ", true, true);
                }
            }
        }

        public void Random()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    data[i, j] = rand.Next(-100, 100);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(data[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public int minCell()
        {
            int min = data[0, 0];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (data[i, j] < min) min = data[i, j];
            return min;
        }

        public int maxCell()
        {
            int max = data[0, 0];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (data[i, j] > max) max = data[i, j];
            return max;
        }

        public int idxOfMaxCol()
        {
            int result = 0, initSum = int.MinValue;
            for (int i = 0; i < cols; i++)
            {
                int sum = 0;
                for (int j = 0; j < rows; j++)
                {
                    sum += data[j, i];
                }
                if (sum > initSum)
                {
                    initSum = sum;
                    result = i;
                }
            }
            return result;
        }

        public int idxOfMaxRow()
        {
            int result = 0, initSum = int.MinValue;
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < cols; j++)
                {
                    sum += data[i, j];
                }
                if (sum > initSum)
                {
                    initSum = sum;
                    result = i;
                }
            }
            return result;
        }

        public int sumOfNonPrimeCell()
        {
            int sum = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (!MathHelper.isPrime(data[i, j]))
                        sum += data[i, j];
            return sum;
        }

        public void deleteColByIndex(int k)
        {
            if (k < 0 || k >= cols) return;
            int[,] newData = new int[rows, cols - 1];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0, newJ = 0; j < cols; j++)
                {
                    if (j == k) continue;
                    newData[i, newJ++] = data[i, j];
                }
            }
            data = newData;
            cols--;
        }

        public void deleteRowByIndex(int k)
        {
            if (k < 0 || k >= rows) return;
            int[,] newData = new int[rows - 1, cols];
            for (int i = 0, newI = 0; i < rows; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < cols; j++)
                {
                    newData[newI, j] = data[i, j];
                }
                newI++;
            }
            data = newData;
            rows--;
        }
    }

    class Date
    {
        int day;
        int month;
        int year;

        public Date(int d, int m, int y)
        {
            day = d;
            month = m;
            year = y;
        }

        private bool IsLeapYear()
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        private int DaysInMonth(int m, int y)
        {
            int[] daysInMonth = { 31, (IsLeapYear() ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return daysInMonth[m - 1];
        }

        public bool isValid()
        {
            if (year < 0 || month < 1 || month > 12 || day < 1) return false;
            if (day > DaysInMonth(month, year)) return false;
            return true;
        }

        public string PrintStr() => $"{day}/{month}/{year}";
        public string PrintSemiStr() => $"{month}/{year}";

        public void Input()
        {
            day = InputHelper.ParseInput("Nhap ngay: ", false, false, false, 1, 31);
            month = InputHelper.ParseInput("Nhap thang: ", false, false, false, 1, 12);
            year = InputHelper.ParseInput("Nhap nam: ", false, false, false, 1);
        }

        public void SemiInput()
        {
            day = 1;
            month = InputHelper.ParseInput("Nhap thang: ", false, false, false, 1, 12);
            year = InputHelper.ParseInput("Nhap nam: ", false, false, false, 1);
        }

        public int daysInMonthCount() => DaysInMonth(month, year);

        public string dayOfWeek()
        {
            int d = day, m = month, y = year;
            if (m < 3) { m += 12; y--; }
            int k = y % 100;
            int j = y / 100;
            int f = d + (13 * (m + 1)) / 5 + k + k / 4 + j / 4 + 5 * j;
            int dayOfWeek = f % 7;
            string[] days = { "Thu 7", "Chu Nhat", "Thu 2", "Thu 3", "Thu 4", "Thu 5", "Thu 6" };
            return days[dayOfWeek];
        }
    }

    class BAI01
    {
        private static Random rand = new Random();
        
        static private int SumPrime(int[] arr, int n)
        {
            int res = 0;
            for (int i = 0; i < n; i++)
                if (MathHelper.isPrime(arr[i]))
                    res += arr[i];
            return res;
        }

        static private int CountOdd(int[] arr, int n)
        {
            int res = 0;
            for(int i = 0; i < n; i++)
                if (MathHelper.isOdd(arr[i]))
                    res++;
            return res;
        }

        static private int MinSquare(int[] arr, int n)
        {
            int min = int.MaxValue;
            bool found = false;
            for (int i = 0; i < n; i++)
                if (MathHelper.isSquare(arr[i]) && arr[i] < min)
                {
                    min = arr[i];
                    found = true;
                }
            return found ? min : -1;
        }

        static public int exec()
        {
            Console.WriteLine("\n\n============Running BAI01 subtask============");
            int n = InputHelper.ParseInput("Nhap so nguyen duong n: ", false, false);
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(1, 100);
            }

            Console.Write("Mang ngau nhien: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Tong cac so nguyen to trong mang: " + SumPrime(arr, n));
            Console.WriteLine("So luong cac so le trong mang: " + CountOdd(arr, n));
            Console.WriteLine("So nho nhat trong mang la so chinh phuong: " + MinSquare(arr, n));
            return 0;
        }
    }

    class BAI02
    {
        static private int sumPrimeLessThanN(int n)
        {
            int sum = 0;
            for (int i = 2; i < n; i++)
                if (MathHelper.isPrime(i)) sum += i;
            return sum;
        }

        static public int exec()
        {
            Console.WriteLine("\n\n============Running BAI02 subtask============");
            int n = InputHelper.ParseInput("Nhap so nguyen duong n: ", false, false);

            Console.WriteLine("Tong cac so nguyen to < n: " + sumPrimeLessThanN(n));
            return 0;
        }
    }

    class BAI03
    {
        static public int exec()
        {
            Console.WriteLine("\n\n============Running BAI03 subtask============");
            Date date = new Date(-1, -1, -1);
            date.Input();
            if (date.isValid())
            {
                Console.WriteLine("Ngay " + date.PrintStr() + " hop le.");
            }
            else
            {
                Console.WriteLine("Ngay " + date.PrintStr() + " khong hop le.");
            }
            return 0;
        }
    }

    class BAI04
    {
        static public int exec()
        {
            Console.WriteLine("\n\n============Running BAI04 subtask============");
            Date date = new Date(-1, -1, -1);
            date.SemiInput();
            if (date.isValid())
            {
                Console.WriteLine("So ngay trong thang: " + date.daysInMonthCount());
            }
            else
            {
                // This never gonna happens 
                Console.WriteLine("Thang " + date.PrintSemiStr() + " khong hop le.");
            }
            return 0;
        }
    }

    class BAI05
    {
        static public int exec()
        {
            Console.WriteLine("\n\n============Running BAI05 subtask============");
            Date date = new Date(-1, -1, -1);
            date.Input();
            if (date.isValid())
            {
                Console.WriteLine("Ngay " + date.PrintStr() + " la: " + date.dayOfWeek());
            }
            else
            {
                Console.WriteLine("Ngay " + date.PrintStr() + " khong hop le.");
            }
            return 0;
        }
    }

    class BAI06
    {
        static public int exec()
        {
            Console.WriteLine("\n\n============Running BAI06 subtask============");
            int rows = InputHelper.ParseInput("Nhap so hang: ", false, false);
            int cols = InputHelper.ParseInput("Nhap so cot: ", false, false);

            Matrix mat = new Matrix(rows, cols);
            mat.Random();

            // a
            mat.Print();

            // b
            Console.WriteLine("Phan tu nho nhat trong ma tran: " + mat.minCell());
            Console.WriteLine("Phan tu lon nhat trong ma tran: " + mat.maxCell());

            // c
            Console.WriteLine("Chi so hang (0-index) co tong lon nhat: " + mat.idxOfMaxRow());

            // d
            Console.WriteLine("Tong cac phan tu khong phai so nguyen to: " + mat.sumOfNonPrimeCell());

            // e
            int delRow = InputHelper.ParseInput($"Nhap chi so hang (0-index) can xoa, trong khoang [0, {rows - 1}]: ", true, false, false, 0, rows - 1);
            mat.deleteRowByIndex(delRow);
            mat.Print();

            // f
            Console.WriteLine("Xoa cot co tong lon nhat.");
            int delCol = mat.idxOfMaxCol();
            mat.deleteColByIndex(delCol);
            mat.Print();

            return 0;
        }
    }
}

namespace LAB02_IT008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                int option = InputHelper.ParseIntInput("\n\nChon bai tap (1-5): ", false, false, false, 1, 5);
                switch (option)
                {
                    case 1:
                        BAI1.exec();
                        break;
                    case 2:
                        BAI2.exec();
                        break;
                    case 3:
                        BAI3.exec();
                        break;
                    case 4:
                        BAI4.exec();
                        break;
                    case 5:
                        BAI5.exec();
                        break;
                    default:
                        Console.WriteLine("Bai tap khong hop le.");
                        break;
                }
            }
        }
    }
    static class InputHelper
    {
        /**
         * Hàm nhập và kiểm tra tính hợp lệ của số nguyên 32-bit từ người dùng
         * @param message: Câu nhắc người dùng
         * @param allowZero: Cho phép nhập số 0
         * @param allowNegative: Cho phép nhập số âm
         * @param callback: Có phải gọi đệ quy (không in message)
         * @param minAllowed: Giới hạn dưới
         * @param maxAllowed: Giới hạn trên
         * @return Số nguyên hợp lệ đã nhập
         */
        static public int ParseIntInput(string message, bool allowZero, bool allowNegative, bool callback = false, int minAllowed = int.MinValue, int maxAllowed = int.MaxValue)
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
                return ParseIntInput(message, allowZero, allowNegative, true, minAllowed, maxAllowed);
            }
            if (!allowNegative && value < 0)
            {
                Console.WriteLine("Input khong duoc la so am. Hay nhap lai.\n");
                Console.Write(message);
                return ParseIntInput(message, allowZero, allowNegative, true, minAllowed, maxAllowed);
            }
            if (value < minAllowed || value > maxAllowed)
            {
                Console.WriteLine($"Input nam ngoai khoang gia tri quy dinh. Hay nhap lai trong khoang [{minAllowed}, {maxAllowed}].\n");
                Console.Write(message);
                return ParseIntInput(message, allowZero, allowNegative, true, minAllowed, maxAllowed);
            }

            return value;
        }
        /**
         * Hàm nhập và kiểm tra tính hợp lệ của số nguyên 64-bit từ người dùng
         * @param message: Câu nhắc người dùng
         * @param allowNegative: Cho phép nhập số âm
         * @param callback: Có phải gọi đệ quy (không in message)
         * @return Số nguyên lớn hợp lệ đã nhập
         */
        static public long ParseLongInput(string message, bool allowNegative, bool callback = false)
        {
            long value = 0;
            string? input = "";
            if (!callback)
                Console.Write(message);
            input = Console.ReadLine();
            while (!long.TryParse(input ?? string.Empty, out value))
            {
                Console.WriteLine("Input khong phai la so nguyen lon. Hay nhap lai.\n");
                Console.Write(message);
                input = Console.ReadLine();
            }
            if (!allowNegative && value < 0L)
            {
                Console.WriteLine("Input khong duoc la so am. Hay nhap lai.\n");
                Console.Write(message);
                return ParseLongInput(message, allowNegative, true);
            }
            return value;
        }
        /**
         * Hàm nhập và kiểm tra tính hợp lệ của số thực từ người dùng
         * @param message: Câu nhắc người dùng
         * @param allowNegative: Cho phép nhập số âm
         * @param callback: Có phải gọi đệ quy (không in message)
         * @return Số thực hợp lệ đã nhập
         */
        static public double ParseDoubleInput(string message, bool allowNegative, bool callback = false)
        {
            double value = 0;
            string? input = "";
            if (!callback)
                Console.Write(message);
            input = Console.ReadLine();
            while (!double.TryParse(input ?? string.Empty, out value))
            {
                Console.WriteLine("Input khong phai la so thuc. Hay nhap lai.\n");
                Console.Write(message);
                input = Console.ReadLine();
            }
            if (!allowNegative && value < 0f)
            {
                Console.WriteLine("Input khong duoc la so am. Hay nhap lai.\n");
                Console.Write(message);
                return ParseDoubleInput(message, allowNegative, true);
            }
            return value;
        }
        /**
         * Hàm nhập và kiểm tra tính hợp lệ của chuỗi từ người dùng
         * @param message: Câu nhắc người dùng
         * @param allowEmpty: Cho phép nhập chuỗi rỗng
         * @param convertToUpperCase: Có chuyển chuỗi về chữ HOA không
         * @return Chuỗi hợp lệ đã nhập
         */
        static public string? ParseStringInput(string message, bool allowEmpty, bool convertToUpperCase)
        {
            string? input = "";
            Console.Write(message);
            input = Console.ReadLine();
            while (!allowEmpty && string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input khong duoc de trong. Hay nhap lai.\n");
                Console.Write(message);
                input = Console.ReadLine();
            }
            return convertToUpperCase ? input?.ToUpper() : input;
        }
    }
    class MathHelper
    {
        /**
         * Hàm kiểm tra số nguyên tố
         * @param n: Số cần kiểm tra
         * @return true nếu n là số nguyên tố, false nếu không phải
         */
        static public bool isPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            for (int i = 3; i * i <= n; i += 2)
                if (n % i == 0)
                    return false;
            return true;
        }
        /**
         * Hàm tính ước chung lớn nhất (GCD) của hai số nguyên
         * @param a: Số nguyên thứ nhất
         * @param b: Số nguyên thứ hai
         * @return Ước chung lớn nhất của a và b
         */
        static public int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
    class Coordinate
    {
        public int X;
        public int Y;
        public Coordinate()
        {
            this.X = 0;
            this.Y = 0;
        }
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    class Matrix
    {
        protected int Rows;
        protected int Cols;
        protected int[,] Data;
        public Matrix()
        {
            this.Rows = 0;
            this.Cols = 0;
            this.Data = new int[0, 0];
        }
        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.Data = new int[rows, cols];
        }
        public void Input()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    this.Data[i, j] = InputHelper.ParseIntInput($"Nhap phan tu [{i},{j}]: ", true, true);
                }
            }
        }
        public void Print()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    Console.Write(this.Data[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        /**
         * Hàm tìm vị trí của phần tử trong ma trận
         * @param value: Giá trị cần tìm
         * @return Tọa độ (i, j) của phần tử nếu tìm thấy, (-1, -1) nếu không tìm thấy
         */
        public Coordinate FindCellByValue(int value)
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (this.Data[i, j] == value)
                    {
                        return new Coordinate(i, j);
                    }
                }
            }
            return new Coordinate(-1, -1);
        }
        /**
         * Hàm in các phần tử nguyên tố trong ma trận cùng với vị trí của chúng
         */
        public void PrintPrimeCell()
        {
            bool found = false;
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (MathHelper.isPrime(this.Data[i, j]))
                    {
                        Console.WriteLine($"Phan tu nguyen to tai vi tri ({i},{j}): {this.Data[i, j]}");
                        found = true;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("Khong co phan tu nguyen to trong ma tran.");
            }
        }
        /**
         * Hàm tìm chỉ số dòng có nhiều phần tử nguyên tố nhất
         * @return Chỉ số dòng có nhiều phần tử nguyên tố nhất, -1 nếu không có dòng nào chứa phần tử nguyên tố
         */
        public int RowIdxWithMostPrimes()
        {
            int maxCount = 0;
            int rowIdx = -1;
            for (int i = 0; i < this.Rows; i++)
            {
                int count = 0;
                for (int j = 0; j < this.Cols; j++)
                {
                    if (MathHelper.isPrime(this.Data[i, j]))
                    {
                        count++;
                    }
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    rowIdx = i;
                }
            }
            return rowIdx;
        }
    }
    class Fraction
    {
        public int Numerator;
        public int Denominator;
        public Fraction()
        {
            this.Numerator = 0;
            this.Denominator = 1;
        }
        public Fraction(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
            if (denominator == 0)
            {
                throw new ArgumentException("Mau so khong duoc bang 0.");
            }
            this.Simplify();
        }
        public void Print()
        {
            if (this.Numerator % this.Denominator == 0)
            {
                Console.WriteLine(this.Numerator / this.Denominator);
            } else
            {
                Console.WriteLine($"{this.Numerator}/{this.Denominator}");
            }
        }
        public void Simplify()
        {
            int gcd = MathHelper.GCD(this.Numerator, this.Denominator);
            this.Numerator /= gcd;
            this.Denominator /= gcd;
            if (this.Denominator < 0)
            {
                this.Numerator = -this.Numerator;
                this.Denominator = -this.Denominator;
            }
        }
        public Fraction Add(Fraction other)
        {
            int newNumerator = this.Numerator * other.Denominator + other.Numerator * this.Denominator;
            int newDenominator = this.Denominator * other.Denominator;
            Fraction result = new Fraction(newNumerator, newDenominator);
            result.Simplify();
            return result;
        }
        public Fraction Subtract(Fraction other)
        {
            int newNumerator = this.Numerator * other.Denominator - other.Numerator * this.Denominator;
            int newDenominator = this.Denominator * other.Denominator;
            Fraction result = new Fraction(newNumerator, newDenominator);
            result.Simplify();
            return result;
        }
        public Fraction Multiply(Fraction other)
        {
            int newNumerator = this.Numerator * other.Numerator;
            int newDenominator = this.Denominator * other.Denominator;
            Fraction result = new Fraction(newNumerator, newDenominator);
            result.Simplify();
            return result;
        }
        public Fraction Divide(Fraction other)
        {
            int newNumerator = this.Numerator * other.Denominator;
            int newDenominator = this.Denominator * other.Numerator;
            Fraction result = new Fraction(newNumerator, newDenominator);
            result.Simplify();
            return result;
        }
        public bool Equals(Fraction other)
        {
            return this.Numerator == other.Numerator && this.Denominator == other.Denominator;
        }
        public bool GreaterThan(Fraction other)
        {
            return this.Numerator * other.Denominator > other.Numerator * this.Denominator;
        }
        public bool LessThan(Fraction other)
        {
            return this.Numerator * other.Denominator < other.Numerator * this.Denominator;
        }
    }
    class FractionArray
    {
        private int size;
        private Fraction[] data;
        public FractionArray(int size)
        {
            this.size = size;
            this.data = new Fraction[size];
        }
        public void Input()
        {
            for (int i = 0; i < this.size; i++)
            {
                Console.WriteLine($"Nhap phan so thu {i}:");
                int num = InputHelper.ParseIntInput("\tTu so: ", true, true);
                int denom = InputHelper.ParseIntInput("\tMau so: ", false, true);
                this.data[i] = new Fraction(num, denom);
            }
        }
        /** Hàm truy cập phần tử tại chỉ số idx
         * @param idx: Chỉ số phần tử cần truy cập
         * @return Phần tử Fraction tại chỉ số idx
         */
        public Fraction At(int idx)
        {
            return this.data[idx];
        }
        /** Hàm tìm phân số lớn nhất trong mảng
         * @return Phân số lớn nhất
         */
        public Fraction FindMax()
        {
            if (this.size == 0) return new Fraction();
            Fraction maxFrac = this.data[0];
            for (int i = 1; i < this.size; i++)
            {
                if (this.data[i].GreaterThan(maxFrac))
                {
                    maxFrac = this.data[i];
                }
            }
            return maxFrac;
        }
        /** Hàm phân hoạch mảng cho thuật toán QuickSort
         * @param low: Chỉ số bắt đầu
         * @param high: Chỉ số kết thúc
         * @return Chỉ số phân hoạch
         */
        private int Partition(int low, int high)
        {
            Fraction pivot = this.data[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (this.data[j].LessThan(pivot))
                {
                    i++;
                    Fraction temp = this.data[i];
                    this.data[i] = this.data[j];
                    this.data[j] = temp;
                }
            }
            Fraction temp1 = this.data[i + 1];
            this.data[i + 1] = this.data[high];
            this.data[high] = temp1;
            return i + 1;
        }
        /** Hàm sắp xếp mảng theo thứ tự tăng dần sử dụng thuật toán QuickSort
         * @param low: Chỉ số bắt đầu
         * @param high: Chỉ số kết thúc
         */
        private void QuickSort(int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(low, high);
                QuickSort(low, pi - 1);
                QuickSort(pi + 1, high);
            }
        }
        /** Hàm sắp xếp mảng theo thứ tự tăng dần
         */
        public void SortAsc()
        {
            QuickSort(0, this.size - 1);
        }
    }
    class BAI1
    {
        public static int exec()
        {
            Console.WriteLine("\tDang chay BAI1");
            int month = InputHelper.ParseIntInput("Nhap thang: ", false, false, false, 1, 12);
            int year = InputHelper.ParseIntInput("Nhap nam: ", false, false, false, 1, int.MaxValue);
            PrintCalendar(month, year);
            return 0;
        }
        /** Hàm in lịch tháng của một năm
         * @param month: Tháng cần in lịch
         * @param year: Năm cần in lịch
         */
        static void PrintCalendar(int month, int year)
        {
            Console.WriteLine($"\nLich thang {month}/{year}\n");
            Console.WriteLine("Sun\tMon\tTue\tWed\tThu\tFri\tSat");

            DateTime firstDay = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int startDay = (int)firstDay.DayOfWeek;
            for (int i = 0; i < startDay; i++)
            {
                Console.Write("\t");
            }
            for (int day = 1; day <= daysInMonth; day++)
            {
                Console.Write(day + "\t");
                if ((startDay + day) % 7 == 0)
                    Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
    class BAI2
    {
        static public int exec()
        {
            Console.WriteLine("\tDang chay BAI2");
            string dirPath = InputHelper.ParseStringInput("Nhap path thu muc: ", false, false) ?? "";
            if (Directory.Exists(dirPath))
            {
                string[] FilesStr = Directory.GetFiles(dirPath);
                string[] DirsStr = Directory.GetDirectories(dirPath);
                if (FilesStr.Length == 0 && DirsStr.Length == 0)
                {
                    Console.WriteLine("\tThu muc rong.");
                }
                else
                {
                    bool foundFiles = false, foundFolders = false;
                    Console.WriteLine("\tCac file trong thu muc:");
                    for(int i = 0;i < FilesStr.Length;i++)
                    {
                        Console.WriteLine($"File#{i}: {FilesStr[i]}");
                        foundFiles = true;
                    }
                    if (!foundFiles)
                    {
                        Console.WriteLine("Khong co");
                    }
                    Console.WriteLine("\n\tCac folder trong thu muc:");
                    for (int i = 0; i < DirsStr.Length; i++)
                    {
                        Console.WriteLine($"Folder#{i}: {DirsStr[i]}");
                        foundFolders = true;
                    }
                    if (!foundFolders)
                    {
                        Console.WriteLine("Khong co");
                    }
                }
            } else
            {
                Console.WriteLine("\tThu muc khong ton tai");
            }
            return 0;
        }
    }
    class BAI3
    {
        static public int exec()
        {
            Console.WriteLine("\tDang chay BAI3");
            int rows = InputHelper.ParseIntInput("Nhap so dong: ", false, false, false, 1, int.MaxValue);
            int cols = InputHelper.ParseIntInput("Nhap so cot: ", false, false, false, 1, int.MaxValue);
            Matrix matrix = new Matrix(rows, cols);
            Console.WriteLine("Nhap ma tran:");
            matrix.Input();
            Console.WriteLine("Ma tran vua nhap:");
            matrix.Print();
            int valueToFind = InputHelper.ParseIntInput("Nhap gia tri can tim: ", true, true);
            Coordinate coord = matrix.FindCellByValue(valueToFind);
            if (coord.X == -1 && coord.Y == -1)
            {
                Console.WriteLine($"Khong tim thay gia tri {valueToFind} trong ma tran.");
            }
            else
            {
                Console.WriteLine($"Tim thay gia tri {valueToFind} tai vi tri ({coord.X}, {coord.Y}).");
            }
            Console.WriteLine("Cac phan tu nguyen to trong ma tran:");
            matrix.PrintPrimeCell();
            int rowIdx = matrix.RowIdxWithMostPrimes();
            if (rowIdx == -1)
            {
                Console.WriteLine("Khong co dong nao chua phan tu nguyen to.");
            }
            else
            {
                Console.WriteLine($"Dong chua nhieu phan tu nguyen to nhat la dong thu {rowIdx}.");
            }
            return 0;
        }
    }
    class BAI4
    {
        static public int exec()
        {
            return exec_a() + exec_b();
        }
        static private int exec_a()
        {
            Console.WriteLine("\tDang chay BAI4-a");
            Console.WriteLine("Nhap phan so thu 1:");
            int num1 = InputHelper.ParseIntInput("\tTu so: ", true, true);
            int denom1 = InputHelper.ParseIntInput("\tMau so: ", false, true);
            Fraction frac1 = new Fraction(num1, denom1);
            Console.WriteLine("Nhap phan so thu 2:");
            int num2 = InputHelper.ParseIntInput("\tTu so: ", true, true);
            int denom2 = InputHelper.ParseIntInput("\tMau so: ", false, true);
            Fraction frac2 = new Fraction(num2, denom2);
            Console.Write("Phan so thu 1: ");
            frac1.Print();
            Console.Write("Phan so thu 2: ");
            frac2.Print();
            Console.Write("Tong hai phan so: ");
            Fraction sum = frac1.Add(frac2);
            sum.Print();
            Console.Write("Hieu hai phan so: ");
            Fraction diff = frac1.Subtract(frac2);
            diff.Print();
            Console.Write("Tich hai phan so: ");
            Fraction prod = frac1.Multiply(frac2);
            prod.Print();
            Console.Write("Thuong hai phan so: ");
            Fraction quot = frac1.Divide(frac2);
            quot.Print();
            return 0;
        }
        static private int exec_b()
        {
            Console.WriteLine("\n\tDang chay BAI4-b");
            int n = InputHelper.ParseIntInput("Nhap so luong phan so: ", false, false, false, 1, int.MaxValue);
            FractionArray fracArr = new FractionArray(n);
            fracArr.Input();
            Console.Write("Phan so lon nhat trong mang: ");
            Fraction maxFrac = fracArr.FindMax();
            maxFrac.Print();
            Console.WriteLine("Mang sau khi sap xep tang dan: ");
            fracArr.SortAsc();
            for (int i = 0; i < n; i++)
            {
                fracArr.At(i).Print();
            }
            return 0;
        }
    }
    class BAI5
    {
        /** Lớp cơ sở KhuDat
         */
        private class KhuDat
        {
            public int type;
            public string? location;
            public long price;
            public double area;

            public virtual void Input()
            {
                this.location = InputHelper.ParseStringInput("\t\tNhap vi tri: ", false, true);
                this.price = InputHelper.ParseLongInput("\t\tNhap gia tien: ", false);
                this.area = InputHelper.ParseDoubleInput("\t\tNhap dien tich (m2): ", false);
                this.type = 1;
            }
            public virtual void Print()
            {
                Console.WriteLine($"\t\tVi tri: {this.location}");
                Console.WriteLine($"\t\tGia tien: {this.price}");
                Console.WriteLine($"\t\tDien tich: {this.area}");
            }
        }
        /** Lớp dẫn xuất NhaPho từ KhuDat
         */
        private class NhaPho : KhuDat
        {
            public int floors;
            public int builtYear;
            public override void Input()
            {
                base.Input();
                this.floors = InputHelper.ParseIntInput("\t\tNhap so tang: ", false, false);
                this.builtYear = InputHelper.ParseIntInput("\t\tNhap nam xay dung: ", false, false);
                this.type = 2;
            }
            public override void Print()
            {
                base.Print();
                Console.WriteLine($"\t\tSo tang: {this.floors}");
                Console.WriteLine($"\t\tNam xay dung: {this.builtYear}");
            }
        }
        /** Lớp dẫn xuất ChungCu từ KhuDat
         */
        private class ChungCu : KhuDat
        {
            public int floorAt;
            public override void Input()
            {
                base.Input();
                this.floorAt = InputHelper.ParseIntInput("\t\tTang cua chung cu: ", false, false);
                this.type = 3;
            }
            public override void Print()
            {
                base.Print();
                Console.WriteLine($"\t\tTang cua chung cu: {this.floorAt}");
            }
        }
        /** Lớp KinhDoanh quản lý danh sách các khu đất
         */
        private class KinhDoanh
        {
            private int size { get; set; }
            private KhuDat[] data;
            public KinhDoanh(int size)
            {
                this.size = size;
                this.data = new KhuDat[size];
            }
            public void Input()
            {
                for (int i = 0; i < this.size; i++)
                {
                    int type = InputHelper.ParseIntInput($"\tChon loai mat hang cho khu dat {i} (1: Khu dat trong; 2: Nha pho; 3: Chung cu): ", false, false, false, 1, 3);
                    switch (type)
                    {
                        case 1:
                            this.data[i] = new KhuDat();
                            break;
                        case 2:
                            this.data[i] = new NhaPho();
                            break;
                        case 3:
                            this.data[i] = new ChungCu();
                            break;
                        default:
                            Console.WriteLine("Loai mat hang khong hop le.");
                            break;
                    }
                    this.data[i].Input();
                }
            }
            public void Print()
            {
                for (int i = 0; i < this.size; i++)
                {
                    Console.WriteLine($"\tKhu dat {i}:");
                    Console.WriteLine($"\t\tLoai khu dat: {(this.data[i].type == 1 ? "Khu dat trong" : this.data[i].type == 2 ? "Nha pho" : "Chung cu")}");
                    this.data[i].Print();
                }
            }
            /** Hàm tính tổng giá trị các khu đất theo loại
             * @param type: Loại khu đất (1: Khu dat trong; 2: Nha pho; 3: Chung cu)
             * @return Tổng giá trị các khu đất thuộc loại đã cho
             */
            public long SumPriceByType(int type)
            {
                long sum = 0;
                for (int i = 0; i < this.size; i++)
                {
                    if (type == this.data[i].type)
                        sum += this.data[i].price;
                }
                return sum;
            }
            /** Hàm in các khu đất trống có diện tích >= 100 hoặc nhà phố có diện tích >= 60 và năm xây dựng >= 2019
             */
            public void PrintKhuDatOrNhaPho()
            {
                for (int i = 0; i < this.size; i++)
                {
                    if (this.data[i].type == 1 && this.data[i].area >= 100)
                    {
                        Console.WriteLine($"\tKhu dat {i}:");
                        Console.WriteLine($"\t\tLoai khu dat: Khu dat trong");
                        this.data[i].Print();
                    }   
                    else if (this.data[i].type == 2)
                    {
                        NhaPho temp = (NhaPho)this.data[i];
                        if (temp.area >= 60 && temp.builtYear >= 2019)
                        {
                            Console.WriteLine($"\tKhu dat {i}:");
                            Console.WriteLine($"\t\tLoai khu dat: Nha pho");
                            this.data[i].Print();
                        }
                    }
                }
            }
            public void PrintNhaPhoOrChungCu(string? location, long priceLimit, double areaLimit)
            {
                bool found = false;
                for (int i = 0; i < this.size; i++)
                {
                    if (location == this.data[i].location)
                    {
                        if (this.data[i].type == 2)
                        {
                            NhaPho temp = (NhaPho)this.data[i];
                            if (temp.price <= priceLimit && temp.area >= areaLimit)
                            {
                                found = true;
                                Console.WriteLine($"\tKhu dat {i}:");
                                Console.WriteLine($"\t\tLoai khu dat: Nha pho");
                                this.data[i].Print();
                            }
                        }
                        else if (this.data[i].type == 3)
                        {
                            ChungCu temp = (ChungCu)this.data[i];
                            if (temp.price <= priceLimit && temp.area >= areaLimit)
                            {
                                found = true;
                                Console.WriteLine($"\tKhu dat {i}:");
                                Console.WriteLine($"\t\tLoai khu dat: Chung cu");
                                this.data[i].Print();
                            }
                        }
                    }
                }
                if (!found)
                {
                    Console.WriteLine("\tKhong tim thay Nha pho hay Chung cu nao phu hop.");
                }
            }
        }
        static public int exec()
        {
            Console.WriteLine("\tDang chay BAI5");
            int size = InputHelper.ParseIntInput("Nhap so luong khu dat: ", false, false, false, 1, int.MaxValue);
            KinhDoanh KD = new KinhDoanh(size);
            KD.Input();

            Console.WriteLine("Danh sach khu dat vua nhap:");
            KD.Print();

            Console.WriteLine($"Tong gia tri cac khu dat trong: {KD.SumPriceByType(1)}");
            Console.WriteLine($"Tong gia tri cac nha pho: {KD.SumPriceByType(2)}");
            Console.WriteLine($"Tong gia tri cac chung cu: {KD.SumPriceByType(3)}");

            Console.WriteLine("Cac khu dat trong co (dien tich (m2) >= 100) va cac nha pho co (dien tich (m2) >= 60 va nam xay dung >= 2019):");
            KD.PrintKhuDatOrNhaPho();

            long priceLimit = InputHelper.ParseLongInput("Nhap gioi han gia tien: ", false);
            double areaLimit = InputHelper.ParseDoubleInput("Nhap gioi han dien tich (m2): ", false);
            string? location = InputHelper.ParseStringInput("Nhap vi tri can tim: ", false, true);
            Console.WriteLine($"Cac nha pho va chung cu tai vi tri {location} co gia tien <= {priceLimit} va dien tich (m2) >= {areaLimit}:");
            KD.PrintNhaPhoOrChungCu(location, priceLimit, areaLimit);

            return 0;
        }
    }
}

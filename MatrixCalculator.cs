using System;

class MatrixCalculator
{
    static void Main()
    {
        Console.WriteLine("====================================");
        Console.WriteLine("       КАЛЬКУЛЯТОР МАТРИЦ");
        Console.WriteLine("====================================");
        
        // Основной цикл программы
        while (true)
        {
            ShowMenu();
            int choice = GetMenuChoice();
            
            // Обработка выбора пользователя
            switch (choice)
            {
                case 1:
                    CreateAndFillMatrices();
                    break;
                case 2:
                    Console.WriteLine("Выход из программы...");
                    return;
                default:
                    Console.WriteLine("Неверный выбор! Попробуйте снова.");
                    break;
            }
        }
    }
    
    // Метод для отображения главного меню
    static void ShowMenu()
    {
        Console.WriteLine("\n--- ГЛАВНОЕ МЕНЮ ---");
        Console.WriteLine("1 - Создать и заполнить матрицы");
        Console.WriteLine("2 - Выход");
        Console.Write("Выберите действие: ");
    }
    
    // Метод для получения выбора пользователя с проверкой
    static int GetMenuChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
        {
            Console.Write("Неверный ввод! Введите 1 или 2: ");
        }
        return choice;
    }
    
    // Метод для создания и заполнения матриц
    static void CreateAndFillMatrices()
    {
        Console.WriteLine("\n--- СОЗДАНИЕ МАТРИЦ ---");
        
        // Создание первой матрицы
        Console.WriteLine("\nПервая матрица:");
        int[,] matrix1 = CreateMatrix();
        
        // Создание второй матрицы
        Console.WriteLine("\nВторая матрица:");
        int[,] matrix2 = CreateMatrix();
        
        // Вывод созданных матриц
        Console.WriteLine("\n--- СОЗДАННЫЕ МАТРИЦЫ ---");
        Console.WriteLine("Первая матрица:");
        PrintMatrix(matrix1);
        Console.WriteLine("\nВторая матрица:");
        PrintMatrix(matrix2);
        
        // Меню операций с матрицами
        MatrixOperationsMenu(matrix1, matrix2);
    }
    
    // Метод для создания матрицы
    static int[,] CreateMatrix()
    {
        // Ввод размеров матрицы с проверкой
        int rows = GetPositiveInteger("Введите количество строк (n): ");
        int cols = GetPositiveInteger("Введите количество столбцов (m): ");
        
        int[,] matrix = new int[rows, cols];
        
        // Выбор способа заполнения матрицы
        Console.WriteLine("\nВыберите способ заполнения матрицы:");
        Console.WriteLine("1 - Ввод с клавиатуры");
        Console.WriteLine("2 - Заполнение случайными числами");
        
        int choice = GetIntegerInRange("Ваш выбор: ", 1, 2);
        
        // Заполнение матрицы выбранным способом
        switch (choice)
        {
            case 1:
                FillMatrixFromKeyboard(matrix);
                break;
            case 2:
                FillMatrixWithRandom(matrix);
                break;
        }
        
        return matrix;
    }
    
    // Метод для заполнения матрицы с клавиатуры
    static void FillMatrixFromKeyboard(int[,] matrix)
    {
        Console.WriteLine("\nЗаполнение матрицы с клавиатуры:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"Введите элемент [{i},{j}]: ");
                // Проверка ввода для каждого элемента
                while (!int.TryParse(Console.ReadLine(), out matrix[i, j]))
                {
                    Console.Write("Неверный ввод! Введите целое число: ");
                }
            }
        }
        Console.WriteLine("Матрица успешно заполнена!");
    }
    
    // Метод для заполнения матрицы случайными числами
    static void FillMatrixWithRandom(int[,] matrix)
    {
        Console.WriteLine("\nЗаполнение матрицы случайными числами:");
        
        // Ввод диапазона случайных чисел
        int a = GetInteger("Введите нижнюю границу диапазона (a): ");
        int b = GetInteger("Введите верхнюю границу диапазона (b): ");
        
        // Проверка корректности диапазона
        if (a > b)
        {
            Console.WriteLine("Нижняя граница больше верхней! Меняем местами...");
            int temp = a;
            a = b;
            b = temp;
        }
        
        Random random = new Random();
        
        // Заполнение матрицы случайными числами
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(a, b + 1);
            }
        }
        
        Console.WriteLine("Матрица заполнена случайными числами!");
    }
    
    // Метод для вывода матрицы на экран
    static void PrintMatrix(int[,] matrix)
    {
        if (matrix == null)
        {
            Console.WriteLine("Матрица не существует!");
            return;
        }
        
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                // Форматированный вывод элементов матрицы
                Console.Write($"{matrix[i, j],8}");
            }
            Console.WriteLine();
        }
    }
    
    // Метод для меню операций с матрицами
    static void MatrixOperationsMenu(int[,] matrix1, int[,] matrix2)
    {
        while (true)
        {
            Console.WriteLine("\n--- ОПЕРАЦИИ С МАТРИЦАМИ ---");
            Console.WriteLine("1 - Сложение матриц");
            Console.WriteLine("2 - Умножение матриц");
            Console.WriteLine("3 - Показать матрицы");
            Console.WriteLine("4 - Вернуться в главное меню");
            
            int choice = GetIntegerInRange("Выберите операцию: ", 1, 4);
            
            switch (choice)
            {
                case 1:
                    AddMatrices(matrix1, matrix2);
                    break;
                case 2:
                    MultiplyMatrices(matrix1, matrix2);
                    break;
                case 3:
                    Console.WriteLine("\nПервая матрица:");
                    PrintMatrix(matrix1);
                    Console.WriteLine("\nВторая матрица:");
                    PrintMatrix(matrix2);
                    break;
                case 4:
                    return; // Возврат в главное меню
            }
        }
    }
    
    // Метод для сложения матриц
    static void AddMatrices(int[,] matrix1, int[,] matrix2)
    {
        Console.WriteLine("\n--- СЛОЖЕНИЕ МАТРИЦ ---");
        
        // Проверка возможности сложения (одинаковые размеры)
        if (matrix1.GetLength(0) != matrix2.GetLength(0) || 
            matrix1.GetLength(1) != matrix2.GetLength(1))
        {
            Console.WriteLine("Ошибка: Матрицы имеют разные размеры!");
            Console.WriteLine($"Размер первой: {matrix1.GetLength(0)}x{matrix1.GetLength(1)}");
            Console.WriteLine($"Размер второй: {matrix2.GetLength(0)}x{matrix2.GetLength(1)}");
            Console.WriteLine("Сложение возможно только для матриц одинакового размера!");
            return;
        }
        
        // Создание результирующей матрицы
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];
        
        // Выполнение сложения
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        
        // Вывод результата
        Console.WriteLine("Результат сложения:");
        PrintMatrix(result);
    }
    
    // Метод для умножения матриц
    static void MultiplyMatrices(int[,] matrix1, int[,] matrix2)
    {
        Console.WriteLine("\n--- УМНОЖЕНИЕ МАТРИЦ ---");
        
        // Проверка возможности умножения (cols1 == rows2)
        if (matrix1.GetLength(1) != matrix2.GetLength(0))
        {
            Console.WriteLine("Ошибка: Несовместимые размеры матриц!");
            Console.WriteLine($"Размер первой: {matrix1.GetLength(0)}x{matrix1.GetLength(1)}");
            Console.WriteLine($"Размер второй: {matrix2.GetLength(0)}x{matrix2.GetLength(1)}");
            Console.WriteLine("Умножение возможно только если число столбцов первой матрицы");
            Console.WriteLine("равно числу строк второй матрицы!");
            return;
        }
        
        // Создание результирующей матрицы
        int rows = matrix1.GetLength(0);
        int cols = matrix2.GetLength(1);
        int common = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];
        
        // Выполнение умножения
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = 0; // Инициализация элемента
                for (int k = 0; k < common; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        
        // Вывод результата
        Console.WriteLine("Результат умножения:");
        PrintMatrix(result);
    }
    
    // Вспомогательный метод для получения положительного целого числа
    static int GetPositiveInteger(string message)
    {
        int number;
        Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
        {
            Console.Write("Неверный ввод! Введите положительное целое число: ");
        }
        return number;
    }
    
    // Вспомогательный метод для получения целого числа
    static int GetInteger(string message)
    {
        int number;
        Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Неверный ввод! Введите целое число: ");
        }
        return number;
    }
    
    // Вспомогательный метод для получения целого числа в заданном диапазоне
    static int GetIntegerInRange(string message, int min, int max)
    {
        int number;
        Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out number) || number < min || number > max)
        {
            Console.Write($"Неверный ввод! Введите число от {min} до {max}: ");
        }
        return number;
    }
}

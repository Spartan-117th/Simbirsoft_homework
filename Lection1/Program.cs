using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lection1
{
    class Program
    {
        static void Main(string[] args)
        {
            string n;                   //Matrix dimension          
            int index_row = 999;        //Matrix row index
            int index_col = 999;        //Matrix column index
            string[,] matrix = new string[index_row, index_col];    //Matrix
            int s = 999;                //Buffer
            bool is_row = false;        //Is a row filled?
            bool is_col = false;        //Is a column filled?
            bool is_diag = false;       //Is a diag filled?
            bool is_full = false;       //Is a matrix full?
            string value = " 0";        //Value for a cell

            Console.WriteLine("Для начала выполнения введите число от 3 до 9!");
            do
            {
                n = Console.ReadLine();
                try
                {
                    s = Convert.ToInt32(n);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Должно быть введено число от 3 до 9!");  //Filtering digits only
                }
                if ((s > 9) || (s < 3)) Console.WriteLine("Должно быть введено число от 3 до 9!");  //Filtering from 3 to 9
            }
            while ((s > 9) || (s < 3));

            for (int i = 0; i < s; i++)             //Filling up the matrix with -1s
            {
                for (int j = 0; j < s; j++)
                {
                    matrix[i, j] = "-1";
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }


            do                  //While there is no row, column or diag filled
            {
                Console.WriteLine("\nВведите индекс строки матрицы от 0 до " + (s - 1).ToString());

                do
                {
                    n = Console.ReadLine();
                    try
                    {
                        index_row = Convert.ToInt32(n);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Должно быть введено число от 0 до " + (s - 1).ToString());       //Filtering row index from 0 to s-1
                    }

                    if (index_row >= s) Console.WriteLine("Должно быть введено число от 0 до " + (s - 1).ToString()
                                                            + "\nВведите индекс строки матрицы от 0 до " + (s - 1).ToString());
                }
                while (index_row >= s);

                Console.WriteLine("\nВведите индекс столбца матрицы от 0 до " + (s - 1).ToString());

                do
                {
                    n = Console.ReadLine();
                    try
                    {
                        index_col = Convert.ToInt32(n);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Должно быть введено число от 0 до " + (s - 1).ToString());       //Filtering column index from 0 to s-1
                    }

                    if (index_col >= s) Console.WriteLine("Должно быть введено число от 0 до " + (s - 1).ToString()
                                                            + "\nВведите индекс столбца матрицы от 0 до " + (s - 1).ToString());
                }
                while (index_col >= s);

                if ((matrix[index_row, index_col] != " 0") && (matrix[index_row, index_col] != " 1"))   //If cell is not 1 or 0
                {
                    for (int i = 0; i < s; i++)                 //Writing *value* instead of -1 in the selected matrix cell
                    {
                        for (int j = 0; j < s; j++)
                        {
                            if ((i == index_row) && (j == index_col))
                            {
                                matrix[i, j] = value;
                                Console.Write(matrix[i, j]);
                            }
                            else
                            {
                                Console.Write(matrix[i, j]);
                            }
                        }
                        Console.WriteLine();
                    }
                }
                else { Console.WriteLine("Выбранная ячейка уже занята значением" + matrix[index_row, index_col].ToString()
                                            + ". Укажите другую ячейку."); continue; }

                if (value == " 0") value = " 1";
                else value = " 0";

                is_col = true;
                is_row = true;
                for (int i = 0; i < s; i++)                 //Checking if any row or column is filled with 0s
                {
                    for (int j = 0; j < s; j++)
                    {
                        if (matrix[i, j] != " 0") is_row = false;                       
                        if (matrix[j, i] != " 0") is_col = false;                                             
                    }
                    if (is_row || is_col) break;
                    else 
                    { 
                        if (i != s - 1) 
                        {
                            is_col = true;
                            is_row = true;
                        } 
                        continue; 
                    }
                }

                if (!is_col && !is_row)                         //...if not
                {
                    is_col = true;
                    is_row = true;
                    for (int i = 0; i < s; i++)                 //..checking if any row or column is filled with 1s
                    {
                        for (int j = 0; j < s; j++)
                        {
                            if (matrix[i, j] != " 1") is_row = false;
                            if (matrix[j, i] != " 1") is_col = false;
                        }
                        if (is_row || is_col) break;
                        else
                        {
                            if (i != s - 1)
                            {
                                is_col = true;
                                is_row = true;
                            }
                            continue;
                        }
                    }
                }


                is_diag = true;
                for (int i = 0; i < s; i++)                 //Checking if left-to-right diag is filled with 0s...
                {
                    if (matrix[i, i] != " 0") 
                    { 
                        is_diag = false; 
                    }
                }

                if (is_diag == false)                           //...if not...
                {
                    is_diag = true;
                    for (int i = 0; i < s; i++)                 //Checking if right-to-left diag is filled with 0s...
                    {
                        if (matrix[i, s - 1 - i] != " 0") { is_diag = false; }
                    }
                }

                is_diag = true;
                for (int i = 0; i < s; i++)                 //Checking if left-to-right diag is filled with 1s...
                {
                    if (matrix[i, i] != " 1")
                    {
                        is_diag = false;
                    }
                }

                if (is_diag == false)                           //...if not...
                {
                    is_diag = true;
                    for (int i = 0; i < s; i++)                 //Checking if right-to-left diag is filled with 1s...
                    {
                        if (matrix[i, s - 1 - i] != " 1") { is_diag = false; }
                    }
                }


                is_full = true;
                for (int i = 0; i < s; i++)                 //Checking if matrix is full
                {
                    for (int j = 0; j < s; j++)
                    {
                        if (matrix[i, j] == "-1") is_full = false;
                    }
                }

                /*is_diag = true;
                for (int i = 0; i < s; i++)                 //Checking if any diag is filled with 0s...
                {
                    if ((matrix[i, i] != " 0") && (matrix[i, s - 1 - i] != " 0")) 
                    { 
                        is_diag = false; 
                    }
                }*/
             

                /*if (is_diag == false)                           //...if not...
                {
                    is_diag = true;
                    for (int i = 0; i < s; i++)                 //Checking if any diag is filled with 1s...
                    {
                        if ((matrix[i, i] != " 1") && (matrix[i, s - 1 - i] != " 1")) { is_diag = false; }
                    }
                }*/

            }
            while (!is_col && !is_diag && !is_row && !is_full);          //While there is no row, column or diag filled

            Console.WriteLine("\nЗадание окончено!");
            if (is_col) Console.WriteLine("Заполнен столбец.");
            else if (is_diag) Console.WriteLine("Заполнена диагональ.");
            else if (is_row) Console.WriteLine("Заполнена строка.");
            else if (is_full) Console.WriteLine("Не осталось свободного места в матрице.");

            Console.Read();

            
        }
    }
}

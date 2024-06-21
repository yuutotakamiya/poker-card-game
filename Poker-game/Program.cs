using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1～4の数字を4つ入力してください");

            // 数値の入力を取得
            int[] numbers = new int[4];
            for (int i = 0; i < 4; i++)
            {
                while (true)
                {
                    Console.Write($"{i + 1}番目のカードを入力してください：");
                    if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= 4)
                    {
                        numbers[i] = num;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("1～4の間の有効な数字を入力してください。");
                    }
                }
            }
        }
    }
}

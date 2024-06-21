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
            while (true)
            {
                Console.WriteLine("0を入力すると終了します。1を入力するとゲームを開始します");
                var startInput = Console.ReadLine();

                if (startInput == "0")
                {
                    Console.WriteLine("ENTERキーを押してください。");
                    break;
                }
                else if (startInput == "1")
                {
                    PlayGame();
                }
                else
                {
                    Console.WriteLine("無効な入力です。0または1を入力してください。");
                }
            }
            Console.ReadLine();
        }

        //ポーカーゲームの処理
        static void PlayGame()
        {
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
            // 数値の出現頻度を数える
            var grouped = numbers.GroupBy(n => n).Select(g => g.Count()).ToList();

            string result;

            //入力された値の判定
            if (grouped.Contains(4))
            {
                result = "フォーカード"; // 4つの数値が同じ
            }
            else if (grouped.Contains(3))
            {
                result = "スリーカード"; // 3つの数値が同じ
            }
            else if (grouped.Count == 2 && grouped.Contains(2))
            {
                result = "ツーペア"; // 2つの数値が同じ×2
            }
            else if (grouped.Contains(2))
            {
                result = "ワンペア"; // 2つの数値が同じ
            }
            else
            {
                result = "ノーペア"; // 4つの数値が全て違う
            }

            Console.WriteLine($"判定結果: {result}");
        }
    }
}

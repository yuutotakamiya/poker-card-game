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
                string startInput = Console.ReadLine();

                //0で終了、1でゲーム開始の判定
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
            Random rnd = new Random();

            // 数値の入力を取得
            int[] numbers = new int[4];

            // ランダムにカードの値を生成
            for (int i = 0; i < 4; i++)
            {
                numbers[i] = rnd.Next(1, 14); // 1～13の間の整数をランダムに生成
            }

            Console.WriteLine($"選ばれたカード: {string.Join(", ", numbers)}");
            var grouped = numbers.GroupBy(n => n).Select(g => g.Count()).ToList();
            string result = DetermineHand(grouped);
            Console.WriteLine($"判定結果: {result}");
        }

        //ランダムで生成されたカードの
        static string DetermineHand(List<int> grouped)
        {

            //ランダムで生成された値の判定
            if (grouped.Contains(4))
            {
                return "フォーカード"; // 4つの数値が同じ
            }
            else if (grouped.Contains(3))
            {
                return "スリーカード"; // 3つの数値が同じ
            }
            else if (grouped.Count == 2 && grouped.Contains(2))
            {
                return "ツーペア"; // 2つの数値が同じ×2
            }
            else if (grouped.Contains(2))
            {
                return "ワンペア"; // 2つの数値が同じ
            }
            else
            {
                return "ノーペア"; // 4つの数値が全て違う
            }
        }
    }
}

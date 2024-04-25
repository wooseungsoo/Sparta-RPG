using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Xml.Linq;
namespace ConsoleApp3
{
    
    //enum PlayType
    //{
    //    None = 0,
    //     State= 1,
    //    Inventory = 2,
    //    Store = 3
    //}

   
    //public class SpartaDungeon
    //{
    //    public void PlayGame()
    //    {

    //        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
    //        Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
    //    }
    //}
    public class Player
    {
        public int Lv { get; set; }
        public string Chad { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }

        public Player(int lv, string chad, int attack, int defense, int hp,int gold)
        {
            Lv = lv;
            Chad= chad;
            Attack= attack;
            Defense = defense;
            Hp = hp;
            Gold= gold;

        }
    }

    class Item
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public string Feature { get; set; }
        public int Money { get; set; }
        public bool Buy { get; set; } = false;

        public Item(string name, string effect, string feature, int money)
        {
            Name = name;
            Effect = effect;
            Feature = feature;
            Money = money;
            

        }

        
    }
    

    internal class Program
    {
        static Player player = new Player(1, "전사", 10, 5, 100, 1500);

        static Item[] Items = new Item[]
        {
            new Item("|수련자 갑옷|", "|방어력 +5|", "|수련에 도움을 주는 갑옷입니다|.", 1000),
             new Item("|무쇠 갑옷|", "|방어력 +9|", "|무쇠로 만들어져 튼튼한 갑옷입니다|.", 2000),
              new Item("|스파르타의 갑옷|", "|방어력 +15|", "|스파르타의 전사들이 사용했다는 전설의 갑옷입니다|.", 3500),
               new Item("|낡은 검|", "|공격력 +2|", "|수련에 도움을 주는 갑옷입니다|.", 600),
                new Item("|청동 도끼|", "|공격력 +5|", "|수련에 도움을 주는 갑옷입니다|.", 1500),
                 new Item("|스파르타의 창|", "|공격력 +7|", "|수련에 도움을 주는 갑옷입니다|.", 3500)
        };
        static Item[] InventoryItems = new Item[]
        {

        };
       static void Equip()
        {
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < InventoryItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}{InventoryItems[i].Name}{InventoryItems[i].Effect}{InventoryItems[i].Feature}{InventoryItems[i].Money}");
            }
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    State();
                    break;
                case "2":
                    Inventory();
                    break;
                case "3":
                    Store();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    ChoosePlay();
                    break;
            }
        }
        static void State()
        {
           

            Console.Clear();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv: ({player.Lv})");
            Console.WriteLine($"Chad {player.Chad}");
            Console.WriteLine($"공격력: {player.Attack}");
            Console.WriteLine($"방여력: {player.Defense}");
            Console.WriteLine($"체력: {player.Hp}");
            Console.WriteLine($"Gold: {player.Gold}G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            string input=Console.ReadLine();
            if(input=="0")
            {
                ChoosePlay();
            }
            else
            {
                State();
            }
        }
        static void Inventory()
        {

            Console.Clear();
            Console.WriteLine("보유중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요");
            string input = Console.ReadLine();
            switch (input)
            {
                case "0":
                    Equip();//장착 관리
                    break;
                case "1":
                    State();
                    break;
                
                default:
                    Console.WriteLine("0,1번중에 골라주세요");
                    Inventory();
                    break;
            }
        }
        static void Store()
        {
            //Player player = new Player(1, "전사", 10, 5, 100, 1500);
            Console.Clear();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
         
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold}G");

            for(int i=0;i<Items.Length;i++)
            {
                Console.WriteLine($"{i+1}{Items[i].Name}{Items[i].Effect}{Items[i].Feature}{Items[i].Money}");
            }
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    State();
                    break;
                case "1":
                    if (Items[0].Money<= player.Gold)
                    {
                        player.Gold -= Items[0].Money;
                       // Items[0] = InventoryItems[0];
                        Console.WriteLine("구매를 완료했습니다.");
                        Store();
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다");
                        Store();
                    }
                    break;
                case "2":
                    if (Items[1].Money <= player.Gold)
                    {
                        player.Gold -= Items[1].Money;
                        Console.WriteLine("구매를 완료했습니다.");
                        Store();
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다");
                        Store();
                    }
                    break;
                case "3":
                    if (Items[2].Money <= player.Gold)
                    {
                        player.Gold -= Items[2].Money;
                        Console.WriteLine("구매를 완료했습니다.");
                        Store();
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다");
                        Store();
                    }
                    break;
                case "4":
                    if (Items[3].Money <= player.Gold)
                    {
                        player.Gold -= Items[3].Money;
                        Console.WriteLine("구매를 완료했습니다.");
                        Store();
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다");
                        Store();
                    }
                    break;
                case "5":
                    if (Items[4].Money <= player.Gold)
                    {
                        player.Gold -= Items[4].Money;
                        Console.WriteLine("구매를 완료했습니다.");
                        Store();
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다");
                        Store();
                    }
                    break;
                case "6":
                    if (Items[5].Money <= player.Gold)
                    {
                        player.Gold -= Items[5].Money;
                        Console.WriteLine("구매를 완료했습니다.");
                        Store();
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다");
                        Store();
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Store();
                    break;
            }


        }
        static void ChoosePlay()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

           // PlayType choice = PlayType.None;
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    State();
                    break;
                case "2":
                    Inventory();
                    break;
                case "3":
                    Store();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    ChoosePlay();
                    break;
            }
            

        }
        static void Main(string[] args)
        {
            
            ChoosePlay();
        }
    }
}

using AoC1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC1.Calculations
{
    public class Day4
    {
        private static List<Board> boards = new();
        private static List<int> balls = new();

        public static void Calculate()
        {
            balls = InputDay4.balls.Split(',').Select(x => int.Parse(x)).ToList();
            string[] boardInput = InputDay4.boards.Split("\r\n\r\n");
            ParseInput(boardInput);
            Winner winner = PullBalls(boards);
            Board winningBoard = boards[winner.BoardNum];
            int sum = 0;
            foreach (BoardItem item in winningBoard.State)
            {
                if (!item.WasCalled) sum += item.Value;
            }
            Console.WriteLine(sum * winner.BallNum);

/*
            List<Board> part2List = boards;
            while (true)
            {
                Winner winner2 = PullBalls(part2List);
                part2List[winner2.BoardNum].IsWinner = true;
                if (part2List.Where(x => x.IsWinner == false).ToList().Count() == 1)
                {
                    break;
                }
            }
            int index = part2List.FindIndex(x => x.IsWinner);
            Winner lastWiner = PullBalls(part2List.Where(x => !x.IsWinner).ToList());
            int sum2 = 0;
            foreach (BoardItem item in part2List[index].State)
            {
                if (!item.WasCalled) sum2 += item.Value;
            }
            Console.WriteLine(sum * lastWiner.BallNum);*/
        }


        private static Winner PullBalls(List<Board> boards)
        {
            Winner winner = new();
            foreach (int ball in balls)
            {
                foreach (Board board in boards)
                {
                    foreach (BoardItem item in board.State)
                    {

                        if (item.Value == ball)
                        {
                            item.WasCalled = true;
                            int winningBoard = CheckForWinners();
                            if (winningBoard > -1)
                            {
                                winner.BoardNum = winningBoard;
                                winner.BallNum = ball;
                                return winner;
                            }
                        }
                    }
                }
            }
            return winner;
        }

        private static int CheckForWinners()
        {
            for(int i = 0; i < boards.Count; i++)
            {
                Board board = boards[i];
                for(int x = 0; x<5; x++) //check rows
                {
                    int numXFound = 0;
   
                    for(int y = 0; y < 5; y++)
                    {
                        if(board.State[x,y].WasCalled == true)
                        {
                            numXFound++;
                        }
                    }
                    if(numXFound == 5)
                    {
                        return i;
                    }
                }
                for (int y = 0; y < 5; y++) //check cols
                {
                    int numYFound = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        if (board.State[x, y].WasCalled == true)
                        {
                            numYFound++;
                        }
                    }
                    if (numYFound == 5)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private static void ParseInput(string[] boardInput)
        {
            foreach (string boardString in boardInput)
            {
                Board board = new Board();
                string[] rows = boardString.Split("\r\n");
                int depth = 0;
                foreach (string row in rows)
                {
                    List<int> numsInRow = new();
                    string[] nums = row.Split(" ");
                    foreach (string s in nums)
                    {
                        if (s != String.Empty) numsInRow.Add(int.Parse(s));
                    }
                    board.AddRow(numsInRow, depth);
                    depth++;
                }
                boards.Add(board);
            }
        }
    }

    public class Board
    {
        public BoardItem[,] State { get; set; } = new BoardItem[5, 5];
        public bool IsWinner = false;
        public void AddRow(List<int> row, int depth)
        {
            for (int i = 0; i < 5; i++)
            {
                BoardItem item = new BoardItem() { Value = row[i] };
                State[depth, i] = item;
            }
        }
    }

    public class BoardItem
    {
        public int Value { get; set; }
        public bool WasCalled { get; set; } = false;
    }

    public class Winner
    {
        public int BoardNum { get; set; } = -1;
        public int BallNum { get; set; } = -1;
    }
}

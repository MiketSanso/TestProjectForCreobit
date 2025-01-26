using System.Collections.Generic;

namespace SecondGame
{
    public class SearchPeaks
    {
        public static GameCard[] AssigningTopCards(int countTriangles, int col, int row, List<GameCard> cardList, int maxCountRows)
        {
            GameCard[] upCards = new GameCard[2];

            if (row != 0)
            {
                for (int i = 1; i <= countTriangles; i++)
                {
                    if (col < row * i + i)
                    {
                        if (col - 1 >= row * (i - 1) + (i - 1) || row == 3 && (col == 4 || col == 8))
                        {
                            if (row == maxCountRows - 1)
                            {
                                upCards[0] = cardList[SearchingIndexObjectInTriangle(row - 1, col - 1)];
                            }
                            else
                                upCards[0] = cardList[SearchingIndexObjectInTriangle(row - 1, col - i)];
                        }

                        if (row == maxCountRows - 1 && i < countTriangles || col + 1 <= row * i + i - 1 && row != maxCountRows - 1 || col <= (row) * (row) - 1)
                        {
                            if (row == maxCountRows - 1)
                            {
                                upCards[1] = cardList[SearchingIndexObjectInTriangle(row - 1, col)];
                            }
                            else
                                upCards[1] = cardList[SearchingIndexObjectInTriangle(row - 1, col - (i - 1))];
                        }
                        return upCards;
                    }
                }
            }

            return null;
        }

        private static int SearchingIndexObjectInTriangle(int row, int col)
        {
            int numberCard = 0;
            for (int i = 0; i < row + 1; i++)
            {
                if (i == row)
                {
                    numberCard += col;
                    return numberCard;
                }

                numberCard += (i + 1) * 3;
            }

            return numberCard;
        }
    }
}

namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            coins = coins.OrderByDescending(c => c).ToList();

            var result = new Dictionary<int, int>();
            int currentSum = 0;
            int coinIndex = 0;

            while (coinIndex < coins.Count && currentSum != targetSum)
            {
                var currentCointValue = coins[coinIndex];

                if (currentSum + currentCointValue > targetSum)
                {
                    coinIndex++;
                    continue;
                }

                var remainingSum = targetSum - currentSum;

                var coinsToTake = remainingSum / currentCointValue;

                currentSum += coinsToTake * currentCointValue;

                result[currentCointValue] = coinsToTake;
            }

            if (currentSum < targetSum)
            {
                throw new InvalidOperationException("Sorry");
            }

            return result;
        }
    }
}
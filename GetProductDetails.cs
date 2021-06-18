using System.Collections.Generic;

namespace Assignment1
{
    public class GetProductDetails
    {
        #region Variables
        int countOfA = 0;
        int priceOfA = 50;
        int countOfB = 0;
        int priceOfB = 30;
        int countOfC = 0;
        int priceOfC = 20;
        int countOfD = 0;
        int priceOfD = 15;

        int promotionalCountofA = 0;
        int promotionalCountofB = 0;
        int promotionalCountofC = 0;

        int promotionalValueofA = 0;
        int promotionalValueofB = 0;
        int promotionalValueofC_D = 0;
        #endregion

        #region Methods
        public List<ActivePromotions> GetActivePromotions()
        {
            List<ActivePromotions> activePromotions = new List<ActivePromotions>
            {
                new ActivePromotions{UNIT="A", Count=3, PromotionalValue=130},
                new ActivePromotions{UNIT="B", Count=2, PromotionalValue=45},
                new ActivePromotions{UNIT="C & D", Count=1, PromotionalValue=30}
            };
            return activePromotions;
        }

        public int GetTotalPrice(List<Product> products)
        {

            List<ActivePromotions> abc = new List<ActivePromotions>();
            abc = GetActivePromotions();
            foreach (var items in abc)
            {
                switch (items.UNIT.ToUpper())
                {
                    case "A":
                        promotionalCountofA = items.Count;
                        promotionalValueofA = items.PromotionalValue;
                        break;
                    case "B":
                        promotionalCountofB = items.Count;
                        promotionalValueofB = items.PromotionalValue;
                        break;
                    case "C & D":
                        promotionalCountofC = items.Count;
                        promotionalValueofC_D = items.PromotionalValue;
                        break;
                }
            }

            foreach (Product product in products)
            {

                switch (product.UNIT.ToUpper())
                {
                    case "A":
                        countOfA += 1;
                        break;
                    case "B":
                        countOfB += 1;
                        break;
                    case "C":
                        countOfC += 1;
                        break;
                    case "D":
                        countOfD += 1;
                        break;
                }
            }
            int totalPriceOfA = (countOfA / promotionalCountofA) * promotionalValueofA + (countOfA % promotionalCountofA * priceOfA);
            int totalPriceOfB = (countOfB / promotionalCountofB) * promotionalValueofB + (countOfB % promotionalCountofB * priceOfB);
            int priceofc_D = 0;
            if (countOfC == 0 || countOfD == 0)
            {
                int totalPriceOfC = (countOfC * priceOfC);
                int totalPriceOfD = (countOfD * priceOfD);
                priceofc_D = totalPriceOfC + totalPriceOfD;
            }
            else
            {
                if (countOfC == countOfD)
                {
                    priceofc_D = countOfC * promotionalValueofC_D;
                }
                else if (countOfC > countOfD)
                {
                    priceofc_D = (countOfC - countOfD) * priceOfC + countOfD * promotionalValueofC_D;
                }
                else if (countOfC < countOfD)
                {
                    priceofc_D = (countOfD - countOfC) * priceOfD + countOfC * promotionalValueofC_D;
                }
            }

            int TotalPrice = totalPriceOfA + totalPriceOfB + priceofc_D;
            return TotalPrice;

        }
        #endregion
    }
}

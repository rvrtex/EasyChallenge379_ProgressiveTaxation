using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyChallenge379_ProgressiveTaxation
{
    class FindTaxesOwed
    {
        public int findTaxesOwed(int income)
        {
            int taxableIncome = (int)income;
            int taxesOwed = 0;
            if (taxableIncome == 0)
            {
                return 0;
            }
            else
            {
                var taxBrackets = getTaxBrackets();
                for (int i = 0; i < taxBrackets.Count; i++)
                {
                    var currentTax = taxBrackets.ElementAt(i);

                    if (taxableIncome >= currentTax.Value)
                    {
                        if (i != 0 && i + 1 < taxBrackets.Count)
                        {
                            taxesOwed += (int)((currentTax.Value - taxBrackets.ElementAt(i - 1).Value) * currentTax.Key);
                        }
                        else if (i == 0)
                        {
                            taxesOwed += (int)(currentTax.Value * currentTax.Key);
                        }
                        else if ((i + 1) >= taxBrackets.Count)
                        {
                            taxesOwed += (int)((taxableIncome - currentTax.Value) * currentTax.Key);
                        }

                    }
                    else
                    {
                        if (i != 0)
                        {
                            if (taxableIncome > taxBrackets.ElementAt(i - 1).Value)
                            {
                                taxesOwed += (int)((taxableIncome - taxBrackets.ElementAt(i - 1).Value) * currentTax.Key);
                            }
                        }
                        else
                        {
                            //TODO:throw exception that there are not enough tax brackets.
                        }
                    }
                }

            }
            return taxesOwed;

        }
        public Dictionary<double, int> getTaxBrackets()
        {
            Dictionary<double, int> taxBrackets = new Dictionary<double, int>() { { 0.00, 10000 }, { 0.10, 30000 }, { 0.25, 100000 }, { 0.40, 100000 } };

            return taxBrackets;
        }

    }
}


        /*
         * if (taxableIncome >= currentTax.Value)
                            {
                                if ((i + 1) != taxBrackets.Count)
                                {
                                    if (taxableIncome >= taxBrackets.ElementAt(i + 1).Value)
                                    {
                                        if (currentTax.Key != 0.0 && i !=0 ) {
                                            taxesOwed += (int)((currentTax.Value - taxBrackets.ElementAt(i - 1).Value) * currentTax.Key);
                                        }
                                        else
                                        {
                                            taxesOwed += (int)(currentTax.Value * currentTax.Key);
                                        }
                                    }
                                    else
                                    {
                                        if(i != 0)
                                        {
                                            taxesOwed += (int)((taxableIncome - currentTax.Value) * taxBrackets.ElementAt(i + 1).Key);

                                        }
                                        else
                                        {
                                            if ((i + 1) != taxBrackets.Count)
                                            {
                                                taxesOwed += (int)((taxableIncome - currentTax.Value) * taxBrackets.ElementAt(i + 1).Key);
                                            }
                                            else
                                            {
                                                //TODO:throw exception that there are not enough tax brackets.
                                            }

                                        }
                                    }
                                }
                                else
                                {
                                    taxesOwed += (int)((taxableIncome - currentTax.Value) * currentTax.Key);
                                }
        */


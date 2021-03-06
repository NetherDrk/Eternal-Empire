using Assets.Plugins;

namespace Assets.Singletons_Scripts
{
    public class NumberSuffixes : Singleton<NumberSuffixes> {
	
        public string[] Suffixes;
        public bool ScientificNotation;

        public string AddSuffixes (double number) {
            if (number < 1000) {
                return number.ToString ("N0");
            }
            else {
                if (ScientificNotation) {
                    return number.ToString ("E3");
                } else {
                    double newNumber = number;
                    int i = 0;
                    while (newNumber >= 1000) {
                        newNumber /= 1000;
                        i++;
                    }
                    if (i >= Suffixes.Length) {
                        return number.ToString ("E3");
                    } else {
                        return newNumber.ToString ("N2") + " " + Suffixes [i];
                    }
                }
            }
        }
    }
}

using System;

namespace klatalog
{
    class Item
    {
        public string Name { get; }
        public double WeightKg { get; }
        public int WeirdnessLevel { get; }
        public bool IsDelicate { get; }

        public Item(string name, double weightKg, int weirdnessLevel, bool isDelicate)
        {
            Name = name;
            WeightKg = Math.Round(weightKg, 3);
            WeirdnessLevel = weirdnessLevel;
            IsDelicate = isDelicate;
        }

        public string Description()
        {
            return $"{{\n\t\"nazwa\": \"{Name}\",\n\t\"waga_kg\": {WeightKg:F3},\n\t\"poziom_dziwnosci\": {WeirdnessLevel},\n\t\"czy_delikatny\": {(IsDelicate ? "TAK" : "NIE")}\n}}";
        }
    }
}

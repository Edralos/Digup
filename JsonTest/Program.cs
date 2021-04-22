using Assets.Characters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace JsonTest
{
    class Program
    {
        private static Dictionary<string, Ally> Roaster;
        private static Dictionary<string, Ennemy> Foes;
        private static Dictionary<string, ActiveItem> ActiveEquipments;
        private static Dictionary<string, TrinketItem> Trinkets;
        private static Dictionary<string, ConsumableItem> Consumables;
        static void Main(string[] args)
        {
            Roaster = new Dictionary<string, Ally>()
            {
                {"Herborist", new Ally("Herborist", 40, 10, 20, 0, 90, 15) },
                {"Captain", new Ally("Captain", 60, 15, 20, 0, 80, 10) },
            };

            Foes = new Dictionary<string, Ennemy>()
            {
                {"Rat soldier", new Ennemy("Rat Soldier",  20, 5, 10, 0, 80, 9,"Tunnels") },
                {"Squarab", new Ennemy("Squarab", 10, 5, 15, 0, 19, 19, "Tunnels") },
            };

            ActiveEquipments = new Dictionary<string, ActiveItem>()
            {
                {"Flower", new ActiveItem("Flower", "Heals 7% of your life total", "Something to give to a loved one when you get back home, either in their hand or on their grave", EquipmentType.NULL,
                new Effect(TargetType.SELF, new List<EffectType>{EffectType.LIFE }, new List<int>(){7 } )) },
                //fourre tout
                {"Thingy", new ActiveItem("Thingy", "???", "A strange object, who knows what it does", EquipmentType.NULL,
                    new Effect(
                        TargetType.ALL_FOES,
                        new List<EffectType>{EffectType.LIFE, EffectType.CHARACTERSTAT, EffectType.STATUS },
                        new List<int>()
                        {
                                7,
                                -7
                        },
                        new Dictionary<StatusType, int>()
                        {
                            {StatusType.BLEED, 6 },
                            {StatusType.POISON, 8 },
                        },
                        new Dictionary<CharacterStatType, int>()
                        {
                            {CharacterStatType.DODGE, 9},
                            {CharacterStatType.MAX_HP, -3 }
                        }
                    )
                ) },
                
            };

            Trinkets = new Dictionary<string, TrinketItem>()
            {
                {"Trinketo", new TrinketItem("Trinketo", "???", "It fills you with power, but of what kind?", EquipmentType.NULL,
                    new Effect(
                        TargetType.ALL_FOES,
                        new List<EffectType>{ EffectType.CHARACTERSTAT },
                        null,
                        null,
                        new Dictionary<CharacterStatType, int>()
                        {
                            {CharacterStatType.DODGE, 9},
                            {CharacterStatType.MAX_HP, -3 }
                        }
                    )
                ) }
            };

            Consumables = new Dictionary<string, ConsumableItem>()
            {

                {
                    "ThingyConsume", new ConsumableItem("Thingy", "???", "A strange object, who knows what it does, this one you eat or drink or whatever",
                    new Effect(
                        TargetType.ALL_FOES,
                        new List<EffectType>{EffectType.LIFE, EffectType.CHARACTERSTAT, EffectType.STATUS },
                        new List<int>()
                        {
                                7,
                                -7
                        },
                        new Dictionary<StatusType, int>()
                        {
                            {StatusType.BLEED, 6 },
                            {StatusType.POISON, 8 },
                        },
                        new Dictionary<CharacterStatType, int>()
                        {
                            {CharacterStatType.DODGE, 9},
                            {CharacterStatType.MAX_HP, -3 }
                        }
                        )
                    )
                },
                {"Potion", new ConsumableItem("Potion","Heals 5% of your life total", "A fresh brew from the best herborist of the caves",
                new Effect (TargetType.SELF, new List<EffectType>(){EffectType.LIFE}, new List<int>(){5}
                )) }
            };

            string strRoaster = JsonConvert.SerializeObject(Roaster, Formatting.Indented);
            string strFoes = JsonConvert.SerializeObject(Foes, Formatting.Indented);
            string strConsume = JsonConvert.SerializeObject(Consumables, Formatting.Indented);
            string strEquip = JsonConvert.SerializeObject(ActiveEquipments, Formatting.Indented);
            string strTrink = JsonConvert.SerializeObject(Trinkets, Formatting.Indented);

            File.WriteAllText(@"Roaster.json", strRoaster);
            File.WriteAllText(@"Ennemies.json", strFoes);
            File.WriteAllText(@"ActiveEquipments.json", strEquip);
            File.WriteAllText(@"Consumables.json", strConsume);
            File.WriteAllText(@"Trinkets.json", strTrink);

        }
    }
}

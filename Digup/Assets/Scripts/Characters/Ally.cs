using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Characters
{
    public class Ally : Character
    {
        public List<ConsumableItem> ConsumableBelt { get; protected set; } = new List<ConsumableItem>();
        public List<EquipmentItem> Equipment { get; protected set; } = new List<EquipmentItem>();
        public int MaxEquipmentSlots;
        public int UnlockedSlots;
        public int BeltSize;
        public Ally(string name, int maxHP, int prot, int dodge, int atkMods, int acc, int speed, int maxSlots, int unlockedSlots, int beltSize) : base(name, maxHP, prot, dodge, atkMods, acc, speed)
        {
            MaxEquipmentSlots = maxSlots;
            UnlockedSlots = unlockedSlots;
            BeltSize = beltSize;
        }


        public bool AddEquipment(EquipmentItem equipment)
        {
            if (equipment is ActiveItem active)
            {
                if (Equipment.Where( a => a.EquipmentType == active.EquipmentType && a.EquipmentType != EquipmentType.NULL).Count() > 0)
                {
                    return false;
                }
                
                    Equipment.Add(equipment);
                    return true;
                
            }
            else if (equipment is TrinketItem trinket)
            {
                if (Equipment.Where(a => a.EquipmentType == trinket.EquipmentType && a.EquipmentType != EquipmentType.NULL).Count() > 0)
                {
                    return false;
                }
                return false;
            }
            return false;
        }
    }
}

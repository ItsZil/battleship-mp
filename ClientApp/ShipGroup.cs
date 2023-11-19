using Newtonsoft.Json;
using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using SharedLibrary.Structs;

namespace ClientApp
{
    public class ShipGroup : IShipComponent
    {
        public int Group { get; set; } = 1;
        public int RemainingShots { get; set; } = 2;
        private List<IShipComponent> _ships = new List<IShipComponent>();
        private Client _client;

        public ShipGroup(int group, Client client)
        {
            Group = group;
            _client = client;
        }

        public void Add (IShipComponent ship)
        {
            _ships.Add(ship);
        }

        private int GetGroupDamage()
        {
            int damage = 0;
            foreach (IShipComponent ship in _ships)
            {
                Ship shipObj = (Ship)ship;
                if (shipObj.Health <= 0)
                    _ships.Remove(ship);
                else
                    damage += shipObj.CannonSize;
            }
            return damage;
        }

        public HitDetails SendShot(Shot shot)
        {
            int groupDamage = GetGroupDamage();
            if (groupDamage <= 0 || RemainingShots <= 0)
            {
                return new HitDetails
                {
                    ShotHappened = false
                };
            }
            shot.Damage = groupDamage;
            RemainingShots--;

            object hitDetailsObj = _client.SendMessage("SendShot", shot);
            HitDetails hitDetails = JsonConvert.DeserializeObject<HitDetails>(hitDetailsObj.ToString());
            return hitDetails;
        }
    }
}

using Newtonsoft.Json;
using SharedLibrary.Models;
using SharedLibrary.Structs;

namespace ClientApp.Handlers
{
    public class GroupShotHandler : ShotHandler
    {
        public override HitDetails HandleShot(Shot shot, Client client)
        {
            if (shot.Damage > 1)
            {
                object hitDetailsObj = client.SendMessage("SendShot", shot);
                HitDetails hitDetails = JsonConvert.DeserializeObject<HitDetails>(hitDetailsObj.ToString());
                return hitDetails;
            }
            else if (_nextHandler != null)
            {
                return _nextHandler.HandleShot(shot, client);
            }
            else
            {
                // No handler available for this damage level
                return new HitDetails
                {
                    ShotHappened = false
                };
            }
        }
    }
}

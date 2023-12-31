﻿using SharedLibrary.Interfaces;
using SharedLibrary.Structs;

namespace SharedLibrary.Models.Strategies
{
    public class ShootStrategy : IBoardCellInteractionStrategy
    {
        public HitDetails Interact(Game game, Shot shot) 
        {
            // TODO: take into account shot.Radius
            var hitDetails = new HitDetails(shot.X, shot.Y);

            List<Ship> targetShips = game.Ships.Where(s => s.PlayerId != shot.PlayerId && s.Health > 0).ToList();
            foreach (Ship ship in targetShips)
            {
                foreach (Coordinate coordinate in ship.Coordinates)
                {
                    if (coordinate.X == shot.X && coordinate.Y == shot.Y)
                    {
                        ship.Health -= shot.Damage;
                        if (ship.Health <= 0)
                            hitDetails.Sunk = true;
                        else
                            hitDetails.Hit = true;
                        hitDetails.HitShip = ship;
                        return hitDetails;
                    }
                }
            }
            return hitDetails;
        }

     
    }
}

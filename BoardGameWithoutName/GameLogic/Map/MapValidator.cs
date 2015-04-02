using GameLogic.Map.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Map 
{
    using GameLogic.Exceptions;

    public static class MapValidator
    {
        public static bool ValidateMap(GameMap map)
        {
            try
            {
                ValidateStartExist(map);
                ValidateConnectivity(map);
            }
            catch (InvalidGameMapException)
            {       
                throw;
            }
            
            return true;
        }

        private static bool ValidateConnectivity(GameMap map)
        {
            foreach (var field in map)
            {
                if(field.NextFields == null || field.NextFields.Count < 1)
                {
                    throw new GameMapInvalidConnectivityException("You must be able to continue from every field!", field);
                }

                if (field.PrevFields == null || field.PrevFields.Count < 1)
                {
                    throw new GameMapInvalidConnectivityException("Every map field must be reachable!", field);
                }
            }

            return true;
        }

        private static bool ValidateStartExist(GameMap map)
        {
            if(map.Start == null || (map.Start as StartField) == null)
            {
                throw new GameMapInvalidStartException("The game must have valid start field!");
            }

            return true;
        }
    }
}

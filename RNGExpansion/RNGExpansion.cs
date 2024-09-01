using PlaceholderAPI.API.Abstract;
using Exiled.API.Features;
using Exiled.API.Extensions;

namespace RNGExpansion
{
    public class RNGExpansion : PlaceholderExpansion
    {
        public override string Author { get; set; } = "NotZer0Two";
        public override string Identifier { get; set; } = "rng";
        public override string RequiredPlugin { get; set; } = null;

        public override string OnOfflineRequest(string param)
        {
            string converted = PlaceholderAPI.API.PlaceholderAPI.SetBracketsPlaceholders(param);
            string[] split = converted.Split('_');
            
            switch(split[0].ToLower())
            {
                case "online":
                    return Player.List.GetRandomValue().Nickname;
                case "random":
                    return UnityEngine.Random.Range(float.MinValue, float.MaxValue).ToString();
                case "color":
                    return UnityEngine.Random.ColorHSV().ToHex();
            };

            if (split.Length == 2 && int.TryParse(split[0], out int min) && int.TryParse(split[1], out int max))
            {
                return UnityEngine.Random.Range(min, max + 1).ToString();
            }

            return null;
        }
    }
}

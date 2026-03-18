using Newtonsoft.Json;

namespace ActividadAutonoma.Models
{
    public class PokemonDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public PokemonSprites Sprites { get; set; }
        public List<PokemonTypeInfo> Types { get; set; }
        public List<PokemonStatInfo> Stats { get; set; }
        public List<PokemonAbilityInfo> Abilities { get; set; }
        public List<PokemonMoveInfo> Moves { get; set; }
    }

    public class PokemonSprites
    {
        public string Front_Default { get; set; }
        public string Back_Default { get; set; }
        public string Front_Shiny { get; set; }
        public string Back_Shiny { get; set; }
        public string Front_Female { get; set; }
        public string Back_Female { get; set; }
        public OtherSprites Other { get; set; }
    }

    public class OtherSprites
    {
        public OfficialArtwork Official_Artwork { get; set; }

        [JsonProperty("official-artwork")]
        public OfficialArtwork OfficialArtwork { get; set; }
    }

    public class OfficialArtwork
    {
        public string Front_Default { get; set; }
        public string Front_Shiny { get; set; }
    }

    public class PokemonTypeInfo
    {
        public int Slot { get; set; }
        public PokemonType Type { get; set; }
    }

    public class PokemonType
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class PokemonStatInfo
    {
        public int Base_Stat { get; set; }
        public int Effort { get; set; }
        public PokemonStat Stat { get; set; }
    }

    public class PokemonStat
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class PokemonAbilityInfo
    {
        public bool Is_Hidden { get; set; }
        public int Slot { get; set; }
        public PokemonAbility Ability { get; set; }
    }

    public class PokemonAbility
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class PokemonMoveInfo
    {
        public PokemonMove Move { get; set; }
        public List<VersionGroupDetail> Version_Group_Details { get; set; }
    }

    public class PokemonMove
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class VersionGroupDetail
    {
        public int Level_Learned_At { get; set; }
        public MoveLearnMethod Move_Learn_Method { get; set; }
        public VersionGroup Version_Group { get; set; }
    }

    public class MoveLearnMethod
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class VersionGroup
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
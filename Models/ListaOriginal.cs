namespace ActividadAutonoma.Models
{
    public class ListaOriginal
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PokemonSummary> Results { get; set; }
    }

    public class PokemonSummary
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }


}

namespace MyPokemon.API
{
    public class ApiResponse<T>
    {
        public T Result { get; set; }
        public string TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}

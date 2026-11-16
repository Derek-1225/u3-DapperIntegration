namespace Orders.Api.models.dtos
{
    public sealed class StudentInfo
    {
        //El valor de section name debe ser identico al campo en el JSON de appsettings
        public const string SectionName = "student";
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
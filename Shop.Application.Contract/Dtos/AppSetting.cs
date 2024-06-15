namespace Shop.Application.Contract.Dtos
{
    public class AppSetting
    {
        public string Alaki { get; set; }
        public ImagesForOptions Images { get; set; }
    }

    public class ImagesForOptions
    {
        public string HttpImagePath { get; set; } = null!;
        public string FileImagePath { get; set; } = null!;
    }

    public class Images
    {
        public static string HttpImagePath { get; set; } = null!;
        public static string FileImagePath { get; set; } = null!;
    }
}

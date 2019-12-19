namespace FaceDetector.Dtos
{
    public class FaceAppImageDto
    {
        public string FileExtension { get; set; }
        public string ImageBase64 { get; set; }
        public int ImageBase64Length { get; set; }
        public int? PictureWidth { get; set; }
        public int? PictureHeight { get; set; }
        public string AnalyzeResult { get; set; }
    }
}

public class Book
{
  public string Title { get; set; } = "";
  public int PageCount { get; set; } = 0;
  public DateTime PublishedDate { get; set; } = DateTime.Now;
  public string ThumbnailUrl { get; set; } = "";
  public string Status { get; set; } = "";
  public string[] Authors { get; set; } = [];
  public string[] Categories { get; set; } = [];
}
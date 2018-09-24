# Booru.Net
A C# Wrapper for the Booru Image Boards.

Currently supported Boards are:
- Safebooru
- Rule34
- Realbooru
- Danbooru
- Gelbooru
- Konachan
- E621
- Yande.re

# How to get started

```cs
var BooruClient = new BooruClient();

var posts = await BooruClient.GetGelbooruImagesAsync("aisha_clanclan", "melfina");

if(posts != null)
{
  ...
}
```

List of Methods in Wrapper:
- `GetGelbooruImagesAsync(string[] tags)`
- `GetDanbooruImagesAsync(string[] tags)`
- `GetRule34ImagesAsync(string[] tags)`
- `GetE621ImagesAsync(string[] tags)`
- `GetKonaChanImagesAsync(string[] tags)`
- `GetYandereImagesAsync(string[] tags)`
- `GetRealBooruImagesAsync(string[] tags)`

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

# Contributing
If you wish to add more booru's to the wrapper/make the code better/optimise the code, please fork your own version and pull-request it. If you are planning on adding another booru to the wrapper, please do it in a similar style to the currently existing methods.

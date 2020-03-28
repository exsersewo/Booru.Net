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
var GelbooruClient = new GelbooruClient();

var posts = await GelbooruClient.GetImagesAsync("aisha_clanclan", "melfina");

if(posts != null)
{
  ...
}

List<string> tags = new List<string>
{
    "aisha_clanclan",
    "melfina"
};

posts = await GelbooruClient.GetImagesAsync(tags);

if(posts != null)
{
  ...
}
```

# Contributing
If you wish to add more booru's to the wrapper/make the code better/optimise the code, please fork your own version and pull-request it. If you are planning on adding another booru to the wrapper, please do it in a similar style to the currently existing methods.

namespace finals;

using System.Reflection;


class ImageLoader
{
    public static Image loadImage(string filePath){
        Assembly asm = Assembly.GetExecutingAssembly();

        Stream? stream = asm.GetManifestResourceStream(
                $"finals.assets.{filePath}"
                );

        if (stream is null)
            throw new Exception("Resource not found");

        using(stream) {
            return Image.FromStream(stream);
        }
    }

    public static Icon loadIcon(string filePath){
        Assembly asm = Assembly.GetExecutingAssembly();

        Stream? stream = asm.GetManifestResourceStream(
                $"finals.assets.{filePath}"
                );

        if (stream is null)
            throw new Exception("Resource not found");

        using(stream) {
            return new Icon(stream);
        }
    }

    public static string getFileExtension(string filePath){

        int length = filePath.Length;
        string extension = "";

        for (int i = length-1; i > 0; i--)
        {
            if (filePath[i] == '.') {
                break;
            }
            extension = filePath[i] + extension;
        }

        return extension;
    }
}



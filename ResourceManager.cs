namespace finals;

using System.ComponentModel;

class ResourceManager
{

    private static ComponentResourceManager? INSTANCE;

    public static ComponentResourceManager getInstance(){
        if (INSTANCE == null) {
            INSTANCE = new ComponentResourceManager(typeof(Form1));
        }

        return INSTANCE;
    }

    public static string getString(string key){
        var instance = getInstance();
        var result = instance.GetString(key);

        return (result == null ? "null" : result);
    }
    
}

using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

class SolarSystemOpenData
{
    public static string GetSolaireBodies()
    {
        string bodies_json = GetApiPage("https://api.le-systeme-solaire.net/rest.php/bodies");
        return bodies_json;
    }

    private static string GetApiPage(string url)
    {
        WebRequest wrGETURL = WebRequest.Create(url);
        Stream objStream = wrGETURL.GetResponse().GetResponseStream();
        //StreamReader objReader = new StreamReader(objStream);
        string spaceData = "";
        using (StreamReader streamReader = new StreamReader(objStream))
        {
            spaceData = streamReader.ReadToEnd();
        }
        return spaceData;
    }
}

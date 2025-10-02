using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsOfArda
{
    public static class AssetManager
    {
        /* Class to manage loading and caching of art assets
         * Art assets are stored in text files in the Assets/AsciiArt folder
         * ArtType enum is used to specify which asset to load
         * Add your assets to the project file by going into properties --> Build Action --> Content and Copy to Output Directory --> Copy if newer
         */

        // Dictonary to save all paths to art assets
        private static readonly Dictionary<ArtType, string> _artAssets = new Dictionary<ArtType, string>
        {
            { ArtType.None, "" },
            { ArtType.Logo, "./Assets/AsciiArt/logo.txt" }
        };
        // Cache to store loaded art assets
        private static readonly Dictionary<ArtType, string> _artCache = new Dictionary<ArtType, string>();

        // Method to get ascii art asset by type
        public static string GetAsciiArt(ArtType artType)
        {
            // If cache contains the art, return it
            if (_artCache.ContainsKey(artType))
            {
                return _artCache[artType];
            }
            // If not, load it from file, store it in cache and return it
            if (_artAssets.ContainsKey(artType))
            {
                string path = _artAssets[artType];
                try
                {
                    string art = File.ReadAllText(path);
                    _artCache[artType] = art;
                    return art;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading art asset from {path}: {ex.Message}");
                    return "";
                }
            }
            return "";
        }

        public static void PlayAsciiAnimation()
        {

        }
    }
}

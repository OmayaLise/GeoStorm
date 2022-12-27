using Raylib_cs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Geostorm
{
    public class Sounds
    {
        public string path;
        public string pathMusic;
        public string pathMusicGameOver;
        public string pathSound;
        public Music musicLoop;
        public Music musicGameOver;
        public Sound shootSound;

        public Sounds()
        {
            string pathMusic = Directory.GetCurrentDirectory();
            path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            pathMusic = path + "\\Ressources\\arcadeloop.mp3";
            pathMusicGameOver = path + "\\Ressources\\gameover.wav";
            pathSound = path + "\\Ressources\\shoot.wav";
            musicLoop = Raylib.LoadMusicStream(pathMusic);
            musicGameOver = Raylib.LoadMusicStream(pathMusicGameOver);
            shootSound = Raylib.LoadSound(pathSound);
        }

    }
}

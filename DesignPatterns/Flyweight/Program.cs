using Flyweight.Music;
using System;
using System.Collections.Generic;

namespace Flyweight
{
    // Summary:
    // It is used to minimize memory usage or computational expenses by sharing as much as possible with similar objects.
    // It is a way to use objects in large numbers when a simple repeated representation would use an unacceptable amount of memory.
    // It is about caching.
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Images 
            //LoadImages();            

            // 2. Kémiai alkalmazás: atomok, molekulák a "pehelysúlyú készlet"-ből
            //ChemistryExample();

            // !) Konstans állapotú objektumok
            // ConnectionPool, ThreadPool, DbContextPool

            MusicExample();

            Console.WriteLine();
        }

        private static void LoadImages()
        {
            var imageNames = new[] { "blue.bmp", "red.bmp", "yellow.bmp", "green.bmp" };

            var imageList = new List<Image>();
            var imagePool = new ImagePool();

            for (int i = 0; i < 300; i++)
            {
                string imageName = imageNames[i % 4];
                //Image image = new Image(imageName);
                Image image = imagePool.GetImage(imageName);
                imageList.Add(image);
            }
        }

        private static void ChemistryExample()
        {
            var chemicalSymbols = new[] { "H", "He", "O", "C", "Na" };

            var chemicalElements = new List<ChemicalElement>();
            var chemicalElementFactory = new ChemicalElementFactory();

            for (int i = 0; i < 100; i++)
            {
                string chemicalSymbol = chemicalSymbols[i % chemicalSymbols.Length];
                //ChemicalElement chemicalElement = new ChemicalElement(chemicalSymbol);
                ChemicalElement chemicalElement = chemicalElementFactory.GetChemicalElement(chemicalSymbol);
                chemicalElements.Add(chemicalElement);
            }

            // https://education.jlab.org/qa/atom_02.html
        }

        private static void MusicExample()
        {
            var musicSounds = new[] { "do", "re", "mi", "fa", "so", "la", "ti", "Do" };
            var soundElements = new List<Sound>();
            var soundFactory = new SoundFactory();

            for (int i = 0; i < 100; i++)
            {
                string soundSymbol = musicSounds[i % musicSounds.Length];
                Sound soundElement = soundFactory.GetSound(soundSymbol);
                soundElements.Add(soundElement);
            }

            foreach (var item in soundElements)
            {
                item.MakeSound();
            }
        }
    }
}

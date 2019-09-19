using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int hauteur = 80;
            int largeur = 79;

            char[,] monde = new char[hauteur,largeur];

            monde = initRandom(hauteur, largeur);

            while(true)
            {
                Console.Clear();
                show(monde, hauteur, largeur);
                Console.ReadKey();
                monde = refresh(monde, hauteur, largeur, 3, 5);
            }
        }

        static char[,] init(char[,] input, int h, int l)
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    input[i, j] = ' ';
                }
            }
            return input;
        }

        static char[,] initRandom(int h, int l)
        {
            Random rnd = new Random();

            char[,] input = new char[h, l];

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if(rnd.Next(0, 2) == 0)
                        input[i, j] = ' ';
                    else
                        input[i, j] = 'X';
                }
            }
            return input;
        }

        static char[,] init(int hauteur, int largeur)
        {
            char[,] input = new char[10, 10] {  { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, 
                                                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' }, 
                                                { ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ' }, 
                                                { ' ', ' ', ' ', ' ', 'X', 'X', 'X', ' ', ' ', ' ' }, 
                                                { ' ', ' ', ' ', ' ', 'X', ' ', 'X', ' ', ' ', ' ' }, 
                                                { ' ', ' ', ' ', ' ', 'X', 'X', 'X', ' ', ' ', ' ' }, 
                                                { ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ' }, 
                                                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' } };

            char[,] send = new char[hauteur, largeur];

            for(int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    send[i, j] = input[i, j];
                }

            for (int i = 10; i < hauteur; i++)
            {
                for (int j = 10; j < largeur ; j++)
                {
                    send[i, j] = ' ';
                }
            }

            return send;
        }

        static char[,] refresh(char[,] input, int h, int l, int survie, int mort)
        {
            char[,] refreshed = new char[h,l];
            refreshed = init(refreshed, h, l);
            for (int i = 1; i < h-1; i++)
            {
                for (int j = 1; j < l-1; j++)
                {
                    if (countLife(input, i, j, 'X') >= survie && countLife(input, i, j, 'X') <= mort)
                    {
                        refreshed[i, j] = 'X';
                    }
                    else
                    {
                        refreshed[i, j] = ' ';
                    }
                }
            }

            if (input == refreshed)
                refreshed = initRandom(h, l);

            return refreshed;
        }

        static int countLife(char[,] input, int x, int y, char vie)
        {
            int compteur = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (input[i, j] == vie)
                        compteur++;
                }
            }
            return compteur;
        }

        static void show(char[,] input, int h, int l)
        {
            string print = String.Empty;
            for (int i = 0; i < h; i++)
            {
                print = String.Empty;
                for (int j = 0; j < l; j++)
                {
                    print += input[i, j];
                }
                Console.WriteLine(print);
            }
        }
    }
}

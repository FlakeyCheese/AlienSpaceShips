using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienSpaceShips
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Alien_ship[] ships = new Alien_ship[10];//array of 10 ships
            
            StreamReader file = new StreamReader("../../resources/ships.txt");//open streamreader
            {
                for (int i = 0; i < ships.Length; i++) //loop through the file storing groups to temp
                {
                    string tempName = file.ReadLine();
                    int tempHP = Convert.ToInt32(file.ReadLine());
                    int tempSpeed = Convert.ToInt32(file.ReadLine());
                    int tempDamage = Convert.ToInt32(file.ReadLine());
                    bool tempFriendly = Convert.ToBoolean(file.ReadLine());
                    ships[i] = new Alien_ship(tempName, tempHP, tempSpeed, tempDamage, tempFriendly);//instantiate new alienship from temp
                }
            }
            file.Close();//close the file

            find_ships(ships,100,10,true);
        }

        public static void find_ships(Alien_ship[] ships, int speed, int damage, bool IsFriendly)
        {
            bool found = false;//a check to see if we found a ship that matches
            for (int i = 0; i < ships.Length; i++)
            {
                if (ships[i].getIsFriendly() == IsFriendly)
                {
                    if (ships[i].getSpeed() >= speed && ships[i].getDamage() >= damage)
                    {
                        found = true;
                        Console.WriteLine("Ship: " + ships[i].getName());
                        Console.WriteLine("Hit Points: " + ships[i].getHitPoints());
                        Console.WriteLine("Speed: " + ships[i].getSpeed());
                        Console.WriteLine("Damage: " + ships[i].getDamage());
                        Console.WriteLine("Friendly?: " + ships[i].getIsFriendly());
                        Console.WriteLine();
                    }
                }
            }
            if (!found) { Console.WriteLine("No ships found that match the criteria"); }
        }
            
    }
    public class Space_object
    {
        protected string name;
        protected int hit_points;

        public Space_object(string myname, int myhit_points)
        {
            this.name = myname;
            this.hit_points = myhit_points;
        }

    }
    public class Alien_ship:Space_object
    {
        private new string name;
        private new int hit_points;
        private int damage;
        private int speed;
        private bool is_friendly;

        public Alien_ship(string myname, int myhit_points, int mydamage, int myspeed, bool my_is_friendly):base(myname,myhit_points) 
        {
            this.name = myname;
            this.hit_points = myhit_points;
            this.damage = mydamage;
            this.speed = myspeed;
            this.is_friendly = my_is_friendly;
        }
        //getters and setters
        public void setName(string myname) {name=myname;}
        public string getName() {return name;}
        public void setHitpoints(int myHitPoints) { hit_points=myHitPoints;}
        public int getHitPoints() {return hit_points;}
        public void setDamage(int mydamage) {damage=mydamage;}
        public int getDamage() {return damage;}
        public void setSpeed(int myspeed) {speed=myspeed;}
        public int getSpeed() {return speed;}
        public void setIsFriendly(bool myisFriendly) {is_friendly=myisFriendly;}
        public bool getIsFriendly() { return is_friendly;}
    }
}

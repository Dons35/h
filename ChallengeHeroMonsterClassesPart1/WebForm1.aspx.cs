using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            dice dice = new dice();


            character hero = new character();
            hero.Name = "Silly Sam";
            hero.Health = 100;
            hero.DamageMaximum = 25;
            hero.AttackBonus = false;

            character monster = new character();
            monster.Name = "Jenova";
            monster.Health = 200;
            monster.DamageMaximum = 15;
            monster.AttackBonus = true;

            while (hero.Health > 0 && monster.Health > 0)
            {
                int damage = hero.Attack(dice);
                monster.Defend(damage);

                damage = monster.Attack(dice);
                hero.Defend(damage);

                displayCharacterStats(hero);
                displayCharacterStats(monster);
            }

            displayResults(hero, monster);

        }

        private void displayResults(character opponent1, character opponent2)
        {
            if (opponent1.Health > 0 && opponent2.Health <= 0)
                resultLabel.Text += String.Format("<p>{0} won.</p>", opponent1.Name);
            else if (opponent2.Health > 0 && opponent1.Health <= 0)
                resultLabel.Text += String.Format("<p>{0} won.</p>", opponent2.Name);
            else if (opponent1.Health <=0 && opponent2.Health <=0)
                resultLabel.Text += "They both lost.";
        }

        private void displayCharacterStats(character character)
        {
            resultLabel.Text += String.Format("<p>Name: {0} <br /> Health: {1} <br /> DamageMaximum: {2} <br /> AttackBonus: {3}</p>", character.Name, character.Health.ToString(), character.DamageMaximum.ToString(), character.AttackBonus.ToString());
                
        }
    }

    class character
    {
        public int Attack(dice dice)
        {
            dice.sides = this.DamageMaximum;
            return dice.Roll(dice.sides);

        }

        public void Defend(int damage)
        {
            this.Health -= damage;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

    }

    class dice
    {
        public int sides { get; set; }

        Random random2 = new Random();

        public int Roll(int sides)
        {
            return random2.Next(sides);
        }
    }
}
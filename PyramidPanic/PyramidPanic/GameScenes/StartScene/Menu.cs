//Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class.
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class Menu
    {

        //Fields

        //Maakt een enumeration voor de buttons die op het scherm te zien zijn.
        private enum Buttons { Start, Load, Help, Scores, Quit }

        //Maakt een variabele van het type Buttons en geef hem de waarde.Start.
        private Buttons buttonActive = Buttons.Start;

        //Maakt een variabele ( Reference ) van het type Image.
        private Image start;
        private Image load; 
        private Image help;
        private Image scores;
        private Image quit;

        //Maakt een variabele aan activeColor. Dit is de kleur van de actieve knop.
        private Color activeColor = Color.Gold;

        //Maakt een variabele ( Reference ) van het type PyramidPanic.
        private PyramidPanic game;


        //Constructor
        public Menu(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }


        public void Initialize()
        {
            this.LoadContent();
        }


        public void LoadContent()
        {
            this.start = new Image(this.game, @"StartScene\Button_start", new Vector2(10f, 435f));
            this.load = new Image(this.game, @"StartScene\Button_load", new Vector2(140f, 435f));
            this.scores = new Image(this.game, @"StartScene\Button_help", new Vector2(270f, 435f));
            this.help = new Image(this.game, @"StartScene\Button_scores", new Vector2(400f, 435f));
            this.quit = new Image(this.game, @"StartScene\Button_quit", new Vector2(530f, 435f));

            this.start.Color = Color.Gold;    
        }


        //Update
        public void Update(GameTime gameTime)
        {
            //Deze if - instructie checked of er op de rechterpijltoets wordt gedrukt. De eropvolgende actie is het ophogen van de variabele buttonActive.
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                this.buttonActive++;
            }

            switch (this.buttonActive)
            {
                case Buttons.Start:
                    this.start.Color = this.activeColor;
                    break;
                
                case Buttons.Load:
                    this.load.Color = this.activeColor;
                    break;

                case Buttons.Help:
                    this.scores.Color = this.activeColor;
                    break;

                case Buttons.Scores:
                    this.help.Color = this.activeColor;
                    break;

                case Buttons.Quit:
                    this.quit.Color = this.activeColor;
                    break;
            }
        }


        //Draw
        public void Draw(GameTime gameTime)
        {
            this.start.Draw(gameTime);
            this.load.Draw(gameTime);
            this.help.Draw(gameTime);
            this.scores.Draw(gameTime);
            this.quit.Draw(gameTime);
        }

    }
}

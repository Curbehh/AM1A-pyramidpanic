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
    public class StartScene : IState //De class StartScene implementeert de interface IState.
    {
        //Fields van de class StartScene.
        private PyramidPanic game;

        //Maakt een variabele ( Reference ) aan van de Image class genaamd background.
        private Image background, title;

        //Maakt een variabele ( Reference ) aan van de Menu class genaamd menu.
        private Menu menu;


        //Constructor van de StartScene class krijgt een object game mee van het type PyramidPanic.
        public StartScene(PyramidPanic game)
        {
            this.game = game;

            //Roept de initialize method aan.
            this.Initialize();
        }

        //Initialize methode. Deze methode initialiseert ( Geeft startwaarden aan variabelen ).
        //Void wil zeggen dat er niets teruggegeven wordt.
        public void Initialize()
        {
            //Roept de loadContent method aan.
            this.LoadContent();
        }

        //LoadContent methode. Deze methode maakt nieuwe objecten aan van de verschillende classes.
        public void LoadContent()
        {
            //Maakt een object van een object ( Instantie ) van de Image.
            this.background = new Image(this.game, @"StartScene\Background", Vector2.Zero);
            this.title = new Image(this.game, @"StartScene\Title", new Vector2(100f, 30f));
            this.menu = new Menu(this.game);
        }

        //Update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen en update alle variabelen, methods enz...
        public void Update(GameTime gametime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Right) || Input.EdgeDetectMousePressLeft() || Input.EdgeDetectMousePressRight())
            {
                this.game.IState = this.game.PlayScene;
            }

            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                this.game.IState = this.game.PlayScene;
            }
        }
         
        //Draw methode. Deze methode wordt normaal 60 maal per seconde aangeroepen en tekent de textures op het canvas.
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Red);
            this.background.Draw(gameTime);
            this.title.Draw(gameTime);
            this.menu.Draw(gameTime);
        }

    }

}

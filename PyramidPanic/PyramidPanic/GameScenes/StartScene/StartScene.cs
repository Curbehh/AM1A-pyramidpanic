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


        //Constructor van de StartScene class krijgt een object game mee van het type PyramidPanic.
        public StartScene(PyramidPanic game)
        {
            this.game = game;
        }

        //Initialize methode. Deze methode initialiseert ( Geeft startwaarden aan variabelen ).
        //Void wil zeggen dat er niets teruggegeven wordt.
        public void Initialize()
        {

        }

        //LoadContent methode. Deze methode maakt nieuwe objecten aan van de verschillende classes.
        public void LoadContent()
        {

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
        public void Draw(GameTime gametime)
        {
            this.game.GraphicsDevice.Clear(Color.Red);
        }

    }

}

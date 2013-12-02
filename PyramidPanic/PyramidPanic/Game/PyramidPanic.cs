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
    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
        //Fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //Maakt een variabele aan van het type StartScene.
        private StartScene startScene;

        //Maakt een variabele aan van het type PlayScene.
        private PlayScene playScene;

        //Maakt een variabele aan van het type HelpScene.
        private HelpScene helpScene;

        //Maakt een variabele aan van het type GameOverScene.
        private GameOverScene gameOverScene;

        //Maakt een variabele aan van het type Interface IState.
        private IState iState;

        //Properties
        #region Properties get/set
        //Maakt het Field iState beschikbaar buiten de class d.m.v een property iState.
        public IState IState
        {
            get { return this.iState; }
            set { this.iState = value; }
        }

        //Maakt het Field StartScene beschikbaar buiten de class d.m.v een property StartScene.
        public StartScene StartScene
        {
            get { return this.startScene; }
        }

        //Maakt het Field PlayScene beschikbaar buiten de class d.m.v een property PlayScene.
        public PlayScene PlayScene
        {
            get { return this.playScene; }
        }

        //Maakt het Field HelpScene beschikbaar buiten de class d.m.v een property HelpScene.
        public HelpScene HelpScene
        {
            get { return this.helpScene; }
        }

        //Maakt het Field GameOverScene beschikbaar buiten de class d.m.v een property GameOverScene.
        public GameOverScene GameoverScene
        {
            get { return this.gameOverScene; }
        } 
        #endregion

        //Dit is de constructor. Heeft altijd dezelfde naam als de class.
        public PyramidPanic()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //Verander de titel van het canvas.
            Window.Title = "Pyramid Panic Alpha 00.00.00.01";

            //Maakt de muis zichtbaar.
            IsMouseVisible = true;

            //Veranderd de breedte van het canvas.
            this.graphics.PreferredBackBufferWidth = 640;

            //Veranderd de hoogte van het canvas.
            this.graphics.PreferredBackBufferHeight = 480;

            //Past de nieuwe hoogte en breedte toe.
            this.graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {        
            //Een spritebatch is nodig voor het tekenen van textures op het canvas.
            spriteBatch = new SpriteBatch(GraphicsDevice);  

            //We maken nu een object/instantie aan van het type StartScene. Dit doe je door de constructor aan te roepen van de StartScene class.
            this.startScene = new StartScene(this);
            this.playScene = new PlayScene(this);
            this.helpScene = new HelpScene(this);
            this.gameOverScene = new GameOverScene(this);
            this.iState = this.startScene;
            
        }
       
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || (Keyboard.GetState().IsKeyDown(Keys.Escape)))

                this.Exit();

            //De Update Method van het object dat toegewezen is aan het interface-object this.iState wordt aangeroepen.
            this.iState.Update(gameTime);

            Input.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Geeft de achtergrond een kleur.
            GraphicsDevice.Clear(Color.Black);

            //Voor een spriteBatch instantie iets kan tekenen moet de Begin() methode aangeroepen worden van de SpriteBatch class.
            this.spriteBatch.Begin();

            //De Draw Method van het object dat toegewezen is aan het interface-object this.iState wordt aangeroepen.
            this.iState.Draw(gameTime);

            //Nadat de spriteBatch.Draw() is aangeroepen moet de End() methode van de SpriteBatch class worden aangeroepen.
            this.spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
